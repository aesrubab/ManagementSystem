CREATE TABLE [dbo].[Customers] (
    [Id]          INT           identity(1,1),
    [CreatedBy]   INT           NULL,
    [UpdatedBy]   INT           NULL,
    [DeletedBy]   INT           NULL,
    [CreatedDate] DATETIME      NOT NULL,
    [DeletedDate] DATETIME      NULL,
    [UpdatedDate] DATETIME      NULL,
    [IsDeleted]   BIT           NOT NULL,
    [Name]        NVARCHAR (60) NOT NULL,
    [Email]       NVARCHAR (60) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);