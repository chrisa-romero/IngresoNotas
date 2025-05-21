IF EXISTS (SELECT name FROM sys.databases WHERE name = 'candidato05')
BEGIN
	DROP DATABASE candidato05
END

CREATE DATABASE candidato05
GO

USE candidato05
GO

CREATE TABLE Alumnos (
    Carnet NVARCHAR(7) PRIMARY KEY NOT NULL,
    Nombres NVARCHAR(150) NOT NULL,
    Apellidos NVARCHAR(150) NOT NULL,
    Fecha_Ingreso SMALLDATETIME NOT NULL,
    CarreraId INT NOT NULL
)
GO

CREATE TABLE Carreras (
    CarreraId INT PRIMARY KEY IDENTITY NOT NULL,
    Titulo NVARCHAR(150) NOT NULL,
	Facultad NVARCHAR(150) NOT NULL,
)
GO

CREATE TABLE Materias (
    MateriaId INT PRIMARY KEY IDENTITY NOT NULL,
    Nombre NVARCHAR(150) NOT NULL
)
GO

CREATE TABLE Carreras_Alumnos (
    CarreraId INT NOT NULL,
    Carnet NVARCHAR(7) NOT NULL,
    PRIMARY KEY (CarreraId, Carnet),
    FOREIGN KEY (CarreraId) REFERENCES Carreras(CarreraId),
    FOREIGN KEY (Carnet) REFERENCES Alumnos(Carnet)
)
GO

CREATE TABLE Carreras_Materias (
    CarreraId INT NOT NULL,
    MateriaId INT NOT NULL,
    PRIMARY KEY (CarreraId, MateriaId),
    FOREIGN KEY (CarreraId) REFERENCES Carreras(CarreraId),
    FOREIGN KEY (MateriaId) REFERENCES Materias(MateriaId)
)
GO

CREATE PROCEDURE InsertAlumno
    @Carnet NVARCHAR(7),
    @Nombres NVARCHAR(150),
    @Apellidos NVARCHAR(150),
    @Fecha_Ingreso SMALLDATETIME,
    @CarreraId INT
AS
BEGIN
    INSERT INTO Alumnos (Carnet, Nombres, Apellidos, Fecha_Ingreso, CarreraId)
    VALUES (@Carnet, @Nombres, @Apellidos, @Fecha_Ingreso, @CarreraId);
END
GO

CREATE PROCEDURE UpdateAlumno
    @Carnet NVARCHAR(7),
    @Nombres NVARCHAR(150),
    @Apellidos NVARCHAR(150),
    @Fecha_Ingreso SMALLDATETIME,
    @CarreraId INT
AS
BEGIN
    UPDATE Alumnos
    SET Nombres = @Nombres, Apellidos = @Apellidos, Fecha_Ingreso = @Fecha_Ingreso, CarreraId = @CarreraId
    WHERE Carnet = @Carnet;
END
GO

CREATE PROCEDURE DeleteAlumno
    @Carnet NVARCHAR(7)
AS
BEGIN
    DELETE FROM Alumnos WHERE Carnet = @Carnet;
END
GO

CREATE PROCEDURE SelectAlumno
AS
BEGIN
    SELECT * FROM Alumnos;
END
GO

CREATE PROCEDURE SelectAlumnoByCarnet
	@Carnet NVARCHAR(7)
AS
BEGIN
    SELECT * FROM Alumnos WHERE Carnet = @Carnet;
END
GO

CREATE PROCEDURE InsertCarrera
    @Titulo NVARCHAR(150),
	@Facultad NVARCHAR(150)
AS
BEGIN
    INSERT INTO Carreras (Titulo, Facultad)
    VALUES (@Titulo, @Facultad);
END
GO

CREATE PROCEDURE UpdateCarrera
    @CarreraId INT,
    @Titulo NVARCHAR(150),
    @Facultad NVARCHAR(150)
AS
BEGIN
    UPDATE Carreras
    SET Titulo = @Titulo,
		Facultad = @Facultad
    WHERE CarreraId = @CarreraId;
END
GO

CREATE PROCEDURE DeleteCarrera
    @CarreraId INT
AS
BEGIN
    DELETE FROM Carreras WHERE CarreraId = @CarreraId;
END
GO

CREATE PROCEDURE SelectCarreras
AS
BEGIN
    SELECT * FROM Carreras;
END
GO

CREATE PROCEDURE SelectCarreraById
    @CarreraId INT
AS
BEGIN
    SELECT * FROM Carreras WHERE CarreraId = @CarreraId;
END
GO

CREATE PROCEDURE InsertMateria
    @Nombre NVARCHAR(150)
AS
BEGIN
    INSERT INTO Materias (Nombre)
    VALUES (@Nombre);
END
GO

CREATE PROCEDURE UpdateMateria
    @MateriaId INT,
    @Nombre NVARCHAR(150)
AS
BEGIN
    UPDATE Materias
    SET Nombre = @Nombre
    WHERE MateriaId = @MateriaId;
END
GO

CREATE PROCEDURE DeleteMateria
    @MateriaId INT
AS
BEGIN
    DELETE FROM Materias WHERE MateriaId = @MateriaId;
END
GO

CREATE PROCEDURE SelectMaterias
AS
BEGIN
    SELECT * FROM Materias;
END
GO

CREATE PROCEDURE SelectMateriaById
    @MateriaId INT
AS
BEGIN
    SELECT * FROM Materias WHERE MateriaId = @MateriaId;
END
GO

INSERT INTO Carreras(Titulo, Facultad) VALUES ('Sistemas', 'Ingeniería'), ('Pediatría', 'Medicina')
GO

INSERT INTO Alumnos(Carnet, Nombres, Apellidos, Fecha_Ingreso, CarreraId) VALUES ('CR00001', 'Christian', 'Romero', '20250101', 1), ('JV00002', 'Julio', 'Verne', '20240601', 2)
GO

INSERT INTO Materias(Nombre) VALUES('Programación I'), ('Medicina General 1'), ('Matematicas I')
GO

INSERT INTO Carreras_Alumnos(CarreraId, Carnet) VALUES(1, 'CR00001'), (2, 'JV00002')
INSERT INTO Carreras_Materias VALUES(1, 1), (1, 3), (2, 2)
GO