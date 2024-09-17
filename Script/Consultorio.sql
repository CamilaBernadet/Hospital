USE master 

go 


if exists(SELECT * FROM sys.databases WHERE name = 'Mutualista')
BEGIN
	DROP DATABASE Mutualista
END
go
 


CREATE DATABASE Mutualista
go



USE Mutualista
go



-----ISS
USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE Mutualista
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
go

-----------------Tablas-----------------------------


CREATE TABLE Empleado (
    NombreUsu VARCHAR(8)  PRIMARY KEY CHECK (LEN(NombreUsu) = 8),
    PassUsu VARCHAR(6) NOT NULL CHECK (LEN(PassUsu) = 6 AND PassUsu LIKE '%[A-Za-z]%[A-Za-z]%[A-Za-z]%' AND 
															PassUsu LIKE '%[0-9]%[0-9]%[0-9]%')
);
GO


CREATE TABLE Policlinica (
    Codigo VARCHAR(6) PRIMARY KEY CHECK (LEN(Codigo) = 6 AND Codigo NOT LIKE '%[^A-Za-z]%'),
    Nombre VARCHAR(50) NOT NULL,
    Direccion VARCHAR(100) NOT NULL
);
GO


CREATE TABLE Consultorio (
    NumeroConsultorio INT NOT NULL CHECK (NumeroConsultorio > 0),
    CodigoPol VARCHAR(6) NOT NULL,
    Descripcion VARCHAR(100),
    PRIMARY KEY (NumeroConsultorio, CodigoPol),
    FOREIGN KEY (CodigoPol) REFERENCES Policlinica(Codigo),
    ActivoC BIT DEfAULT (1)
);
GO

CREATE TABLE Paciente (
    CiPaciente VARCHAR(10) PRIMARY KEY CHECK (CiPaciente LIKE '[1-6][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Nombre VARCHAR(50) NOT NULL,
    Fecha_Nacimiento DATE NOT NULL CHECK (Fecha_Nacimiento < GETDATE()),
    ActivoP BIT DEFAULT (1)
);
GO


CREATE TABLE Patologia (
    CI_Paciente VARCHAR(10) NOT NULL,
    Patologia VARCHAR(100),
    PRIMARY KEY (CI_Paciente, Patologia),
    FOREIGN KEY (CI_Paciente) REFERENCES Paciente(CiPaciente)
);
GO


CREATE TABLE Consulta (
    NumeroInterno INT IDENTITY(1,1) PRIMARY KEY,
    CodigoPol VARCHAR(6),
    Id_Consultorio INT NOT NULL,
    Fecha_Consulta DATETIME NOT NULL CHECK (Fecha_Consulta > GETDATE()),
    Medico VARCHAR(50) NOT NULL,
    Especialidad VARCHAR(50) NOT NULL,
    CantidadNumeros INT NOT NULL CHECK (CantidadNumeros >= 1 AND CantidadNumeros <= 20),
    FOREIGN KEY (Id_Consultorio, CodigoPol) REFERENCES Consultorio(NumeroConsultorio, CodigoPol)  
);
GO

CREATE TABLE Solicitud (
    NumeroInterno INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(),
    Asistencia BIT NOT NULL DEFAULT 0,
    CI_Paciente VARCHAR(10) NOT NULL,
    NumeroConsulta INT NOT NULL,
    NombreUsu VARCHAR(8) NOT NULL,
    FOREIGN KEY (CI_Paciente) REFERENCES Paciente(CiPaciente),
    FOREIGN KEY (NumeroConsulta) REFERENCES Consulta(NumeroInterno),
    FOREIGN KEY (NombreUsu) REFERENCES Empleado(NombreUsu)
);
GO

-------------Datos de Pruebas-------------------

--10 Empleados
INSERT INTO Empleado (NombreUsu, PassUsu) VALUES
('Albeto01', 'ABC123'),
('Abigail1', 'DEF456'),
('Benjami1', 'GHI789'),
('Danielle', 'JKL012'),
('Eleonora', 'MNO345'),
('Ferdinan', 'PQR678'),
('Gabriela', 'STU901'),
('Isabella', 'VWX234'),
('Jonathan', 'YZA567'),
('Kimberly', 'BCD890'),
('Leonardo', 'EFG123'),
('Margarit', 'HIJ456');
GO


-- 10 registros de Policlinica
INSERT INTO Policlinica (Codigo, Nombre, Direccion) VALUES
('XXXRRR', 'Policlinica Central', 'Calle 123'),
('EEETTT', 'Policlinica Norte', 'Calle 234'),
('MMMAAA', 'Policlinica Sur', 'Calle 345'),
('ZERTRA', 'Policlinica Este', 'Calle 456'),
('CARDEN', 'Policlinica Oeste', 'Calle 567'),
('TREITE', 'Policlinica Centro', 'Calle 678'),
('POLRIV', 'Policlinica Alturas', 'Calle 789'),
('POLTAC', 'Policlinica Lomas', 'Calle 890'),
('POLMDO', 'Policlinica Marina', 'Calle 901'),
('POLSJE', 'Policlinica Valle', 'Calle 012');
go


--20 consultorio
INSERT INTO Consultorio (CodigoPol, NumeroConsultorio, Descripcion) VALUES
('XXXRRR', 2, 'Consultorio de Radiología Completa con equipo de última generación'),
('EEETTT', 3, 'Consultorio equipado con camilla y equipo de monitoreo'),
('MMMAAA', 5, 'Consultorio general con espacio amplio y ventilación'),
('ZERTRA', 4, 'Consultorio con equipamiento básico para revisiones generales'),
('CARDEN', 8, 'Consultorio dental equipado sin camilla, para tratamientos odontológicos'),
('TREITE', 9, 'Consultorio general con acceso a equipo de diagnóstico'),
('POLRIV', 23, 'Consultorio especializado en fisioterapia con equipo avanzado'),
('POLTAC', 43, 'Consultorio para exámenes de laboratorio con equipo de análisis'),
('POLMDO', 12, 'Consultorio ginecológico con equipamiento especializado'),
('POLSJE', 42, 'Consultorio de endocrinología con equipo de diagnóstico avanzado'),
('XXXRRR', 6, 'Consultorio general para consultas de medicina interna'),
('EEETTT', 7, 'Consultorio de pediatría con área de juegos para niños'),
('MMMAAA', 10, 'Consultorio de ginecología con equipo moderno y espacio privado'),
('ZERTRA', 11, 'Consultorio de cardiología con equipo de monitoreo cardíaco'),
('CARDEN', 13, 'Consultorio de neurología con equipo de electroencefalografía'),
('TREITE', 14, 'Consultorio de endocrinología con equipo de análisis hormonal'),
('POLRIV', 15, 'Consultorio de psiquiatría con ambiente tranquilo y privado'),
('POLTAC', 16, 'Consultorio de dermatología con lámparas de luz ultravioleta'),
('POLMDO', 17, 'Consultorio de oftalmología con equipo de refracción y diagnóstico visual'),
('POLSJE', 18, 'Consultorio de urología con equipo de ultrasonido y análisis urinario');
GO

-------20 Pacientes Faltan 30
INSERT INTO Paciente (CiPaciente, Nombre, Fecha_Nacimiento) VALUES
('12345678', 'Carlos Méndez', '1987-03-21'),
('23456789', 'Ana Torres', '1995-06-05'),
('34567890', 'Fernando Díaz', '1972-01-19'),
('45678901', 'Lucía Fernández', '1984-08-13'),
('56789012', 'Martín Rojas', '1990-11-30'),
('67890123', 'Claudia Suárez', '2001-04-22'),
('18901234', 'José Navarro', '1968-02-17'),
('29012345', 'María López', '1993-09-28'),
('30123456', 'Raúl Vargas', '1985-07-10'),
('41234567', 'Diana Castillo', '1999-12-12'),
('52341234', 'Gabriel Pérez', '1978-05-15'),
('63452345', 'Laura García', '1982-07-23'),
('14563456', 'Santiago Ramírez', '1991-08-30'),
('25674567', 'Verónica Hernández', '1983-04-02'),
('36785678', 'Manuel López', '1996-11-14'),
('47896789', 'Patricia Gómez', '1976-09-08'),
('58907890', 'Ricardo Sánchez', '1989-06-17'),
('69018901', 'Carolina Ortiz', '2002-03-11'),
('10129012', 'Andrés Jiménez', '1974-01-29'),
('21230123', 'Rosa Fernández', '1998-10-20');
GO


--10 Patologias
INSERT INTO Patologia (CI_Paciente, Patologia) VALUES
('12345678', 'Hipertensión'),
('23456789', 'Diabetes'),
('34567890', 'Asma'),
('45678901', 'Alergias'),
('56789012', 'Migrañas'),
('67890123', 'Obesidad'),
('18901234', 'Cardiopatía'),
('29012345', 'Artritis'),
('30123456', 'Depresión'),
('41234567', 'Hipotiroidismo'),
('52341234', 'Hipertensión'),
('63452345', 'Diabetes'),
('14563456', 'Asma'),
('25674567', 'Alergias'),
('36785678', 'Migrañas'),
('47896789', 'Obesidad'),
('58907890', 'Cardiopatía'),
('69018901', 'Artritis'),
('10129012', 'Depresión'),
('21230123', 'Hipotiroidismo');
GO


---30 Consultas

INSERT INTO Consulta (CodigoPol, Id_Consultorio, Fecha_Consulta, Medico, Especialidad, CantidadNumeros)
VALUES
('XXXRRR', 2, '2024-11-01T09:00:00', 'Dr. Gómez', 'Radiología', 5),
('EEETTT', 3, '2024-11-01T10:00:00', 'Dra. Pérez', 'Medicina General', 6),
('MMMAAA', 5, '2024-11-01T11:00:00', 'Dr. Díaz', 'Pediatría', 7),
('ZERTRA', 4, '2024-11-01T12:00:00', 'Dra. Torres', 'Dermatología', 8),
('CARDEN', 8, '2024-11-01T13:00:00', 'Dr. Suárez', 'Odontología', 9),
('TREITE', 9, '2024-11-01T14:00:00', 'Dra. Rojas', 'Ginecología', 10),
('POLRIV', 23, '2024-11-01T15:00:00', 'Dr. Vargas', 'Traumatología', 11),
('POLTAC', 43, '2024-11-01T16:00:00', 'Dra. López', 'Psiquiatría', 12),
('POLMDO', 12, '2024-11-01T17:00:00', 'Dr. Castillo', 'Neurología', 13),
('POLSJE', 42, '2024-11-01T18:00:00', 'Dra. Navarro', 'Oftalmología', 14),
('XXXRRR', 2, '2024-11-02T09:00:00', 'Dr. Gómez', 'Radiología', 5),
('EEETTT', 3, '2024-11-02T10:00:00', 'Dra. Pérez', 'Medicina General', 6),
('MMMAAA', 5, '2024-11-02T11:00:00', 'Dr. Díaz', 'Pediatría', 7),
('ZERTRA', 4, '2024-11-02T12:00:00', 'Dra. Torres', 'Dermatología', 8),
('CARDEN', 8, '2024-11-02T13:00:00', 'Dr. Suárez', 'Odontología', 9),
('TREITE', 9, '2024-11-02T14:00:00', 'Dra. Rojas', 'Ginecología', 10),
('POLRIV', 23, '2024-11-02T15:00:00', 'Dr. Vargas', 'Traumatología', 11),
('POLTAC', 43, '2024-11-02T16:00:00', 'Dra. López', 'Psiquiatría', 12),
('POLMDO', 12, '2024-11-02T17:00:00', 'Dr. Castillo', 'Neurología', 13),
('POLSJE', 42, '2024-11-02T18:00:00', 'Dra. Navarro', 'Oftalmología', 14),
('XXXRRR', 2, '2024-11-03T09:00:00', 'Dr. Gómez', 'Radiología', 5),
('EEETTT', 3, '2024-11-03T10:00:00', 'Dra. Pérez', 'Medicina General', 6),
('MMMAAA', 5, '2024-11-03T11:00:00', 'Dr. Díaz', 'Pediatría', 7),
('ZERTRA', 4, '2024-11-03T12:00:00', 'Dra. Torres', 'Dermatología', 8),
('CARDEN', 8, '2024-11-03T13:00:00', 'Dr. Suárez', 'Odontología', 9),
('TREITE', 9, '2024-11-03T14:00:00', 'Dra. Rojas', 'Ginecología', 10),
('POLRIV', 23, '2024-11-03T15:00:00', 'Dr. Vargas', 'Traumatología', 11),
('POLTAC', 43, '2024-11-03T16:00:00', 'Dra. López', 'Psiquiatría', 12),
('POLMDO', 12, '2024-11-03T17:00:00', 'Dr. Castillo', 'Neurología', 13),
('POLSJE', 42, '2024-11-03T18:00:00', 'Dra. Navarro', 'Oftalmología', 14);
GO

---80
INSERT INTO Solicitud (FechaHora, Asistencia, CI_Paciente, NumeroConsulta, NombreUsu) VALUES
('2024-08-03T09:00:00', 1, '56789012', 1, 'Leonardo'),
('2024-08-03T09:30:00', 0, '67890123', 2, 'Margarit'),
('2024-11-01T10:00:00', 1, '18901234', 3, 'Albeto01'),
('2024-08-03T10:30:00',  0, '29012345', 4, 'Abigail1'),
('2024-11-01T11:00:00',  1, '30123456', 5, 'Benjami1'),
('2024-08-03T11:30:00', 0, '41234567', 6, 'Danielle'),
('2024-11-01T12:00:00', 1, '52341234', 7, 'Eleonora'),
('2024-08-03T12:30:00',  0, '63452345', 8, 'Ferdinan'),
('2024-11-01T13:00:00',  1, '14563456', 9, 'Gabriela'),
('2024-11-01T13:30:00',  0, '25674567', 10, 'Isabella'),
('2024-11-02T09:00:00',  1, '36785678', 11, 'Jonathan'),
('2024-11-02T09:30:00',  0, '47896789', 12, 'Kimberly'),
('2024-11-02T10:00:00',  1, '58907890', 13, 'Leonardo'),
('2024-11-02T10:30:00',  0, '69018901', 14, 'Margarit'),
('2024-11-02T11:00:00',  1, '10129012', 15, 'Albeto01'),
('2024-11-02T11:30:00', 0, '21230123', 16, 'Abigail1'),
('2024-11-02T12:00:00', 1, '12345678', 17, 'Benjami1'),
('2024-11-02T12:30:00',  0, '23456789', 18, 'Danielle'),
('2024-11-02T13:00:00', 1, '34567890', 19, 'Eleonora'),
('2024-11-02T13:30:00',  0, '45678901', 20, 'Ferdinan'),
('2024-11-03T09:00:00',  1, '56789012', 1, 'Gabriela'),
('2024-11-03T09:30:00', 0, '67890123', 2, 'Isabella'),
('2024-11-03T10:00:00',1, '18901234', 3, 'Jonathan'),
('2024-11-03T10:30:00', 0, '29012345', 4, 'Kimberly'),
('2024-11-03T11:00:00', 1, '30123456', 5, 'Leonardo'),
('2024-11-03T11:30:00',  0, '41234567', 6, 'Margarit'),
('2024-11-03T12:00:00', 1, '52341234', 7, 'Albeto01'),
('2024-11-03T12:30:00', 0, '63452345', 8, 'Abigail1'),
('2024-11-03T13:00:00', 1, '14563456', 9, 'Benjami1'),
('2024-11-03T13:30:00',  0, '25674567', 10, 'Danielle'),
('2024-11-04T09:00:00',  1, '36785678', 11, 'Eleonora'),
('2024-11-04T09:30:00', 0, '47896789', 12, 'Ferdinan'),
('2024-11-04T10:00:00',  1, '58907890', 13, 'Gabriela'),
('2024-11-04T10:30:00', 0, '69018901', 14, 'Isabella'),
('2024-11-04T11:00:00',  1, '10129012', 15, 'Jonathan'),
('2024-11-04T11:30:00',  0, '21230123', 16, 'Kimberly'),
('2024-11-04T12:00:00',  1, '12345678', 17, 'Leonardo'),
('2024-11-04T12:30:00',  0, '23456789', 18, 'Margarit'),
('2024-11-04T13:00:00',  1, '34567890', 19, 'Albeto01'),
('2024-11-04T13:30:00',  0, '45678901', 20, 'Abigail1'),

('2024-11-05T09:00:00', 1, '56789012', 1, 'Benjami1'),
('2024-11-05T09:30:00', 0, '67890123', 2, 'Danielle'),
('2024-11-05T10:00:00', 1, '18901234', 3, 'Eleonora'),
('2024-11-05T10:30:00', 0, '29012345', 4, 'Ferdinan'),
('2024-11-05T11:00:00', 1, '30123456', 5, 'Gabriela'),
('2024-11-05T11:30:00', 0, '41234567', 6, 'Isabella'),
('2024-11-05T12:00:00', 1, '52341234', 7, 'Jonathan'),
('2024-11-05T12:30:00', 0, '63452345', 8, 'Kimberly'),
('2024-11-05T13:00:00', 1, '14563456', 9, 'Leonardo'),
('2024-11-05T13:30:00', 0, '25674567', 10, 'Margarit'),
('2024-11-06T09:00:00', 1, '36785678', 11, 'Albeto01'),
('2024-11-06T09:30:00', 0, '47896789', 12, 'Abigail1'),
('2024-11-06T10:00:00', 1, '58907890', 13, 'Benjami1'),
('2024-11-06T10:30:00', 0, '69018901', 14, 'Danielle'),
('2024-11-06T11:00:00', 1, '10129012', 15, 'Eleonora'),
('2024-11-06T11:30:00', 0, '21230123', 16, 'Ferdinan'),
('2024-11-06T12:00:00', 1, '12345678', 17, 'Gabriela'),
('2024-11-06T12:30:00', 0, '23456789', 18, 'Isabella'),
('2024-11-06T13:00:00', 1, '34567890', 19, 'Jonathan'),
('2024-11-06T13:30:00', 0, '45678901', 20, 'Kimberly'),
('2024-11-07T09:00:00', 1, '56789012', 1, 'Leonardo'),
('2024-11-07T09:30:00', 0, '67890123', 2, 'Margarit'),
('2024-11-07T10:00:00', 1, '18901234', 3, 'Albeto01'),
('2024-11-07T10:30:00', 0, '29012345', 4, 'Abigail1'),
('2024-11-07T11:00:00', 1, '30123456', 5, 'Benjami1'),
('2024-11-07T11:30:00', 0, '41234567', 6, 'Danielle'),
('2024-11-07T12:00:00',  1, '52341234', 7, 'Eleonora'),
('2024-11-07T12:30:00',  0, '63452345', 8, 'Ferdinan'),
('2024-11-07T13:00:00',1, '14563456', 9, 'Gabriela'),
('2024-11-07T13:30:00', 0, '25674567', 10, 'Isabella'),
('2024-11-08T09:00:00', 1, '36785678', 11, 'Jonathan'),
('2024-11-08T09:30:00', 0, '47896789', 12, 'Kimberly'),
('2024-11-08T10:00:00', 1, '58907890', 13, 'Leonardo'),
('2024-11-08T10:30:00', 0, '69018901', 14, 'Margarit'),
('2024-11-08T11:00:00', 1, '10129012', 15, 'Albeto01'),
('2024-11-08T11:30:00', 0, '21230123', 16, 'Abigail1'),
('2024-11-08T12:00:00',  1, '12345678', 17, 'Benjami1'),
('2024-11-08T12:30:00',  0, '23456789', 18, 'Danielle'),
('2024-11-08T13:00:00', 1, '34567890', 19, 'Eleonora'),
('2024-11-08T13:30:00', 0, '45678901', 20, 'Ferdinan');
GO



--------------------Procedimiento----------------------



------------EMpleado-----------------------

CREATE PROCEDURE AltaEmpleado 
@NomUsu Varchar (8),
@PassUsu Varchar(6)
AS
BEGIN
	IF(EXISTS (SELECT * From Empleado WHERE NombreUsu = @NomUsu))
		RETURN -1
		
		
		Insert Empleado (NombreUsu, PassUsu) 
		Values(@NomUsu, @PassUsu);
		
		If @@ERROR = 0
			return 2
END
GO


CREATE PROCEDURE LogueoEmpleado 
		@NomUsu Varchar (8),
		@PassUsu Varchar(6)
		AS
		BEGIN
		
		SELECT * FROM Empleado
		WHERE NombreUsu = @NomUsu AND PassUsu = @PassUsu

END
GO

CREATE PROCEDURE BuscarEmpleado
		@NomUsu Varchar (8)
		AS
			BEGIN
			
			SELECT *
			FROM Empleado 
			WHERE NombreUsu = @NomUsu

END
GO



------------Policlinicaa---------------------


CREATE PROCEDURE AltaPoliclinica 
@Codigo VARCHAR (6),
@Nombre VARCHAR (50),
@Direccion VARCHAR (100)
AS
BEGIN

IF (EXISTS(SELECT * FROM Policlinica WHERE Codigo = @Codigo))

RETURN -1

Insert Policlinica (Codigo, Nombre, Direccion)
Values (@Codigo, @Nombre, @Direccion);

IF @@ERROR = 0
			RETURN 1
		ELSE
			RETURN -2


END
GO



CREATE PROCEDURE BuscarPoliclinica
    @Codigo VARCHAR(6)
AS
BEGIN
   
    SELECT * 
    FROM Policlinica
    WHERE Codigo = @Codigo;
END
GO

CREATE PROCEDURE ListarPoliclinica
AS
BEGIN

SELECT * From Policlinica

END
GO	



---------- Consultorio (Baja Logica)----------


CREATE PROCEDURE AltaConsultorio

    @NumeroConsultorio INT,
    @CodigoPol VARCHAR(6),
    @Descripcion VARCHAR(100)
    
    AS 
    BEGIN
    
    ---Primero consulto si la policlinica existe
    IF NOT (EXISTS (SELECT * FROM Policlinica WHERE Codigo = @CodigoPol))
  
    RETURN -1
    
    ---Consulto si  el consultorio existe o esta activo
    IF (EXISTS (SELECT * FROM Consultorio WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodigoPol AND ActivoC = 1))
    BEGIN
	 RETURN -2
    END
    
    IF (EXISTS (SELECT * FROM Consultorio WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodigoPol AND ActivoC = 0))
    
    BEGIN
		UPDATE Consultorio
		SET    Descripcion = @Descripcion,ActivoC = 1
		WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol=@CodigoPol
		RETURN 1
    
    END
    
    ---Caso contrario le doy el ALTA
    Insert Consultorio(NumeroConsultorio, CodigoPol, Descripcion)
    Values (@NumeroConsultorio, @CodigoPol, @Descripcion)
    
    END
    GO
  
   
CREATE PROCEDURE BajaConsultorio
    @NumeroConsultorio INT,
    @CodPol VARCHAR(6)
AS
BEGIN
   
    IF NOT EXISTS (SELECT 1 FROM Consultorio WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodPol)
    BEGIN
        RETURN -2 
    END

    -- Verificar si hay consultas asociadas al consultorio
    IF EXISTS (SELECT 1 FROM Consulta WHERE Id_Consultorio = @NumeroConsultorio AND CodigoPol = @CodPol)
    BEGIN
        -- Desactivar el consultorio (baja lógica)
        UPDATE Consultorio
        SET ActivoC = 0
        WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodPol

        IF @@ERROR = 0
        BEGIN
            RETURN 2 
        END
        ELSE
        BEGIN
            RETURN 3 
        END
    END
    ELSE
    BEGIN
        -- Si no hay consultas, realizar baja física
        DELETE FROM Consultorio 
        WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodPol
        
        IF @@ERROR = 0
        BEGIN
            RETURN 1 
        END
        ELSE
        BEGIN
            RETURN 3 
        END
    END
END
GO


CREATE PROCEDURE ModificarConsultorio
    @NumeroConsultorio INT,
    @CodigoPol VARCHAR(6),
    @Descripcion VARCHAR(100)
AS
BEGIN
    -- Verificación de la existencia del consultorio activo con la clave primaria compuesta
    IF NOT EXISTS (SELECT * FROM Consultorio WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodigoPol AND ActivoC = 1)
    BEGIN
        RETURN -2
    END

    -- Modificación del consultorio
    BEGIN
        UPDATE Consultorio
        SET Descripcion = @Descripcion
        WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodigoPol
        
        IF (@@ERROR = 0)
            RETURN 2
        ELSE
            RETURN -3
    END
END
GO


CREATE PROCEDURE ListarConsultorio
AS
BEGIN

	SELECT * FROM Consultorio WHERE ActivoC = 1

END
GO


CREATE PROCEDURE BuscarActivo
@NumeroConsulta INT,
@CodPol VARCHAR(6)
AS
BEGIN
	IF NOT (EXISTS (SELECT * FROM Policlinica WHERE Codigo = @CodPol))
	RETURN -1
	
	SELECT * FROM Consultorio WHERE NumeroConsultorio = @NumeroConsulta AND ActivoC = 1
	
END
GO


CREATE PROCEDURE BuscarConsultorio
    @NumeroConsultorio INT,
    @CodPol VARCHAR(6)
    
AS
BEGIN
 
    
    IF NOT EXISTS (SELECT * FROM Policlinica WHERE Codigo = @CodPol)
    BEGIN
        RETURN -1
    END

    
    SELECT * FROM Consultorio 
    WHERE NumeroConsultorio = @NumeroConsultorio AND CodigoPol = @CodPol
END
GO
 


---------------Paciente (Baja Logica)--------------


CREATE PROCEDURE AltaPaciente
    @CiPaciente VARCHAR(10),
    @Nombre VARCHAR(50),
    @Fecha_Nacimiento DATE
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM Paciente WHERE CiPaciente = @CiPaciente AND ActivoP = 1)
    BEGIN
        RETURN -1
    END

   
    IF EXISTS (SELECT 1 FROM Paciente WHERE CiPaciente = @CiPaciente AND ActivoP = 0)
    BEGIN
        UPDATE Paciente
        SET Nombre = @Nombre, Fecha_Nacimiento = @Fecha_Nacimiento, ActivoP = 1
        WHERE CiPaciente = @CiPaciente

        IF @@ERROR = 0
        BEGIN
            RETURN 1
        END
        ELSE
        BEGIN
            RETURN -2 
        END
    END

   
    INSERT INTO Paciente (CiPaciente, Nombre, Fecha_Nacimiento, ActivoP)
    VALUES (@CiPaciente, @Nombre, @Fecha_Nacimiento, 1)

    IF @@ERROR = 0
    BEGIN
        RETURN 2
    END
    ELSE
    BEGIN
        RETURN -3 
    END
END
GO
 
CREATE PROCEDURE BajaPaciente
    @CiPaciente VARCHAR(10)
AS
BEGIN
    -- Verificar si el paciente existe
    IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CiPaciente = @CiPaciente)
    BEGIN
        RETURN -2; 
    END

    -- Verificar si el paciente tiene solicitudes
    IF EXISTS (SELECT 1 FROM Solicitud WHERE CI_Paciente = @CiPaciente)
    BEGIN
        -- Baja lógica
        UPDATE Paciente
        SET ActivoP = 0
        WHERE CiPaciente = @CiPaciente;

        IF @@ERROR = 0
        BEGIN
            RETURN 2; 
        END
        ELSE
        BEGIN
            RETURN -3; 
        END
    END

    
    BEGIN TRANSACTION;

    -- Eliminar las patologías asociadas al paciente
    DELETE FROM Patologia WHERE CI_Paciente = @CiPaciente;

    IF @@ERROR <> 0
    BEGIN
        ROLLBACK TRANSACTION;
        RETURN -3; 
    END

    -- Eliminar el paciente
    DELETE FROM Paciente 
    WHERE CiPaciente = @CiPaciente;

    IF @@ERROR = 0
    BEGIN
        COMMIT TRANSACTION;
        RETURN 1; 
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        RETURN -3; 
    END
END
GO

CREATE PROCEDURE ModificarPaciente
@CiPaciente VARCHAR(10),
@Nombre VARCHAR(50),
@Fecha_Nacimiento DATE

AS 
BEGIN

IF NOT (EXISTS (SELECT * FROM Paciente WHERE CiPaciente = @CiPaciente AND ActivoP = 1))
		BEGIN
			RETURN -2
		END
		
	ELSE
		BEGIN 
			UPDATE Paciente
			SET  Nombre = @Nombre, Fecha_Nacimiento = @Fecha_Nacimiento WHERE CiPaciente = @CiPaciente
			IF (@@ERROR =0)
				RETURN 2
			ELSE
				RETURN -3
		END

END
GO



CREATE PROCEDURE BuscarPaciente 
@CiPaciente VARCHAR(10)

AS
BEGIN

	SELECT * FROM Paciente WHERE CiPaciente = @CiPaciente
END
GO


CREATE PROCEDURE BuscarPacienteActivo 
@CiPaciente VARCHAR(10)

AS
BEGIN

	SELECT * FROM Paciente WHERE CiPaciente = @CiPaciente AND ActivoP = 1


END
GO

CREATE PROCEDURE ListarPaciente
AS
BEGIN
	SELECT * From Paciente WHERE ActivoP = 1
	
	END
	GO



----------Consulta------
CREATE PROCEDURE AltaConsulta
    @CodPol VARCHAR(6),
    @Id_Consultorio INT,
    @Fecha_Consulta DATETIME,
    @Medico VARCHAR(50),
    @Especialidad VARCHAR(50),
    @CantidadNumeros INT
AS
BEGIN
 
    IF NOT EXISTS (SELECT 1 FROM Consultorio WHERE NumeroConsultorio = @Id_Consultorio and @CodPol = CodigoPol AND ActivoC =1)
    BEGIN
        RETURN -1 
    END

    -- Insertar la nueva consulta
    INSERT INTO Consulta (CodigoPol, Id_Consultorio, Fecha_Consulta, Medico, Especialidad, CantidadNumeros)
    VALUES (@CodPol, @Id_Consultorio, @Fecha_Consulta, @Medico, @Especialidad, @CantidadNumeros)

    IF @@ERROR = 0
    BEGIN
        RETURN 1 
    END
    ELSE
    BEGIN
        RETURN -4 
    END
END
GO
	
	
CREATE PROCEDURE ListarConsulta

AS
BEGIN

SELECT * 
FROM Consulta


ENd
GO




CREATE PROCEDURE BuscarConsulta
@NumeroConsulta INT
AS
BEGIN

SELECT *
FROM Consulta
WHERE NumeroInterno = @NumeroConsulta

END
GO


CREATE PROCEDURE ListarConsultasFuturas

AS
BEGIN

SELECT *
FROM Consulta
WHERE Fecha_Consulta > GETDATE()
ORDER BY Fecha_Consulta ASC

END
GO


------------Solicitud--------------


CREATE PROCEDURE AltaSolicitud
    @CiPaciente VARCHAR(10),
    @NumeroConsulta INT,
    @NombreUsu VARCHAR(8)
AS
BEGIN
    
   
    IF NOT EXISTS (SELECT 1 FROM Paciente WHERE CiPaciente = @CiPaciente AND ActivoP = 1)
    BEGIN
        RETURN -2
    END

    
    IF NOT EXISTS (SELECT 1 FROM Consulta WHERE NumeroInterno = @NumeroConsulta)
    BEGIN
        RETURN -3 
    END

   
    IF NOT EXISTS (SELECT 1 FROM Empleado WHERE NombreUsu = @NombreUsu)
    BEGIN
        RETURN -4 
    END

  
    IF EXISTS (SELECT 1 FROM Consulta WHERE NumeroInterno = @NumeroConsulta AND Fecha_Consulta <= GETDATE())
    BEGIN
        RETURN -5 
    END

    
    IF EXISTS (SELECT 1 FROM Solicitud WHERE CI_Paciente = @CiPaciente AND NumeroConsulta = @NumeroConsulta)
    BEGIN
        RETURN -6 
    END

    
    INSERT INTO Solicitud (CI_Paciente, NumeroConsulta, NombreUsu)
    VALUES (@CiPaciente, @NumeroConsulta, @NombreUsu)

   
    RETURN SCOPE_IDENTITY() 
END
GO


CREATE PROCEDURE LisSolicitudesCompleta

AS
BEGIN

SELECT * FROM Solicitud

END
GO



CREATE PROCEDURE ListSinAsistir
AS
BEGIN
    SELECT *
    FROM Solicitud s
    WHERE s.Asistencia = 0 
      AND s.NumeroConsulta IN (
          SELECT c.NumeroInterno 
          FROM Consulta c 
          WHERE c.Fecha_Consulta >= CONVERT(DATE, GETDATE()) 
           --AND c.Fecha_Consulta < CONVERT(DATE, DATEADD(DAY, 1, GETDATE()))
      )
END
GO







CREATE PROCEDURE ListarPorConsulta

@NumConsulta INT

AS
BEGIN

SELECT * 

FROM Solicitud
WHERE NumeroInterno  = @NumConsulta

ENd
GO

CREATE PROCEDURE MarcarAsistencia
 @NumeroSolicitud INT
AS
BEGIN

    
    IF NOT EXISTS (SELECT 1 FROM Solicitud WHERE NumeroInterno = @NumeroSolicitud)
    BEGIN
        RETURN -1  
    END

    
    BEGIN
        UPDATE Solicitud
        SET Asistencia = 1
        WHERE NumeroInterno = @NumeroSolicitud

        
        IF @@ERROR = 0
        BEGIN
            RETURN 2  
        END
        ELSE
        BEGIN
            RETURN -2  
        END
    END

END
GO



------------Patologia---------------------

CREATE PROCEDURE AltaPatologia
    @CiPaciente VARCHAR(10),
    @Patologia VARCHAR(100)
AS
BEGIN
    
    IF NOT EXISTS (SELECT * FROM Paciente WHERE CiPaciente = @CiPaciente)
   
        RETURN -1;  
  

    
    IF EXISTS (SELECT * FROM Patologia WHERE CI_Paciente = @CiPaciente AND Patologia = @Patologia)
   
        RETURN -2;  
   

    -- Intentar insertar la patología
    INSERT INTO Patologia (CI_Paciente, Patologia)
    VALUES (@CiPaciente, @Patologia);

    If @@ERROR = 0
			RETURN 1
		ELSE
			RETURN -2 
END
GO




CREATE PROCEDURE BajaPatologia
    @CiPaciente VARCHAR(10)
AS
BEGIN
    DELETE FROM Patologia WHERE CI_Paciente = @CiPaciente
END
GO

CREATE PROCEDURE ListadoDePacientePorPatoligia
@CiPaciente VARCHAR(10)

AS
BEGIN

SELECT * 
FROM Patologia
WHERE CI_Paciente =@CiPaciente

END
GO


