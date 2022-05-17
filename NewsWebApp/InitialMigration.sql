CREATE DATABASE NoticiasDB
GO
USE NoticiasDB
GO
CREATE TABLE Categorias(
	CategoriaId UNIQUEIDENTIFIER PRIMARY KEY,
	Nombre NVARCHAR(500) NOT NULL,
	FechaCreacion DATETIME2 NOT NULL,
	UsuarioCreacion NVARCHAR(254) NOT NULL,
	FechaModificacion DATETIME2 NOT NULL,
	UsuarioModificacion NVARCHAR(254) NOT NULL
)
GO
CREATE TABLE Noticias(
	NoticiaId UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo NVARCHAR(500) NOT NULL,
	Cuerpo NVARCHAR(MAX) NOT NULL,
	CategoriaId UNIQUEIDENTIFIER NOT NULL,
	FechaPublicacion DATETIME2 NOT NULL,
	FechaCreacion DATETIME2 NOT NULL,
	UsuarioCreacion NVARCHAR(254) NOT NULL,
	FechaModificacion DATETIME2 NOT NULL,
	UsuarioModificacion NVARCHAR(254) NOT NULL
)
GO
ALTER TABLE Noticias ADD CONSTRAINT FK_Noticias_Categorias
FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId);
GO
SELECT *
FROM sys.tables;
GO
INSERT INTO Categorias(CategoriaId, Nombre, FechaCreacion, UsuarioCreacion, FechaModificacion, UsuarioModificacion) 
VALUES
(NEWID(), 'Tecnologia',SYSDATETIME(), 'admin@imagina.com',SYSDATETIME(), 'admin@imagina.com'),
(NEWID(), 'Diseño',SYSDATETIME(), 'admin@imagina.com',SYSDATETIME(), 'admin@imagina.com'),
(NEWID(), 'Hardware',SYSDATETIME(), 'admin@imagina.com',SYSDATETIME(), 'admin@imagina.com');
GO
SELECT * FROM Categorias;
GO
INSERT INTO Noticias
VALUES
(NEWID(),'.Net Core 6','Crea una aplicacion web en menos de 10 mins.'
	,'566EF8EF-7DF3-4C34-BBBC-F58F72F729B9', SYSDATETIME(),SYSDATETIME(), 'admin',SYSDATETIME(), 'admin'),
(NEWID(),'Kafka','Procesa el flujo de todos los mensajes IOT.'
	,'566EF8EF-7DF3-4C34-BBBC-F58F72F729B9', SYSDATETIME(),SYSDATETIME(), 'admin',SYSDATETIME(), 'admin'),
(NEWID(),'RabbitMQ','El message broker robusto que se ha popularizado.'
	,'566EF8EF-7DF3-4C34-BBBC-F58F72F729B9', SYSDATETIME(),SYSDATETIME(), 'admin',SYSDATETIME(), 'admin')