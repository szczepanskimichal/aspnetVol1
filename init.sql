-- Utwórz bazę jeśli nie istnieje
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ShirtStoreDb')
BEGIN
    CREATE DATABASE ShirtStoreDb;
END
GO

