-- Inicio DDL
CREATE DATABASE T_People;

USE T_People;

CREATE TABLE Funcionarios
(
	IdFuncionarios	INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(250) NOT NULL 
	,Sobrenome		VARCHAR(250) NOT NULL 
);
-- Fim DDL