Drop database if exists `veloMax`;
Create database if not exists `veloMax`;
Use `veloMax`;

DROP TABLE IF EXISTS Users;
CREATE TABLE IF NOT EXISTS Users (
  userId int AUTO_INCREMENT NOT NULL,
  username varchar(20) NOT NULL,
  user_password varchar(20) NOT NULL,
  user_type ENUM('admin','normal') Not NULL,
  PRIMARY KEY (userId)
);


DROP TABLE IF EXISTS Modele ;
CREATE TABLE IF NOT EXISTS Modele (
	numProduit INT AUTO_INCREMENT NOT NULL,
	nomProduit VARCHAR(20) NOT NULL,
	grandeur enum('Adultes','Jeunes','Hommes','Dames') not null,
	prixUnitaire INT NOT NULL,
	ligneProduit VARCHAR(40),
	dateIntroduction DATE NOT NULL,
	dateDiscontinuation DATE NOT NULL,
	PRIMARY KEY (numProduit)
    );

DROP TABLE IF EXISTS Piece ;
CREATE TABLE IF NOT EXISTS Piece (
	numProduit INT AUTO_INCREMENT NOT NULL,
	descriptionP ENUM('cadre','guidon','freins','selle','derailleurAvant','derailleurArriere','roueAvant','roueArriere','reflecteurs','pedalier','ordinateur','panier') NOT NULL,
	nomFournisseur VARCHAR(20) NOT NULL,
	numProdFournisseur INT NOT NULL,
	prixUnitaire INT NOT NULL,
	dateIntroduction DATE Not NULL,
	dateDiscontinuation DATE Not NULL,
	delaiApprovisionnement INT Not NULL,
	PRIMARY KEY (numProduit));

 DROP TABLE IF EXISTS Assemble ;
 CREATE TABLE IF NOT EXISTS Assemble (
	numProduit_Piece INT NOT NULL,
	numProduit_Modele int NOT NULL,
	PRIMARY KEY (numProduit_Piece,  numProduit_Modele),
	CONSTRAINT FK_numProduit_Assemble_piece FOREIGN KEY (numProduit_Piece) REFERENCES Piece (numProduit) on delete cascade on update no action,
	CONSTRAINT FK_numProduit_Assemble_modele FOREIGN KEY (numProduit_modele) REFERENCES Modele (numProduit) on delete cascade on update no action
    );

DROP TABLE IF EXISTS Fournisseur ;
CREATE TABLE IF NOT EXISTS Fournisseur (
	siret VARCHAR(9) NOT NULL,
	nomEntreprise VARCHAR(40) NOT NULL,
	libelleReactivite ENUM('très bon','bon','moyen','mauvais') NULL,
	PRIMARY KEY (siret));

DROP TABLE IF EXISTS BoutiqueSpecialise ;
CREATE TABLE IF NOT EXISTS BoutiqueSpecialise (
	idBoutique INT AUTO_INCREMENT NOT NULL,
	nomCompagnie VARCHAR(40) NULL,
	adresse VARCHAR(40) NULL,
	telephone VARCHAR(10) NULL,
	courriel VARCHAR(40) NULL,
	nomContact VARCHAR(20) NULL,
	PRIMARY KEY (idBoutique));

DROP TABLE IF EXISTS ProgramFidelite ;
CREATE TABLE IF NOT EXISTS ProgramFidelite (
	numProgramme INT AUTO_INCREMENT NOT NULL,
	descriptionPF VARCHAR(40),
	cout INT NOT NULL,
	duree INT NOT NULL,
	rabais INT NOT NULL,
	PRIMARY KEY (numProgramme));

DROP TABLE IF EXISTS Individu ;
CREATE TABLE IF NOT EXISTS Individu (
	idClient INT AUTO_INCREMENT NOT NULL,
	nom VARCHAR(20) NULL,
	prenom VARCHAR(20) NULL,
	adresse VARCHAR(40) NULL,
	telephone VARCHAR(10) NULL,
	courriel VARCHAR(40) NULL,
	PRIMARY KEY (idClient));

DROP TABLE IF EXISTS Commande ;
CREATE TABLE IF NOT EXISTS Commande (
	numUnique INT AUTO_INCREMENT NOT NULL,
	dateCommande VARCHAR(30) NOT NULL,
	adresseLivraison VARCHAR(40) NULL,
	dateLivraison VARCHAR(30) NOT NULL,
	PRIMARY KEY (numUnique)
    );

DROP TABLE IF EXISTS CommandeCLient ;
CREATE TABLE IF NOT EXISTS CommandeClient (
	numUnique_Commande_C INT NOT NULL,
    idClient_Commande INT NOT NULL,
	PRIMARY KEY (numUnique_Commande_C),
    CONSTRAINT FK_numUnique_Commande_C FOREIGN KEY (numUnique_Commande_C) REFERENCES Commande (numUnique) on delete cascade on update no action,
	CONSTRAINT FK_idClient_Appro FOREIGN KEY (idClient_Commande) REFERENCES Individu (idClient) on delete cascade on update no action
    );
    
DROP TABLE IF EXISTS CommandeBoutique ;
CREATE TABLE IF NOT EXISTS CommandeBoutique (
	numUnique_Commande_B INT NOT NULL,
    idBoutique_Commande INT NOT NULL,
	PRIMARY KEY (numUnique_Commande_B),
    CONSTRAINT FK_numUnique_Commande_B FOREIGN KEY (numUnique_Commande_B) REFERENCES Commande (numUnique) on delete cascade on update no action,
	CONSTRAINT FK_idBoutique_Appro FOREIGN KEY (idBoutique_Commande) REFERENCES BoutiqueSpecialise (idBoutique) on delete cascade on update no action
    );

DROP TABLE IF EXISTS CommanderPiece ;
CREATE TABLE IF NOT EXISTS CommanderPiece (
	numUnique_Commande_P INT NOT NULL,
    numProduit_CommanderPiece INT NOT NULL,
	quantite INT NOT NULL,
	PRIMARY KEY (numUnique_Commande_P,numProduit_CommanderPiece),
	CONSTRAINT FK_numUnique_Commande_P FOREIGN KEY (numUnique_Commande_P) REFERENCES Commande (numUnique) on delete cascade on update no action,
	CONSTRAINT FK_Produit_CommanderPiece FOREIGN KEY (numProduit_CommanderPiece) REFERENCES Piece (numProduit) on delete cascade on update no action
    );

DROP TABLE IF EXISTS CommanderModele ;
CREATE TABLE IF NOT EXISTS CommanderModele (
    numUnique_Commande_M INT NOT NULL,
	numProduit_CommanderModele INT NOT NULL,
	quantite INT NOT NULL,
	PRIMARY KEY (numUnique_Commande_M,numProduit_CommanderModele),
	CONSTRAINT FK_numUnique_Commande_M FOREIGN KEY (numUnique_Commande_M) REFERENCES Commande (numUnique) on delete cascade on update no action,
    CONSTRAINT FK_numProduit_CommanderModele FOREIGN KEY (numProduit_CommanderModele) REFERENCES Modele (numProduit) on delete cascade on update no action
    );

DROP TABLE IF EXISTS Adhere ;
CREATE TABLE IF NOT EXISTS Adhere (
	idClient_Adhere INT NOT NULL,
    numProgramme_Adhere INT NOT NULL,
	dateAdhesion DATE NOT NULL,
	PRIMARY KEY (idClient_Adhere),
	CONSTRAINT FK_idClient FOREIGN KEY (idClient_Adhere) REFERENCES Individu (idClient) on delete cascade on update no action,
	CONSTRAINT FK_numProgramme FOREIGN KEY (numProgramme_Adhere) REFERENCES ProgramFidelite (numProgramme) on delete cascade on update no action
    );
    
DROP TABLE IF EXISTS Approvisionne ;
-- mettre un id auto_incrementant permet de simplifier le select de pièce sinon il aurait fallut combiner tous les attributs en clé primaire
CREATE TABLE IF NOT EXISTS Approvisionne (
	numUniqueAppro INT auto_increment not null,
	siret_Appro VARCHAR(9) NOT NULL,
	numProduit_Appro INT NOT NULL,
	quantite INT NOT NULL,
	dateAchat DATE NOT NULL,
	PRIMARY KEY (numUniqueAppro),
	CONSTRAINT FK_siret FOREIGN KEY (siret_Appro) REFERENCES Fournisseur (siret) on delete cascade on update no action,
	CONSTRAINT FK_numProduit FOREIGN KEY (numProduit_Appro) REFERENCES Piece (numProduit) on delete cascade on update no action
    );
    
DROP TABLE IF EXISTS ApprovisionneModele ;
-- mettre un id auto_incrementant permet de simplifier le select de pièce sinon il aurait fallut combiner tous les attributs en clé primaire
CREATE TABLE IF NOT EXISTS ApprovisionneModele (
	numUniqueAppro INT auto_increment not null,
	siret_Appro_M VARCHAR(9) NOT NULL,
	numProduit_Appro_M INT NOT NULL,
	quantite INT NOT NULL,
	dateAchat DATE NOT NULL,
	PRIMARY KEY (numUniqueAppro),
	CONSTRAINT FK_siret_M FOREIGN KEY (siret_Appro_M) REFERENCES Fournisseur (siret) on delete cascade on update no action,
	CONSTRAINT FK_numProduit_M FOREIGN KEY (numProduit_Appro_M) REFERENCES Modele (numProduit) on delete cascade on update no action
    );

INSERT INTO `veloMax`.`Users` (`username`,`user_password`,`user_type`) VALUES ('admin','admin','admin');
INSERT INTO `veloMax`.`Users` (`username`,`user_password`,`user_type`) VALUES ('tibo','tibo','normal');
INSERT INTO `veloMax`.`Fournisseur`(`siret`,`nomEntreprise`,`libelleReactivite`) VALUES ('123243','Apple','bon');
INSERT INTO `veloMax`.`Fournisseur`(`siret`,`nomEntreprise`,`libelleReactivite`) VALUES ('433243','Orange','très bon');
INSERT INTO `veloMax`.`Fournisseur`(`siret`,`nomEntreprise`,`libelleReactivite`) VALUES ('443423','Decathlon','moyen');
INSERT INTO `veloMax`.`Piece`(`descriptionP`,`nomFournisseur`,`numProdFournisseur`,`prixUnitaire`,`dateIntroduction`,`dateDiscontinuation`,`delaiApprovisionnement`)
VALUES('guidon','Apple',12,20,'2022-5-12','2022-5-30',2);
INSERT INTO `veloMax`.`Piece`(`descriptionP`,`nomFournisseur`,`numProdFournisseur`,`prixUnitaire`,`dateIntroduction`,`dateDiscontinuation`,`delaiApprovisionnement`)
VALUES('freins','Orange',13,24,'2022-5-13','2022-5-30',2);
INSERT INTO `veloMax`.`Piece`(`descriptionP`,`nomFournisseur`,`numProdFournisseur`,`prixUnitaire`,`dateIntroduction`,`dateDiscontinuation`,`delaiApprovisionnement`)
VALUES('cadre','Decathlon',14,22,'2022-5-11','2022-5-30',2);
INSERT INTO `veloMax`.`Approvisionne`(`siret_Appro`,`numProduit_Appro`,`quantite`,`dateAchat`)
VALUES('123243',1,10,'2022-5-14');
INSERT INTO `veloMax`.`Approvisionne`(`siret_Appro`,`numProduit_Appro`,`quantite`,`dateAchat`)
VALUES('433243',2,10,'2022-5-14');
INSERT INTO `veloMax`.`Approvisionne`(`siret_Appro`,`numProduit_Appro`,`quantite`,`dateAchat`)
VALUES('443423',3,10,'2022-5-14');
INSERT INTO `veloMax`.`Modele`(`nomProduit`,`grandeur`,`prixUnitaire`,`ligneProduit`,`dateIntroduction`,`dateDiscontinuation`)
VALUES ('Vélo 1000','Adultes',120,'VTT','2022-5-12','2022-5-30');
INSERT INTO `veloMax`.`Modele`(`nomProduit`,`grandeur`,`prixUnitaire`,`ligneProduit`,`dateIntroduction`,`dateDiscontinuation`)
VALUES ('Vélo 2000','Dames',120,'Vélo de course','2022-5-12','2022-5-30');
INSERT INTO `veloMax`.`Modele`(`nomProduit`,`grandeur`,`prixUnitaire`,`ligneProduit`,`dateIntroduction`,`dateDiscontinuation`)
VALUES ('Velo 3000','Jeunes',100,'Classique','2022-5-12','2022-5-30');
INSERT INTO `veloMax`.`ApprovisionneModele`(`siret_Appro_M`,`numProduit_Appro_M`,`quantite`,`dateAchat`)
VALUES('123243',1,10,'2022-5-14');
INSERT INTO `veloMax`.`ApprovisionneModele`(`siret_Appro_M`,`numProduit_Appro_M`,`quantite`,`dateAchat`)
VALUES('433243',2,10,'2022-5-14');
INSERT INTO `veloMax`.`ApprovisionneModele`(`siret_Appro_M`,`numProduit_Appro_M`,`quantite`,`dateAchat`)
VALUES('443423',3,10,'2022-5-14');
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (1,1);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (2,1);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (3,1);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (1,2);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (2,2);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (3,2);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (1,3);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (2,3);
INSERT INTO `veloMax`.`Assemble`(`numProduit_Piece`,`numProduit_Modele`) VALUES (3,3);
INSERT INTO `veloMax`.`BoutiqueSpecialise`(`nomCompagnie`,`adresse`,`telephone`,`courriel`,`nomContact`)
VALUES ('Microsoft','Silicon Valley','06123456','microsoft@email.fr','Tobi');
INSERT INTO `veloMax`.`BoutiqueSpecialise`(`nomCompagnie`,`adresse`,`telephone`,`courriel`,`nomContact`)
VALUES ('SpaceX','Texas','06134456','spacex@email.fr','Anna');
INSERT INTO `veloMax`.`BoutiqueSpecialise`(`nomCompagnie`,`adresse`,`telephone`,`courriel`,`nomContact`)
VALUES ('Google','Paris','06223433','google@email.fr','Pierre');
INSERT INTO `veloMax`.`Individu`(`nom`,`prenom`,`adresse`,`telephone`,`courriel`)
VALUES ('Dupont','Luc','Paris','06222233','luc@email.fr');
INSERT INTO `veloMax`.`Individu`(`nom`,`prenom`,`adresse`,`telephone`,`courriel`)
VALUES ('Poire','Theo','Paris','06223443','theo@email.fr');
INSERT INTO `veloMax`.`Individu`(`nom`,`prenom`,`adresse`,`telephone`,`courriel`)
VALUES ('Pomme','Tom','Paris','06555433','tom@email.fr');
INSERT INTO `veloMax`.`ProgramFidelite`(`descriptionPF`,`cout`,`duree`,`rabais`)
VALUES ('Fidélio',15,1,5);
INSERT INTO `veloMax`.`ProgramFidelite`(`descriptionPF`,`cout`,`duree`,`rabais`)
VALUES ('Fidélio Or',25,2,8);
INSERT INTO `veloMax`.`ProgramFidelite`(`descriptionPF`,`cout`,`duree`,`rabais`)
VALUES ('Fidélio',60,2,10);
INSERT INTO `veloMax`.`ProgramFidelite`(`descriptionPF`,`cout`,`duree`,`rabais`)
VALUES ('Fidélio',100,3,12);
INSERT INTO `veloMax`.`Adhere`(`idClient_Adhere`,`numProgramme_Adhere`,`dateAdhesion`)
VALUES (1,1,'2022-5-14');
INSERT INTO `veloMax`.`Adhere`(`idClient_Adhere`,`numProgramme_Adhere`,`dateAdhesion`)
VALUES (2,2,'2022-5-14');
INSERT INTO `veloMax`.`Adhere`(`idClient_Adhere`,`numProgramme_Adhere`,`dateAdhesion`)
VALUES (3,3,'2022-5-14');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris1','2022-5-18');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris2','2022-5-18');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris3','2022-5-18');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris4','2022-5-18');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris5','2022-5-18');
INSERT INTO `veloMax`.`Commande`(`dateCommande`,`adresseLivraison`,`dateLivraison`)
VALUES ('2022-5-15','Paris6','2022-5-18');
INSERT INTO `veloMax`.`CommandeClient`(`numUnique_Commande_C`,`idClient_Commande`)
VALUES (1,1);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (1,1,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (1,1,1);
INSERT INTO `veloMax`.`CommandeClient`(`numUnique_Commande_C`,`idClient_Commande`)
VALUES (2,2);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (2,2,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (2,2,1);
INSERT INTO `veloMax`.`CommandeClient`(`numUnique_Commande_C`,`idClient_Commande`)
VALUES (3,3);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (3,3,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (3,3,1);
INSERT INTO `veloMax`.`CommandeBoutique`(`numUnique_Commande_B`,`idBoutique_Commande`)
VALUES (4,1);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (4,3,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (4,3,1);
INSERT INTO `veloMax`.`CommandeBoutique`(`numUnique_Commande_B`,`idBoutique_Commande`)
VALUES (5,2);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (5,2,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (5,2,1);
INSERT INTO `veloMax`.`CommandeBoutique`(`numUnique_Commande_B`,`idBoutique_Commande`)
VALUES (6,3);
INSERT INTO `veloMax`.`CommanderPiece`(`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)
VALUES (6,1,1);
INSERT INTO `veloMax`.`CommanderModele`(`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)
VALUES (6,1,1);



select * from Users;
select username,user_password from Users WHERE username ='admin' AND user_password = 'admin';
-- INSERT INTO Piece (`descriptionP`,`nomFournisseur`,`numProdFournisseur`,`prixUnitaire`,`dateIntroduction`,`dateDiscontinuation`,`delaiApprovisionnement`)   VALUES('ordinateur','Tibo',1222,28,12/08/2021,12/08/2021,2);
select * from Piece;
-- delete from Piece where Piece.numProduit = 2;
select Cm.numProduit_CommanderModele, sum(Cm.quantite) from CommanderModele as Cm group by Cm.numProduit_CommanderModele;
select Pf.descriptionPF, I.nom, I.prenom, DATE_ADD(A.dateAdhesion, interval + Pf.duree year) from Adhere as A join ProgramFidelite as Pf on Pf.numProgramme = A.numProgramme_Adhere join Individu as I on I.idClient = A.idClient_Adhere order by Pf.descriptionPF, I.nom, I.prenom;

select I.nom, I.prenom, sum(Cp.quantite) from Individu as I join CommandeClient as Cc on I.idClient = Cc.idClient_Commande join CommanderPiece as Cp on Cp.numUnique_Commande_P = Cc.numUnique_Commande_C group by Cp.numUnique_Commande_P having sum(Cp.quantite) = max(Cp.quantite);
select avg(Cp.quantite * P.prixUnitaire) from CommanderPiece as Cp join Piece as P on P.numProduit = Cp.numProduit_CommanderPiece group by Cp.numProduit_CommanderPiece;