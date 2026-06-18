-- ==========================================
-- 1. CREACIÓN DE LA BASE DE DATOS
-- ==========================================
CREATE DATABASE BibliotecaDB;
GO

USE BibliotecaDB;
GO

-- ==========================================
-- 2. CREACIÓN DE TABLAS (CON RELACIONES)
-- ==========================================

-- Tabla 1: Categorías
CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100)
);

-- Tabla 2: Libros
CREATE TABLE Libros (
    IdLibro INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL,
    Autor VARCHAR(100) NOT NULL,
    Anio INT,
    IdCategoria INT,
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);

-- Tabla 3: Usuarios
CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Correo VARCHAR(100),
    Telefono VARCHAR(20)
);

-- Tabla 4: Login
CREATE TABLE Login (
    IdLogin INT IDENTITY(1,1) PRIMARY KEY,
    Usuario VARCHAR(30) UNIQUE NOT NULL,
    Clave VARCHAR(50) NOT NULL
);

-- Tabla 5: Préstamos
CREATE TABLE Prestamos (
    IdPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT,
    IdLibro INT,
    FechaPrestamo DATE NOT NULL,
    FechaDevolucion DATE,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdLibro) REFERENCES Libros(IdLibro)
);
GO

-- ==========================================
-- 3. INSERCIÓN DE DATOS INICIALES
-- ==========================================
-- Usuario administrador por defecto para el Login
INSERT INTO Login (Usuario, Clave) VALUES ('admin', 'admin123');
GO


-- ==========================================
-- 4. PROCEDIMIENTOS ALMACENADOS (CRUD)
-- ==========================================

--- PROCEDIMIENTOS PARA CATEGORÍAS ---
CREATE PROCEDURE sp_InsertarCategoria
    @NombreCategoria VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categorias (NombreCategoria, Descripcion) 
    VALUES (@NombreCategoria, @Descripcion);
END;
GO

CREATE PROCEDURE sp_ActualizarCategoria
    @IdCategoria INT,
    @NombreCategoria VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categorias 
    SET NombreCategoria = @NombreCategoria, Descripcion = @Descripcion 
    WHERE IdCategoria = @IdCategoria;
END;
GO


--- PROCEDIMIENTOS PARA LIBROS ---
CREATE PROCEDURE sp_InsertarLibro
    @Titulo VARCHAR(100),
    @Autor VARCHAR(100),
    @Anio INT,
    @IdCategoria INT
AS
BEGIN
    INSERT INTO Libros (Titulo, Autor, Anio, IdCategoria)
    VALUES (@Titulo, @Autor, @Anio, @IdCategoria);
END;
GO

CREATE PROCEDURE sp_ActualizarLibro
    @IdLibro INT,
    @Titulo VARCHAR(100),
    @Autor VARCHAR(100),
    @Anio INT,
    @IdCategoria INT
AS
BEGIN
    UPDATE Libros
    SET Titulo = @Titulo, Autor = @Autor, Anio = @Anio, IdCategoria = @IdCategoria
    WHERE IdLibro = @IdLibro;
END;
GO


--- PROCEDIMIENTOS PARA USUARIOS ---
CREATE PROCEDURE sp_InsertarUsuario
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Correo VARCHAR(100),
    @Telefono VARCHAR(20)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Apellido, Correo, Telefono)
    VALUES (@Nombre, @Apellido, @Correo, @Telefono);
END;
GO

CREATE PROCEDURE sp_ActualizarUsuario
    @IdUsuario INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Correo VARCHAR(100),
    @Telefono VARCHAR(20)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Telefono = @Telefono
    WHERE IdUsuario = @IdUsuario;
END;
GO


--- PROCEDIMIENTOS PARA PRÉSTAMOS ---
CREATE PROCEDURE sp_RegistrarPrestamo
    @IdUsuario INT,
    @IdLibro INT,
    @FechaPrestamo DATE
AS
BEGIN
    INSERT INTO Prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucion)
    VALUES (@IdUsuario, @IdLibro, @FechaPrestamo, NULL);
END;
GO

CREATE PROCEDURE sp_DevolverLibro
    @IdPrestamo INT,
    @FechaDevolucion DATE
AS
BEGIN
    UPDATE Prestamos
    SET FechaDevolucion = @FechaDevolucion
    WHERE IdPrestamo = @IdPrestamo;
END;
GO