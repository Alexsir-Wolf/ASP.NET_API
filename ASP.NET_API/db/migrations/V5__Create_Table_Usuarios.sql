CREATE TABLE Usuarios (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    NomeUsuario VARCHAR(50),
	Senha VARCHAR(130),
	NomeCompleto VARCHAR(200),
	RefreshToken VARCHAR(500),
	RefreshTokenExpiracao DATETIME,
);