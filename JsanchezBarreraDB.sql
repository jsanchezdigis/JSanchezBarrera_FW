CREATE DATABASE JSanchezBarrera
USE JSanchezBarrera
GO

CREATE TABLE Alumno(
	IdAlumno INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50),
	ApellidoMaterno VARCHAR(50)
)
GO

CREATE TABLE Profesor(
	IdProfesor INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50)
)
GO

CREATE TABLE Materia(
	IdMateria INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	Creditos VARCHAR(3)
)
GO

CREATE TABLE Calificaciones(
	IdCalificaciones INT IDENTITY(1,1) PRIMARY KEY,
	Calificacion VARCHAR(4),
	IdMateria INT,
	IdAlumno INT,
	IdProfesor INT,
	CONSTRAINT fk_Calificaciones_Materia FOREIGN KEY (IdMateria) REFERENCES Materia(IdMateria),
	CONSTRAINT fk_Calificaciones_Alumno FOREIGN KEY (IdAlumno) REFERENCES Alumno(IdAlumno),
	CONSTRAINT fk_Calificaciones_Profesor FOREIGN KEY (IdProfesor) REFERENCES Profesor(IdProfesor)
)
GO

CREATE TABLE Grupo(
	IdGrupo INT IDENTITY(1,1) PRIMARY KEY,
	IdMateria INT,
	IdProfesor INT,
	IdAlumno INT,
	CONSTRAINT fk_Grupo_Materia FOREIGN KEY (IdMateria) REFERENCES Materia(IdMateria),
	CONSTRAINT fk_Grupo_Profesor FOREIGN KEY (IdProfesor) REFERENCES Profesor(IdProfesor),
	CONSTRAINT fk_Grupo_Alumno FOREIGN KEY (IdAlumno) REFERENCES Alumno(IdAlumno)
)
GO

------------------ALUMNO-----------------
CREATE PROCEDURE AlumnoAdd --'Jose','Sanchez','Xihuitl'
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
INSERT INTO Alumno(Nombre,ApellidoPaterno,ApellidoMaterno)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno)
GO

CREATE PROCEDURE AlumnoUpdate
@IdAlumno INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
UPDATE Alumno SET
Nombre = @Nombre,
ApellidoPaterno = @ApellidoPaterno,
ApellidoMaterno = @ApellidoMaterno
WHERE IdAlumno = @IdAlumno
GO

CREATE PROCEDURE AlumnoDelete
@IdAlumno INT
AS
DELETE FROM Alumno WHERE IdAlumno = @IdAlumno
GO

CREATE PROCEDURE AlumnoGetAll
AS
SELECT IdAlumno,Nombre,ApellidoPaterno,ApellidoMaterno FROM Alumno
GO

CREATE PROCEDURE AlumnoGetById
@IdAlumno INT
AS
SELECT IdAlumno,Nombre,ApellidoPaterno,ApellidoMaterno FROM Alumno
WHERE IdAlumno = @IdAlumno
GO
 ----------------PROFESOR------------------------
CREATE PROCEDURE ProfesorAdd --'Alexis','Mendez'
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50)
AS
INSERT INTO Profesor(Nombre,ApellidoPaterno)VALUES(@Nombre,@ApellidoPaterno)
GO

CREATE PROCEDURE ProfesorUpdate
@IdProfesor INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50)
AS
UPDATE Profesor SET
Nombre = @Nombre,
ApellidoPaterno = @ApellidoPaterno
WHERE IdProfesor = @IdProfesor
GO

CREATE PROCEDURE ProfesorDelete
@IdProfesor INT
AS
DELETE FROM Profesor WHERE IdProfesor = @IdProfesor
GO

CREATE PROCEDURE ProfesorGetAll
AS
SELECT IdProfesor,Nombre,ApellidoPaterno FROM Profesor
GO

CREATE PROCEDURE ProfesorGetById
@IdProfesor INT
AS
SELECT IdProfesor,Nombre,ApellidoPaterno FROM Profesor
WHERE IdProfesor = @IdProfesor
GO

 ---------------------MATERIA----------------------
CREATE PROCEDURE MateriaAdd --'Calculo','50'
@Nombre VARCHAR(50),
@Creditos VARCHAR(3)
AS
INSERT INTO Materia(Nombre,Creditos)VALUES(@Nombre,@Creditos)
GO

CREATE PROCEDURE MateriaUpdate
@IdMateria INT,
@Nombre VARCHAR(50),
@Creditos VARCHAR(3)
AS
UPDATE Materia SET
Nombre = @Nombre,
Creditos = @Creditos
WHERE IdMateria = @IdMateria
GO

CREATE PROCEDURE MateriaDelete
@IdMateria INT
AS
DELETE FROM Materia WHERE IdMateria = @IdMateria
GO

CREATE PROCEDURE MateriaGetAll
AS
SELECT IdMateria,Nombre,Creditos FROM Materia
GO

CREATE PROCEDURE MateriaGetById
@IdMateria INT
AS
SELECT IdMateria,Nombre,Creditos FROM Materia
WHERE IdMateria = @IdMateria
GO

---------------CALIFICACIONES----------------

CREATE PROCEDURE CalificacionesProfesor --'80',1,1,1
@Calificacion VARCHAR(4),
@IdMateria INT,
@IdAlumno INT,
@IdProfesor INT
AS
INSERT INTO Calificaciones(Calificacion,IdMateria,IdAlumno,IdProfesor)VALUES(@Calificacion,@IdMateria,@IdAlumno,@IdProfesor)
GO

CREATE PROCEDURE CalificacionesProfesorUpdate --1,'90',1,1
@IdCalificaciones INT,
@Calificacion VARCHAR(4),
@IdMateria INT,
@IdProfesor INT
AS
UPDATE Calificaciones SET
Calificacion = @Calificacion,
IdMateria = @IdMateria,
IdProfesor = @IdProfesor
WHERE IdCalificaciones = @IdCalificaciones
GO

CREATE PROCEDURE MateriasAlumno --1
@IdAlumno INT
AS
SELECT IdCalificaciones,Calificacion,Materia.IdMateria,Materia.Nombre AS MateriaNom,Alumno.IdAlumno,Alumno.Nombre AS AlumnoNom,Alumno.ApellidoPaterno,Alumno.ApellidoMaterno,IdProfesor FROM Calificaciones
INNER JOIN Materia ON Calificaciones.IdMateria = Materia.IdMateria
INNER JOIN Alumno ON Calificaciones.IdAlumno = Alumno.IdAlumno
WHERE Alumno.IdAlumno = @IdAlumno
GO

CREATE PROCEDURE MateriasAlumnoGetById 1
@IdCalificaciones INT
AS
SELECT IdCalificaciones,Calificacion,Materia.IdMateria,Materia.Nombre AS MateriaNom,Alumno.IdAlumno,Alumno.Nombre AS AlumnoNom,Alumno.ApellidoPaterno,Alumno.ApellidoMaterno,IdProfesor FROM Calificaciones
INNER JOIN Materia ON Calificaciones.IdMateria = Materia.IdMateria
INNER JOIN Alumno ON Calificaciones.IdAlumno = Alumno.IdAlumno
WHERE IdCalificaciones = @IdCalificaciones
GO

CREATE PROCEDURE CalificacionesProfesorDelete
@IdCalificaciones INT
AS
DELETE FROM Calificaciones WHERE IdCalificaciones = @IdCalificaciones
GO