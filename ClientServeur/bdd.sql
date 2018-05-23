CREATE TABLE IF NOT EXISTS etudiant (
  idEtudiant int(11) NOT NULL AUTO_INCREMENT,
  nom varchar(20) NOT NULL,
  prenom varchar(20) NOT NULL,
  adressePostal varchar(100) NOT NULL,
  groupe int(11) NOT NULL,
  PRIMARY KEY (idEtudiant)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS professeur (
  idProfesseur int(11) NOT NULL AUTO_INCREMENT,
  nom varchar(20) NOT NULL,
  prenom varchar(20) NOT NULL,
  adressePostal varchar(100) NOT NULL,
  PRIMARY KEY (idProfesseur)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS activite (
  idActivite int(11) NOT NULL AUTO_INCREMENT,
  type varchar(20) NOT NULL,
  matiere varchar(20) NOT NULL,
  idProfesseur int(11) NOT NULL,
  idSalle int(11) NOT NULL,
  PRIMARY KEY (idActivite),
  FOREIGN KEY (idProfesseur, idSalle)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS salle (
  idSalle int(11) NOT NULL AUTO_INCREMENT,
  numero int(11) NOT NULL,
  type varchar(20) NOT NULL,
  PRIMARY KEY (idSalle)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS suivre (
  idSuivre int(11) NOT NULL AUTO_INCREMENT,
  statut varchar(20) NOT NULL,
  note float,
  date date NOT NULL,
  appreciation text,
  idEtudiant int(11) NOT NULL,
  idActivite int(11) NOT NULL,
  PRIMARY KEY (idSuivre),
  FOREIGN KEY (idEtudiant, idActivite)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS information (
  idInformation int(11) NOT NULL AUTO_INCREMENT,
  valeur text NOT NULL,
  idType int(11) NOT NULL,
  idEtudiant int(11),
  idProfesseur int(11),
  PRIMARY KEY (idInformation),
  FOREIGN KEY (idType, idEtudiant, idProfesseur)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS type (
  idType int(11) NOT NULL AUTO_INCREMENT,
  nom  varchar(100) NOT NULL,
  PRIMARY KEY (idType)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
