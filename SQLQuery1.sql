CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    CreatedBy INT NULL,
    UpdatedBy INT NULL,
    DeletedBy INT NULL,
    CreatedDate DATETIME NOT NULL,
    DeletedDate DATETIME NULL,
    UpdatedDate DATETIME NULL,
    IsDeleted BIT NOT NULL,
    Name NVARCHAR(60) NOT NULL,
    Email NVARCHAR(60) NOT NULL
);
