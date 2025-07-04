CREATE DATABASE dbChamado

ON PRIMARY 
(
NAME = dbChamado,
FILENAME = 'C:\BD\dbChamado.MDF',
SIZE = 15MB,
MAXSIZE = 45MB,
FILEGROWTH = 10%
);

GO
USE dbChamado;
GO



CREATE TABLE tblCliente
(
    idCliente INT PRIMARY KEY NOT NULL IDENTITY(10,1),
	Nome VARCHAR(80) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Endereco VARCHAR(200) NOT NULL,
	Telefone VARCHAR(16) NOT NULL,
	CNPJ  VARCHAR(20) NOT NULL
);

CREATE TABLE tblUsuario
(
    idUsuario INT PRIMARY KEY NOT NULL IDENTITY(100,1),
	Nome VARCHAR(80) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL
		);

CREATE TABLE tblChamado
(
	idChamado INT PRIMARY KEY NOT NULL IDENTITY(50,1),
	Nome VARCHAR(50) NOT NULL,
	Dt DATE NOT NULL DEFAULT GETDATE(),
	Descricao VARCHAR(200) NOT NULL,
	Stts  VARCHAR(30) NOT NULL,
	Prioridade VARCHAR(10) NOT NULL,
	Avaliacao FLOAT,
	idUsuario INT NOT NULL,
    idCliente INT NOT NULL,
	CONSTRAINT fk_Chamado_Usuario FOREIGN KEY (idUsuario) REFERENCES tblUsuario(idUsuario),
    CONSTRAINT fk_Chamado_Cliente FOREIGN KEY (idCliente) REFERENCES tblCliente(idCliente)
);


INSERT INTO tblCliente (Nome, Email, Endereco, Telefone, CNPJ)
VALUES
('Empresa XPTO', 'contato@xpto.com', 'Rua das Flores, 123', '(11) 99999-0001', '12.345.678/0001-90'),
('Tecnologia SA', 'suporte@tecnologia.com',  'Av. Central, 456', '(11) 98888-0002', '23.456.789/0001-01'),
('Comercial ABC', 'vendas@abc.com',  'Rua dos Andradas, 789', '(11) 97777-0003', '34.567.890/0001-12'),
('Construtora Sol', 'contato@sol.com', 'Rua Azul, 321', '(11) 97666-0004', '45.678.901/0001-23'),
('InfoTech', 'info@infotech.com',  'Av. Brasil, 987', '(11) 96555-0005', '56.789.012/0001-34'),
('Global Systems', 'contato@globalsystems.com',  'Rua Verde, 654', '(11) 95444-0006', '67.890.123/0001-45');


INSERT INTO tblUsuario (Nome, Email, Senha)
VALUES
('Fernanda Rocha', 'fernanda.rocha@email.com', 'minhaSenha!'),
('João Pedro', 'joao.pedro@email.com', 'securePass1'),
('Mariana Silva', 'mariana.silva@email.com', 'senhaSegura2025'),
('Admin', 'mariana.silvad@email.com', 'Admin'),
('A', 'mariana.silvad@email.com', 'A');


INSERT INTO tblChamado (Nome, Dt, Descricao, Stts, Prioridade, Avaliacao, idUsuario, idCliente)
VALUES 
('João Silva', '2025-05-01', 'Erro ao abrir o sistema', 'Aberto', 'Alta', 3, 100, 10),  
('Maria Souza', '2025-05-02', 'Sistema lento', 'Em andamento', 'Média', 2, 101, 11),  
('Carlos Lima', '2025-05-03', 'Não consigo acessar', 'Fechado', 'Alta', 5, 102, 12),  
('Ana Paula', '2025-05-04', 'Impressora não funciona', 'Aberto', 'Baixa', NULL, 103, 13), 
('José Oliveira', '2025-05-05', 'Tela trava ao logar', 'Em andamento', 'Alta', NULL, 104, 14);
