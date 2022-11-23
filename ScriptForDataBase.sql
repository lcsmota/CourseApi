CREATE DATABASE CourseApiDapper

Use CourseApiDapper

CREATE TABLE Courses(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Nome VARCHAR(80) NOT NULL,
    Categoria VARCHAR(30) NOT NULL,
    OferecidoPor VARCHAR(20) NOT NULL,
    Descricao VARCHAR(255) NOT NULL,
    Turno VARCHAR(10) NOT NULL,
    CargaHoraria SMALLINT NOT NULL,
    Observacao VARCHAR(40),
    EOnline BIT NOT NULL
);

CREATE TABLE Students(
    RA INT PRIMARY KEY IDENTITY NOT NULL,
    Nome VARCHAR(80) NOT NULL,
    Idade SMALLINT NOT NULL,
    Endereco VARCHAR(120) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    CursoId INT NOT NULL,

    CONSTRAINT [FK_Students_Course] FOREIGN KEY(CursoId)
        REFERENCES Courses([Id])
);


