IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Students] (
    [StudentID] int NOT NULL IDENTITY,
    [FName] nvarchar(max) NOT NULL,
    [SName] nvarchar(max) NOT NULL,
    [IDNumber] nvarchar(max) NOT NULL,
    [EmailAddress] nvarchar(max) NOT NULL,
    [TimeCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316055522_First Migration', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230324040036_init', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Districts] (
    [ID] int NOT NULL IDENTITY,
    [STCode] int NOT NULL,
    [StateName] nvarchar(100) NOT NULL,
    [DTCode] int NOT NULL,
    [DistrictName] nvarchar(100) NOT NULL,
    [SDTCode] int NOT NULL,
    [SubDistrictName] nvarchar(100) NOT NULL,
    [TownCode] int NOT NULL,
    [AreaName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230324051344_Making Districts Table', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230324062857_ChangeAttriuteRanges', N'7.0.4');
GO

COMMIT;
GO

