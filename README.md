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
('CS0001', 'Internal compiler error: unexpected error encountered in the compiler.', 'May be caused by a bug in the compiler or corrupted installation.', 'var x = 1; // Unexpected compiler state'),
('CS0003', 'Syntax error: missing member declaration or invalid token.', 'A missing identifier or misplaced syntax, such as a missing bracket, can cause this error.', 'public class MyClass { int x = ; }'),
('CS0004', 'Unexpected symbol: the symbol does not belong to the current context.', 'Typo or misplaced operator may lead to this error.', 'Console.WriteLine(;;);'),
('CS0005', 'Invalid type: conversion or type incompatibility error.', 'Assigning a value of an incompatible type without proper conversion.', 'int x = "text";'),
('CS0006', 'Declaration is not valid: a code construct is used incorrectly.', 'Incorrect declaration of methods or variables.', 'void MyMethod { }'),
('CS0007', 'Member access error: trying to access a non-existing member.', 'Accessing a member that does not exist or has an incorrect name.', 'myObject.NonExistentMethod();'),
('CS0008', 'Namespace error: missing or incorrect namespace usage.', 'Not including the proper using directive or using the wrong namespace.', 'using System; Console.WriteLine(DateTime.Now);'),
('CS0009', 'Ambiguous call: method overload resolution failed.', 'Multiple methods match and the compiler cannot decide which one to use.', 'Console.WriteLine(1, 2);'),
('CS0010', 'Parameter error: incorrect number of parameters provided.', 'Calling a method with either fewer or extra parameters than required.', 'MyMethod(1, 2, 3);'),
('CS0011', 'Attribute error: attribute usage is not valid for this target.', 'Applying an attribute to an element that does not support it.', '[Serializable] int x = 0;');
GO

-- (Si deseas insertar también el error CS0103, hazlo en un nuevo INSERT)
INSERT INTO ErrorCatalog_English (ErrorCode, Description, PossibleCause, Example)
VALUES 
('CS0103', 'The name does not exist in the current context.', 'Variable not declared or a typo exists in the identifier.', 'Console.WriteLine(varName);');
GO

-- Insert sample data into the Spanish table
INSERT INTO ErrorCatalog_Spanish (ErrorCode, Descripcion, CausaPosible, Ejemplo)
VALUES 
('CS0001', 'Error interno del compilador: se encontró un error inesperado en el compilador.', 'Puede ser causado por un error en el compilador o una instalación corrupta.', 'var x = 1; // Estado inesperado del compilador'),
('CS0003', 'Error de sintaxis: falta la declaración de un miembro o token inválido.', 'La ausencia de un identificador o una sintaxis mal ubicada, como corchetes faltantes, puede causar este error.', 'public class MiClase { int x = ; }'),
('CS0004', 'Símbolo inesperado: el símbolo no pertenece al contexto actual.', 'Un error tipográfico o un operador mal colocado puede provocar este error.', 'Console.WriteLine(;;);'),
('CS0005', 'Tipo inválido: error de conversión o incompatibilidad de tipos.', 'Se está asignando un valor de un tipo incompatible sin la conversión adecuada.', 'int x = "texto";'),
('CS0006', 'La declaración no es válida: se usa incorrectamente una construcción de código.', 'Declaración incorrecta de métodos o variables.', 'void MiMetodo { }'),
('CS0007', 'Error de acceso a miembro: se intenta acceder a un miembro inexistente.', 'Acceder a un miembro que no existe o cuyo nombre es incorrecto.', 'miObjeto.MetodoInexistente();'),
('CS0008', 'Error de espacio de nombres: falta o se utiliza incorrectamente.', 'No se incluye la directiva using adecuada o se usa un espacio de nombres equivocado.', 'using System; Console.WriteLine(DateTime.Now);'),
('CS0009', 'Llamada ambigua: la resolución de sobrecarga de métodos falló.', 'Existen múltiples métodos que coinciden y el compilador no puede decidir cuál usar.', 'Console.WriteLine(1, 2);'),
('CS0010', 'Error de parámetros: número incorrecto de parámetros proporcionados.', 'Llamar a un método con un número de parámetros diferente al requerido.', 'MiMetodo(1, 2, 3);'),
('CS0011', 'Error de atributo: el uso del atributo no es válido para este elemento.', 'Aplicar un atributo a un elemento de código que no lo admite.', '[Serializable] int x = 0;');
GO

-- (Si deseas insertar también el error CS0103 en la tabla en español, hazlo en un nuevo INSERT)
INSERT INTO ErrorCatalog_Spanish (ErrorCode, Descripcion, CausaPosible, Ejemplo)
VALUES 
('CS0103', 'El nombre no existe en el contexto actual.', 'La variable no fue declarada o hay un error tipográfico.', 'Console.WriteLine(nombreVariable);');
GO

-- Create an index on the English table's Description column
CREATE INDEX IX_ErrorCatalog_English_Description
ON ErrorCatalog_English (Description);
GO


-- Create an index on the English table's Description column
CREATE INDEX IX_ErrorCatalog_English_Description
ON ErrorCatalog_English (Description);
GO


