CREATE TABLE Pessoas (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50),
	Sobrenome VARCHAR(100),
	Idade INT,
	Genero VARCHAR(10),
	Endereco VARCHAR(200),
    Email VARCHAR(100),
);