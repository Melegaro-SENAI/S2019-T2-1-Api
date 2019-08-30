CREATE DATABASE T_Ekips;

USE T_Ekips;
-- DDL
CREATE TABLE Usuarios
(
	IdUsuario	INT PRIMARY KEY IDENTITY
	,Email		VARCHAR (255) UNIQUE NOT NULL
	,Senha		VARCHAR (250) NOT NULL
	,Permissão	VARCHAR (200) NOT NULL
)

CREATE TABLE Departamentos
(
	IdDepartamento	INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR (250) NOT NULL
)

CREATE TABLE Cargos
(
	IdCargo			INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR (250) NOT NULL
	,Ativo			BIT NOT NULL DEFAULT (1)
)

CREATE TABLE Funcionarios
(
	IdFuncionario	INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR (250) NOT NULL
	,DataNascimento	DATE
	,CPF			VARCHAR (300) NOT NULL
	,Salario		INT
	,IdDepartamento	INT FOREIGN KEY REFERENCES Departamentos (IdDepartamento)
	,IdCargo		INT FOREIGN KEY REFERENCES Cargos (IdCargo)
	,IdUsuario		INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
)

-- DML

USE T_Ekips

INSERT INTO Usuarios (Email, Senha, Permissão) VALUES ('Manoel@gmail.com','123456','ADMINISTRADOR');

INSERT INTO Usuarios (Email, Senha, Permissão) VALUES ('Guilherme@gmail.com','654321','COMUM');

INSERT INTO Departamentos (Nome) VALUES ('Jurídico')

INSERT INTO Departamentos (Nome) VALUES ('Tecnologia')

INSERT INTO Cargos (Nome, Ativo) VALUES ('Advogado Trabalhista','1')

INSERT INTO Cargos (Nome, Ativo) VALUES ('Product Owner ','1')

INSERT INTO Funcionarios (Nome, DataNascimento, CPF, Salario, IdDepartamento, IdCargo, IdUsuario) VALUES ('Bob','25/02/1982','42343278732','1500',1,1,1)

INSERT INTO Funcionarios (Nome, DataNascimento, CPF, Salario, IdDepartamento, IdCargo, IdUsuario) VALUES ('Fernando','12/07/1997','53457576742','1000',2,2,2)

-- DQL 

SELECT * FROM Usuarios
SELECT * FROM Departamentos
SELECT * FROM Cargos
SELECT * FROM Funcionarios