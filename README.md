# Error Catalog API - Multilingual Lookup Service

This project is a .NET Core web API that provides error codes and details in English and Spanish, using data stored in a SQL Server database. The API includes a Swagger UI for easy documentation and testing. All error reference information is sourced from learn.microsoft.com

Use a SQL data extraction query for Spanish and English: 
--------------------------------------------------------


-- Create the database
CREATE DATABASE ErrorCatalogDB;
GO

-- Use the created database
USE ErrorCatalogDB;
GO

-- Create table for error catalog in English
CREATE TABLE ErrorCatalog_English (
    ErrorCode NVARCHAR(10) NOT NULL PRIMARY KEY,
    Description NVARCHAR(255) NOT NULL,
    PossibleCause NVARCHAR(255),
    Example NVARCHAR(MAX)
);
GO

-- Create table for error catalog in Spanish
CREATE TABLE ErrorCatalog_Spanish (
    ErrorCode NVARCHAR(10) NOT NULL PRIMARY KEY,
    Descripcion NVARCHAR(255) NOT NULL,
    CausaPosible NVARCHAR(255),
    Ejemplo NVARCHAR(MAX)
);
GO

-- Insert sample data into the English table
INSERT INTO ErrorCatalog_English (ErrorCode, Description, PossibleCause, Example)
VALUES 
('CS1002', ''';'' expected', 'Missing semicolon at the end of the statement.', 'Console.WriteLine("Hello World") // Missing semicolon');

INSERT INTO ErrorCatalog_English (ErrorCode, Description, PossibleCause, Example)
VALUES 
('CS0103', 'The name does not exist in the current context.', 'Variable not declared or a typo exists in the identifier.', 'Console.WriteLine(varName);');
GO

-- Insert sample data into the Spanish table
INSERT INTO ErrorCatalog_Spanish (ErrorCode, Descripcion, CausaPosible, Ejemplo)
VALUES 
('CS1002', 'Se esperaba "";""', 'Falta el punto y coma al final de la declaración.', 'Console.WriteLine("Hola Mundo") // Falta el punto y coma');

INSERT INTO ErrorCatalog_Spanish (ErrorCode, Descripcion, CausaPosible, Ejemplo)
VALUES 
('CS0103', 'El nombre no existe en el contexto actual.', 'La variable no fue declarada o hay un error tipográfico.', 'Console.WriteLine(nombreVariable);');
GO

-- Create an index on the English table's Description column
CREATE INDEX IX_ErrorCatalog_English_Description
ON ErrorCatalog_English (Description);
GO


