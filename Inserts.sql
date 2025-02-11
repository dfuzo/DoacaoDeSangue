INSERT INTO Endereco (CEP, Quadra, Bloco, Numero, Complemento, Cidade, Estado) VALUES
('12345000', 'A', '1', '10', 'Casa', 'São Paulo', 'SP'),
('23456000', 'B', '2', '20', 'Apto 202', 'Rio de Janeiro', 'RJ'),
('34567000', 'C', '3', '30', 'Sala 303', 'Belo Horizonte', 'MG'),
('45678000', 'D', '4', '40', 'Prédio', 'Porto Alegre', 'RS'),
('56789000', 'E', '5', '50', 'Sobrado', 'Curitiba', 'PR');

INSERT INTO Tipo_Sanguineo (Tipo, Fator_Rh) VALUES
('A', '+'),
('A', '-'),
('B', '+'),
('B', '-'),
('AB', '+'),
('AB', '-'),
('O', '+'),
('O', '-');

INSERT INTO Hemocentro (CNPJ, Nome, Id_Endereco, Telefone, Email) VALUES
('12345678000101', 'Hemocentro Central', 1, '1123456789', 'central@hemocentro.com'),
('22345678000102', 'Hemocentro Norte', 2, '2123456789', 'norte@hemocentro.com'),
('32345678000103', 'Hemocentro Sul', 3, '3123456789', 'sul@hemocentro.com'),
('42345678000104', 'Hemocentro Leste', 4, '4123456789', 'leste@hemocentro.com'),
('52345678000105', 'Hemocentro Oeste', 5, '5123456789', 'oeste@hemocentro.com');

INSERT INTO Doadores (Cpf, Nome, Data_Nascimento, Sexo, Peso, Telefone, Email, Id_Tipo_Sanguineo, Id_Endereco) VALUES
('12345678901', 'Joao Silva', '1990-05-15', 'Masculino', 75.5, '11999999999', 'joao.silva@gmail.com', 1, 1),
('23456789012', 'Maria Oliveira', '1985-08-20', 'Feminino', 62.3, '21988888888', 'maria.oliveira@gmail.com', 2, 2),
('34567890123', 'Pedro Santos', '1992-12-10', 'Masculino', 80.0, '31977777777', 'pedro.santos@gmail.com', 3, 3),
('45678901234', 'Ana Costa', '1998-03-25', 'Feminino', 58.7, '41966666666', 'ana.costa@gmail.com', 4, 4),
('56789012345', 'Lucas Lima', '1987-07-18', 'Masculino', 72.4, '51955555555', 'lucas.lima@gmail.com', 5, 5);

INSERT INTO Receptores (Cpf, Nome, Data_Nascimento, Sexo, Peso, Telefone, Email, Id_Tipo_Sanguineo, Id_Endereco) VALUES
('67890123456', 'Clara Nunes', '1983-04-12', 'Feminino', 65.0, '61944444444', 'clara.nunes@gmail.com', 1, 1),
('78901234567', 'Carlos Souza', '1975-10-30', 'Masculino', 85.3, '71933333333', 'carlos.souza@gmail.com', 2, 2),
('89012345678', 'Fernanda Melo', '1995-01-15', 'Feminino', 70.2, '81922222222', 'fernanda.melo@gmail.com', 3, 3),
('90123456789', 'Rafael Almeida', '1991-09-22', 'Masculino', 78.6, '91911111111', 'rafael.almeida@gmail.com', 4, 4),
('01234567890', 'Juliana Ferreira', '1989-06-05', 'Feminino', 60.1, '10199999999', 'juliana.ferreira@gmail.com', 5, 5);

INSERT INTO Funcionario (Ponto, Nome, Sexo, Telefone, Email, Cargo, Hemocentro) VALUES
('101', 'Carlos Silva', 'Masculino', '11999990001', 'carlos.silva@gmail.com', 'Médico', '12345678000101'),
('102', 'Fernanda Souza', 'Feminino', '21999990002', 'fernanda.souza@gmail.com', 'Coletador', '22345678000102'),
('103', 'João Oliveira', 'Masculino', '31999990003', 'joao.oliveira@gmail.com', 'Coletador', '32345678000103'),
('104', 'Ana Lima', 'Feminino', '41999990004', 'ana.lima@gmail.com', 'Médico', '42345678000104'),
('105', 'Roberto Nunes', 'Masculino', '51999990005', 'roberto.nunes@gmail.com', 'Técnico', '52345678000105'),
('201', 'Patrícia Mendes', 'Feminino', '61999990006', 'patricia.mendes@gmail.com', 'Enfermeiro', '12345678000101'),
('202', 'Gustavo Ramos', 'Masculino', '71999990007', 'gustavo.ramos@gmail.com', 'Enfermeiro', '22345678000102'),
('203', 'Beatriz Fernandes', 'Feminino', '81999990008', 'beatriz.fernandes@gmail.com', 'Enfermeiro', '32345678000103'),
('204', 'Eduardo Martins', 'Masculino', '91999990009', 'eduardo.martins@gmail.com', 'Supervisor', '42345678000104'),
('205', 'Mariana Rocha', 'Feminino', '10199990010', 'mariana.rocha@gmail.com', 'Supervisor', '52345678000105');

INSERT INTO Coleta (Cpf_Doador, Ponto_Funcionario, Data_Coleta, Data_Validade, Volume, Id_Hemocentro, Id_Tipo_Sanguineo) VALUES
('12345678901', 101, '2025-01-15', '2025-02-15', 450, '12345678000101', 1),
('23456789012', 102, '2025-01-16', '2025-02-16', 500, '22345678000102', 2),
('34567890123', 103, '2025-01-17', '2025-02-17', 470, '32345678000103', 3),
('45678901234', 104, '2025-01-18', '2025-02-18', 480, '42345678000104', 4),
('56789012345', 105, '2025-01-19', '2025-02-19', 490, '52345678000105', 5);

INSERT INTO Transfusao (Id_Coleta, Cpf_Receptor, Ponto_Funcionario, Data_Transfusao, Volume, Id_Hemocentro, Id_Tipo_Sanguineo, Comprovante) VALUES
(1, '67890123456', 201, '2025-01-20', 450, '12345678000101', 1, NULL),
(2, '78901234567', 202, '2025-01-21', 500, '22345678000102', 2, NULL),
(3, '89012345678', 203, '2025-01-22', 470, '32345678000103', 3, NULL),
(4, '90123456789', 204, '2025-01-23', 480, '42345678000104', 4, NULL),
(5, '01234567890', 205, '2025-01-24', 490, '52345678000105', 5, NULL);

INSERT INTO Estoque (Id_Hemocentro, Tipo_Item, Quantidade) VALUES
('12345678000101', 'Sangue O+', 100),
('22345678000102', 'Sangue A-', 80),
('32345678000103', 'Sangue B+', 90),
('42345678000104', 'Sangue AB-', 50),
('52345678000105', 'Sangue O-', 120);

INSERT INTO Doacao (Id_Doador, Data_Doacao, Local_Doacao, Volume_Coletado, Tipo_Sanguineo) VALUES
('12345678901', '2025-01-15', 'Hemocentro Central', 450, 1),
('23456789012', '2025-01-16', 'Hemocentro Norte', 500, 2),
('34567890123', '2025-01-17', 'Hemocentro Sul', 470, 3),
('45678901234', '2025-01-18', 'Hemocentro Leste', 480, 4),
('56789012345', '2025-01-19', 'Hemocentro Oeste', 490, 5);

