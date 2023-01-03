DROP TABLE IF EXISTS tennisVlaanderen.SpelerClubTornooi;
DROP TABLE IF EXISTS tennisVlaanderen.Tornooi;
DROP TABLE IF EXISTS tennisVlaanderen.TerreinReservatie;
DROP TABLE IF EXISTS tennisVlaanderen.Abonnement;
DROP TABLE IF EXISTS tennisVlaanderen.Tarieven;
DROP TABLE IF EXISTS tennisVlaanderen.Speler;
DROP TABLE IF EXISTS tennisVlaanderen.Club;


DROP SCHEMA IF EXISTS tennisVlaanderen;
GO

CREATE SCHEMA tennisVlaanderen;
GO

--aanmaken van (Kernentiteit) tabel: Club
CREATE TABLE tennisVlaanderen.Club (
    Id int IDENTITY(1,1) NOT NULL,
    ClubNaam varchar(100) NOT NULL,
    Adres varchar(100) NOT NULL,
    Telefoon varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	Website varchar(100) NOT NULL,
    KwaliteitLabel varchar(100) NOT NULL,
	Clubaanbod varchar(100) NOT NULL,
    CONSTRAINT PK_Club PRIMARY KEY(Id),
);

--aanmaken van (Kernentiteit) tabel: Speler
CREATE TABLE tennisVlaanderen.Speler (
    Id int IDENTITY(1,1) NOT NULL,
    ClubID int,
	Naam varchar(100) NOT NULL,
	Voornaam varchar(100) NOT NULL,
	Klassement varchar(100) NOT NULL,
	Geslacht varchar(100) NOT NULL,
	GeboorteDatum date NOT NULL,
	Nationaliteit varchar(100) NOT NULL,
	Adres varchar(100) NOT NULL,
	Land varchar(100) NOT NULL,
	Telefoon varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	RijksNummer varchar(100) NOT NULL,
	CONSTRAINT PK_Speler PRIMARY KEY (Id),
    CONSTRAINT FK_tennisVlaanderen_Club_Inschrijven FOREIGN KEY (ClubID)
	REFERENCES tennisVlaanderen.Club (Id) 
);

--aanmaken van (Associatie v) tabel: Tarieven
CREATE TABLE tennisVlaanderen.Tarieven (
    Id int IDENTITY(1,1) NOT NULL,
	ClubID int NOT NULL,
    Leeftijdgraad varchar(100),
    TypeTennis varchar(100) NOT NULL,
	Prijs money NULL,
    CONSTRAINT PK_Tarieven PRIMARY KEY(Id),
    CONSTRAINT FK_tennisVlaanderen_Club FOREIGN KEY (ClubID)
	REFERENCES tennisVlaanderen.Club (Id) 
);

--aanmaken van (Associatie entiteit) tabel: Abonnement
CREATE TABLE tennisVlaanderen.Abonnement (
    Id int IDENTITY(1,1) NOT NULL,
	SpelerID int NOT NULL,
	ClubID int NOT NULL,
    Lessen varchar(100) null,
    Stages varchar(100) null,
    CONSTRAINT PK_Abonnement PRIMARY KEY(Id),
	CONSTRAINT FK_tennisVlaanderen_Speler FOREIGN KEY (SpelerID)
	REFERENCES tennisVlaanderen.Speler (Id),
    CONSTRAINT FK_tennisVlaanderen_Club_Abonnement FOREIGN KEY (ClubID)
	REFERENCES tennisVlaanderen.Club (Id)
);

--aanmaken van (Karakteristieke entiteit) tabel: TerreinReservatie
CREATE TABLE tennisVlaanderen.TerreinReservatie (
    Id int IDENTITY(1,1) NOT NULL,
    SpelerID int NOT NULL,
    TerreinNummer varchar(100) NOT NULL,
    TypeOndergrond varchar(100) NOT NULL,
	TypeTennis varchar(100) NOT NULL,
    CONSTRAINT PK_TerreinReservatie PRIMARY KEY(Id),
    CONSTRAINT FK_tennisVlaanderen_Speler_TerreinReservatie FOREIGN KEY (SpelerID)
	REFERENCES tennisVlaanderen.Speler (Id)
);

--aanmaken van (Karakteristieke entiteit) tabel: Tornooi
CREATE TABLE tennisVlaanderen.Tornooi (
    Id int IDENTITY(1,1) NOT NULL,
    NaamTornooi varchar(100) NOT NULL,
    Datum date NOT NULL,
    Circuit varchar(100) NOT NULL,
	TypeCompetitie varchar(100) NOT NULL,
    CONSTRAINT PK_Tornooi PRIMARY KEY(Id),
);

--aanmaken van (Associatie entiteit) tabel: SpelerClubTornooi
CREATE TABLE tennisVlaanderen.SpelerClubTornooi (
    Id int IDENTITY(1,1) NOT NULL,
    ClubID int NOT NULL,
    SpelerID int NOT NULL,
    TornooiID int NOT NULL,
    CONSTRAINT PK_SpelerClubTornooi PRIMARY KEY(id),
    CONSTRAINT FK_tennisVlaanderen_Speler_SpelerClubTornooi FOREIGN KEY (SpelerID)
	REFERENCES tennisVlaanderen.Speler (Id),
	CONSTRAINT FK_tennisVlaanderen_Club_SpelerClubTornooi FOREIGN KEY (ClubID)
	REFERENCES tennisVlaanderen.Club (Id),
	CONSTRAINT FK_tennisVlaanderen_Tornooi FOREIGN KEY (TornooiID)
	REFERENCES tennisVlaanderen.Tornooi (Id)
);


SET IDENTITY_INSERT tennisVlaanderen.Club ON
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (1,'',' ','','','','','');
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (2,'GT.Tessenderlo','Voorbeeld straat 99 3980 Tessenderlo','+3231234567','tessenderlo@email.be','www.GT.Tessenderlo.be','Goudlabel - blauwlabel + PTC','Tennis - Paddel');
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (3,'GT.Westerlo','Voorbeeld straat 99 2260 Westerlo','+3231234567','westerlo@email.be','www.GT.Westerlo.be','Goudlabel','Tennis - Paddel');
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (4,'GT.Oevel','Voorbeeld straat 99 2260 Westerlo','+3231234567','oevel@email.be','www.GT.Oevel.be','Goudlabel','Tennis');
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (5,'GT.Tongerlo','Voorbeeld straat 99 2260 Westerlo','+3231234567','tongerlo@email.be','www.GT.Tongerlo.be','Goudlabel - blauwlabel + PTC','Tennis');
INSERT INTO tennisVlaanderen.Club (Id, ClubNaam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (6,'GT.Voortkapel','Voorbeeld straat 99 2260 Westerlo','+3231234567','voortkapel@email.be','www.GT.Voortkapel.be','Goudlabel - blauwlabel','Tennis - Paddel');
SET IDENTITY_INSERT tennisVlaanderen.Club OFF

SET IDENTITY_INSERT tennisVlaanderen.Speler ON
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (1,'2','de Jong','Olivia','enkel 8 ptn','Vrouw','1972-10-12','Belg','Voorbeeld straat 99 3980 Tessenderlo','België','+3231234567','olivia@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (2,'3','Jansen','Arthur','dubbel 30 ptn','Man','1999-11-14','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','arthur@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (3,'4','de Vries','Emma','dubbel 25 ptn','Vrouw','2001-01-15','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','emma@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (4,'5','van den Berg','Noah','enkel 48 ptn','Man','1997-06-14','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','noah@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (5,'6','van Dijk','Mila','enkel 330 ptn','Vrouw','1986-07-07','Belg','Voorbeeld straat 99 3980 Tessenderlo','België','+3231234567','mila@email.be','00.01.01-123.45');
SET IDENTITY_INSERT tennisVlaanderen.Speler OFF

SET IDENTITY_INSERT tennisVlaanderen.Tarieven ON
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (1,'2','volswassen','tennis','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (2,'2','volswassen','paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (3,'2','volswassen','tennis + paddel','120.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (4,'2','jeugd','tennis','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (5,'2','jeugd','paddel','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (6,'2','jeugd','tennis + paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (7,'2','senioren','tennis','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (8,'2','senioren','paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (9,'2','senioren','tennis + paddel','80.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (10,'3','volswassen','tennis','50.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (11,'3','volswassen','paddel','50.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (12,'3','volswassen','tennis + paddel','100.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (13,'3','jeugd','tennis','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (14,'3','jeugd','paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (15,'3','jeugd','tennis + paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (16,'3','senioren','tennis','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (17,'3','senioren','paddel','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (18,'3','senioren','tennis + paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (19,'3','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (20,'4','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (21,'4','jeugd','tennis + paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (22,'4','volswassen','tennis','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (23,'4','volswassen','paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (24,'4','volswassen','tennis + paddel','120.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (25,'4','senioren','tennis','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (26,'4','senioren','paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (27,'4','senioren','tennis + paddel','80.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (28,'5','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (29,'5','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (30,'5','jeugd','tennis + paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (31,'5','volswassen','tennis','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (32,'5','volswassen','paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (33,'5','volswassen','tennis + paddel','120.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (34,'5','senioren','tennis','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (35,'5','senioren','paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (36,'5','senioren','tennis + paddel','80.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (37,'6','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (38,'6','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (39,'6','jeugd','tennis + paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (40,'6','volswassen','tennis','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (41,'6','volswassen','paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (42,'6','volswassen','tennis + paddel','120.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (43,'6','senioren','tennis','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (44,'6','senioren','paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (45,'6','senioren','tennis + paddel','80.00');
SET IDENTITY_INSERT tennisVlaanderen.Tarieven OFF

SET IDENTITY_INSERT tennisVlaanderen.Abonnement ON
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (1,'1','2','6','4');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (2,'2','3','10','0');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (3,'3','4','11','0');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (4,'4','5','14','9');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (5,'5','6','6','6');
SET IDENTITY_INSERT tennisVlaanderen.Abonnement OFF

SET IDENTITY_INSERT tennisVlaanderen.TerreinReservatie ON
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (1,'1','1','Gravel','enkel');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (2,'2','2','Gras','enkel');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (3,'3','3','gravel','double');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (4,'4','4','Gras','double');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (5,'5','5','Gravel','enkel');
SET IDENTITY_INSERT tennisVlaanderen.TerreinReservatie OFF

SET IDENTITY_INSERT tennisVlaanderen.Tornooi ON
INSERT INTO tennisVlaanderen.Tornooi (Id,NaamTornooi,Datum,Circuit,TypeCompetitie) 
VALUES (1,'Vlaanderen interclub','2022-06-12','Vlaanderen-cup','enkel spel');
INSERT INTO tennisVlaanderen.Tornooi (Id,NaamTornooi,Datum,Circuit,TypeCompetitie) 
VALUES (2,'Adelaide International 1','2022-07-22','ATP 250','enkel spel');
INSERT INTO tennisVlaanderen.Tornooi (Id,NaamTornooi,Datum,Circuit,TypeCompetitie) 
VALUES (3,'ATP Challenger Quimper, France','2022-09-22','ATP 500','enkel spel');
INSERT INTO tennisVlaanderen.Tornooi (Id,NaamTornooi,Datum,Circuit,TypeCompetitie) 
VALUES (4,'Open Sud de France','2022-07-14','ATP 250','double spel');
INSERT INTO tennisVlaanderen.Tornooi (Id,NaamTornooi,Datum,Circuit,TypeCompetitie) 
VALUES (5,'Qatar ExxonMobil Open','2022-12-14','Grand Slam','double spel');
SET IDENTITY_INSERT tennisVlaanderen.Tornooi OFF

SET IDENTITY_INSERT tennisVlaanderen.SpelerClubTornooi ON
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (1,'2','1','1');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (2,'3','2','2');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (3,'4','3','3');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (4,'5','4','4');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (5,'6','5','5');
SET IDENTITY_INSERT tennisVlaanderen.SpelerClubTornooi OFF

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.TerreinReservatie  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Speler_TerreinReservatie;  
GO  

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.SpelerClubTornooi  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Speler_SpelerClubTornooi;  
GO  

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.Abonnement  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Speler;  
GO  

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.Abonnement  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Club_Abonnement;  
GO  

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.SpelerClubTornooi  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Club_SpelerClubTornooi;  
GO  

USE TennisVlaanderen;  
GO  
ALTER TABLE TennisVlaanderen.SpelerClubTornooi  
NOCHECK CONSTRAINT FK_tennisVlaanderen_Tornooi;  
GO  