CREATE DATABASE locacaoimoveis; 

CREATE TABLE endereco (
  id int NOT NULL AUTO_INCREMENT,
  cep int NOT NULL,
  logradouro varchar(100) NOT NULL,
  complemento varchar(100) NOT NULL,
  bairro varchar(100) NOT NULL,
  localidade varchar(100) NOT NULL,
  uf char(2) NOT NULL,
  ibge int NOT NULL,
  gia int DEFAULT NULL,
  ddd int NOT NULL,
  siafi int NOT NULL,
  numero int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB;

CREATE TABLE imobiliaria (
  id int NOT NULL AUTO_INCREMENT,
  razaoSocial varchar(200) NOT NULL,
  nome varchar(200) NOT NULL,
  telefone int NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB;

CREATE TABLE imovel (
  id int NOT NULL AUTO_INCREMENT,
  preco double NOT NULL,
  imobiliaria_id int NOT NULL,
  endereco_id int NOT NULL,
  proprietario_id int NOT NULL,
  PRIMARY KEY (id),
  KEY fk_imovel_imobiliaria_idx (imobiliaria_id),
  KEY fk_imovel_endereco1_idx (endereco_id),
  KEY fk_imovel_proprietario1_idx (proprietario_id)
) ENGINE=InnoDB;

CREATE TABLE proprietario (
  id int NOT NULL AUTO_INCREMENT,
  nome varchar(200) NOT NULL,
  telefone int NOT NULL,
  cpf varchar(11) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB;

ALTER TABLE imovel
  ADD CONSTRAINT fk_imovel_endereco1 FOREIGN KEY (endereco_id) REFERENCES endereco (id),
  ADD CONSTRAINT fk_imovel_imobiliaria FOREIGN KEY (imobiliaria_id) REFERENCES imobiliaria (id),
  ADD CONSTRAINT fk_imovel_proprietario1 FOREIGN KEY (proprietario_id) REFERENCES proprietario (id);
COMMIT;
