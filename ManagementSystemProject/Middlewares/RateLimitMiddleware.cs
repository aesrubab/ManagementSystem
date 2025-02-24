using ManagementSystem.Common.GlobalResponses;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Text.Json;

namespace ManagementSystemProject.Middlewares;

public class RateLimitMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    //_requestCounts: Bütün müştəri sorğularını izləmək üçün Thread-Safe (axın təhlükəsiz) bir dictionary. Burada, hər bir müştərinin (client) sorğu sayı saxlanılır.
    private static readonly ConcurrentDictionary<string, int> _requestCounts = new();

    //_timeWindow: 1 dəqiqəlik bir zaman pəncərəsi təyin edilir. Yəni, 1 dəqiqə ərzində müəyyən bir müştəri həddindən artıq sorğu göndərərsə, bloklanacaq.
    private static readonly TimeSpan _timeWindow = TimeSpan.FromMinutes(1);


    //_resetTime: Hər 1 dəqiqədən bir sorğu sayını sıfırlamaq üçün istifadə olunur
    private static DateTime _resetTime = DateTime.UtcNow.Add(_timeWindow);
    private const int _maxRequest = 5;

    public async Task InvokeAsync(HttpContext context)
    {
        string clientKey = "global";


     

        //Əgər 1 dəqiqəlik vaxt pəncərəsi bitibsə, _requestCounts sıfırlanır və yeni bir zaman pəncərəsi başlayır.
        if (DateTime.UtcNow >= _resetTime)
        {
            _requestCounts.Clear();
            _resetTime = DateTime.UtcNow.Add(_timeWindow);
        }

        _requestCounts.AddOrUpdate(clientKey, 1, (_, count) => count + 1);

        if (_requestCounts[clientKey] >= _maxRequest)
        {
            var message = new List<string>() { "Many request" };
            await WriteError(context, HttpStatusCode.TooManyRequests, message);
            return;
        }
        await _next(context);
    }

    public static async Task WriteError(HttpContext context, HttpStatusCode statusCode, List<string> messages)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(new Result(messages));
        await context.Response.WriteAsync(json);
    }
}

