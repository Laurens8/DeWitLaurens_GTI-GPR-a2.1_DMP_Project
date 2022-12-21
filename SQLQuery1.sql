DROP TABLE IF EXISTS tennisVlaanderen.SpelerClubTornooi;
DROP TABLE IF EXISTS tennisVlaanderen.Tornooi;
DROP TABLE IF EXISTS tennisVlaanderen.TerreinReservatie;
DROP TABLE IF EXISTS tennisVlaanderen.Abonnement;
DROP TABLE IF EXISTS tennisVlaanderen.Tarieven;
DROP TABLE IF EXISTS tennisVlaanderen.Club;
DROP TABLE IF EXISTS tennisVlaanderen.Speler;

DROP SCHEMA IF EXISTS tennisVlaanderen;
GO

CREATE SCHEMA tennisVlaanderen;
GO

--aanmaken van (Kernentiteit) tabel: Speler
CREATE TABLE tennisVlaanderen.Speler (
    Id int IDENTITY(1,1) NOT NULL,
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
	CONSTRAINT PK_Speler PRIMARY KEY (Id)
);

--aanmaken van (Kernentiteit) tabel: Club
CREATE TABLE tennisVlaanderen.Club (
    Id int IDENTITY(1,1) NOT NULL,
    Naam varchar(100) NOT NULL,
    Adres varchar(100) NOT NULL,
    Telefoon varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	Website varchar(100) NOT NULL,	KwaliteitLabel varchar(100) NOT NULL,
	Clubaanbod varchar(100) NOT NULL,
    CONSTRAINT PK_Club PRIMARY KEY(Id),
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
