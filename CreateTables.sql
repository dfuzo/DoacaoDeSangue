-- Tabela: Endereco
CREATE TABLE Endereco (
    Id_Endereco INT PRIMARY KEY IDENTITY,
    CEP VARCHAR(10) NOT NULL,
    Quadra VARCHAR(50),
    Bloco VARCHAR(50),
    Numero VARCHAR(10),
    Complemento VARCHAR(100),
    Cidade VARCHAR(100) NOT NULL,
    Estado VARCHAR(50) NOT NULL
);

-- Tabela: Tipo Sanguineo
CREATE TABLE Tipo_Sanguineo (
    Id_Tipo_Sanguineo INT PRIMARY KEY IDENTITY,
    Tipo VARCHAR(3) NOT NULL,
    Fator_Rh CHAR(1) NOT NULL
);

-- Tabela: Hemocentro
CREATE TABLE Hemocentro (
    CNPJ VARCHAR(14) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Id_Endereco INT FOREIGN KEY REFERENCES Endereco(Id_Endereco),
    Telefone VARCHAR(15),
    Email VARCHAR(100)
);

-- Tabela: Funcionario
CREATE TABLE Funcionario (
    Ponto VARCHAR(10) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Telefone VARCHAR(15),
    Email VARCHAR(100),
    Cargo VARCHAR(30),
    Hemocentro VARCHAR(14) FOREIGN KEY REFERENCES Hemocentro(CNPJ)
);


-- Tabela: Doador
CREATE TABLE Doador (
    Cpf VARCHAR(11) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Data_Nascimento DATE NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Peso FLOAT NOT NULL,
    Telefone VARCHAR(15),
    Email VARCHAR(100),
    Id_Tipo_Sanguineo INT FOREIGN KEY REFERENCES Tipo_Sanguineo(Id_Tipo_Sanguineo),
    Id_Endereco INT FOREIGN KEY REFERENCES Endereco(Id_Endereco)
);

-- Tabela: Receptor
CREATE TABLE Receptor (
    Cpf VARCHAR(11) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Data_Nascimento DATE NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Peso FLOAT NOT NULL,
    Telefone VARCHAR(15),
    Email VARCHAR(100),
    Id_Tipo_Sanguineo INT FOREIGN KEY REFERENCES Tipo_Sanguineo(Id_Tipo_Sanguineo),
    Id_Endereco INT FOREIGN KEY REFERENCES Endereco(Id_Endereco)
);

-- Tabela: Coleta
CREATE TABLE Coleta (
    Id_Coleta INT PRIMARY KEY IDENTITY,
    Cpf_Doador VARCHAR(11) FOREIGN KEY REFERENCES Doador(Cpf),
    Ponto_Funcionario Ponto VARCHAR(10) FOREIGN KEY REFERENCES Funcionario(Ponto),
    Data_Coleta DATE NOT NULL,
    Data_Validade DATE NOT NULL,
    Volume FLOAT NOT NULL,
    Id_Hemocentro VARCHAR(14) FOREIGN KEY REFERENCES Hemocentro(CNPJ),
    Id_Tipo_Sanguineo INT FOREIGN KEY REFERENCES Tipo_Sanguineo(Id_Tipo_Sanguineo),
);

-- Tabela: Transfusao
CREATE TABLE Transfusao (
    Id_Transfusao INT PRIMARY KEY IDENTITY,
    Id_Coleta INT FOREIGN KEY REFERENCES Coleta(Id_Coleta),
    Cpf_Receptor VARCHAR(11) FOREIGN KEY REFERENCES Receptor(Cpf),
    Ponto_Funcionario Ponto VARCHAR(10) FOREIGN KEY REFERENCES Funcionario(Ponto),
    Data_Transfusao DATE NOT NULL,
    Volume FLOAT NOT NULL,
    Id_Hemocentro VARCHAR(14) FOREIGN KEY REFERENCES Hemocentro(CNPJ),
    Id_Tipo_Sanguineo INT FOREIGN KEY REFERENCES Tipo_Sanguineo(Id_Tipo_Sanguineo),
    Comprovante VARBINARY(MAX)
);


-- Tabela: Estoque
CREATE TABLE Estoque (
    Id_Estoque INT PRIMARY KEY IDENTITY,
    Id_Hemocentro VARCHAR(14) FOREIGN KEY REFERENCES Hemocentro(CNPJ),
    Tipo_Item VARCHAR(50) NOT NULL,
    Quantidade INT NOT NULL
);

-- Tabela: Doacao
CREATE TABLE Doacao (
    Id_Doacao INT PRIMARY KEY IDENTITY,
    Id_Doador VARCHAR(11) FOREIGN KEY REFERENCES Doadores(Cpf),
    Data_Doacao DATE NOT NULL,
    Local_Doacao VARCHAR(100) NOT NULL,
    Volume_Coletado FLOAT NOT NULL,
    Tipo_Sanguineo INT FOREIGN KEY REFERENCES Tipo_Sanguineo(Id_Tipo_Sanguineo)
);


