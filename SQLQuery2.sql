
SET IDENTITY_INSERT tennisVlaanderen.Club ON
INSERT INTO tennisVlaanderen.Club (Id, Naam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (1,'GT.Tessenderlo','Voorbeeld straat 99 3980 Tessenderlo','+3231234567','tessenderlo@email.be','www.GT.Tessenderlo.be','Goudlabel - blauwlabel + PTC','Tennis - Paddel');
INSERT INTO tennisVlaanderen.Club (Id, Naam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (2,'GT.Westerlo','Voorbeeld straat 99 2260 Westerlo','+3231234567','westerlo@email.be','www.GT.Westerlo.be','Goudlabel','Tennis - Paddel');
INSERT INTO tennisVlaanderen.Club (Id, Naam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (3,'GT.Oevel','Voorbeeld straat 99 2260 Westerlo','+3231234567','oevel@email.be','www.GT.Oevel.be','Goudlabel','Tennis');
INSERT INTO tennisVlaanderen.Club (Id, Naam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (4,'GT.Tongerlo','Voorbeeld straat 99 2260 Westerlo','+3231234567','tongerlo@email.be','www.GT.Tongerlo.be','Goudlabel - blauwlabel + PTC','Tennis');
INSERT INTO tennisVlaanderen.Club (Id, Naam,Adres,Telefoon,Email,Website,KwaliteitLabel,Clubaanbod) 
VALUES (5,'GT.Voortkapel','Voorbeeld straat 99 2260 Westerlo','+3231234567','voortkapel@email.be','www.GT.Voortkapel.be','Goudlabel - blauwlabel','Tennis - Paddel');
SET IDENTITY_INSERT tennisVlaanderen.Club OFF

SET IDENTITY_INSERT tennisVlaanderen.Speler ON
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (1,'1','de Jong','Olivia','enkel 8 ptn','Vrouw','1972-10-12','Belg','Voorbeeld straat 99 3980 Tessenderlo','België','+3231234567','olivia@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (2,'2','Jansen','Arthur','dubbel 30 ptn','Man','1999-11-14','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','arthur@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (3,'3','de Vries','Emma','dubbel 25 ptn','Vrouw','2001-01-15','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','emma@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (4,'4','van den Berg','Noah','enkel 48 ptn','Man','1997-06-14','Belg','Voorbeeld straat 99 2260 Westerlo','België','+3231234567','noah@email.be','00.01.01-123.45');
INSERT INTO tennisVlaanderen.Speler (Id,ClubId,Naam,Voornaam,klassement,Geslacht,GeboorteDatum,Nationaliteit,Adres,Land,Telefoon,Email,RijksNummer) 
VALUES (5,'5','van Dijk','Mila','enkel 330 ptn','Vrouw','1986-07-07','Belg','Voorbeeld straat 99 3980 Tessenderlo','België','+3231234567','mila@email.be','00.01.01-123.45');
SET IDENTITY_INSERT tennisVlaanderen.Speler OFF

SET IDENTITY_INSERT tennisVlaanderen.Tarieven ON
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (1,'1','volswassen','tennis','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (2,'1','volswassen','paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (3,'1','volswassen','tennis + paddel','120.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (4,'1','jeugd','tennis','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (5,'1','jeugd','paddel','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (6,'1','jeugd','tennis + paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (7,'1','senioren','tennis','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (8,'1','senioren','paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (9,'1','senioren','tennis + paddel','80.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (10,'2','volswassen','tennis','50.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (11,'2','volswassen','paddel','50.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (12,'2','volswassen','tennis + paddel','100.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (13,'2','jeugd','tennis','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (14,'2','jeugd','paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (15,'2','jeugd','tennis + paddel','40.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (16,'2','senioren','tennis','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (17,'2','senioren','paddel','30.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (18,'2','senioren','tennis + paddel','60.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (19,'3','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (20,'3','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (21,'3','jeugd','tennis + paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (19,'4','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (20,'4','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (21,'4','jeugd','tennis + paddel','20.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (19,'5','jeugd','tennis','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (20,'5','jeugd','paddel','10.00');
INSERT INTO tennisVlaanderen.Tarieven (Id,ClubID,Leeftijdgraad,TypeTennis,Prijs) 
VALUES (21,'','jeugd','tennis + paddel','20.00');
SET IDENTITY_INSERT tennisVlaanderen.Tarieven OFF

SET IDENTITY_INSERT tennisVlaanderen.Abonnement ON
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (1,'1','3','6','4');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (2,'2','5','10','0');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (3,'3','2','11','0');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (4,'4','1','14','9');
INSERT INTO tennisVlaanderen.Abonnement (Id,SpelerID,ClubID,Lessen,Stages) 
VALUES (5,'5','4','6','6');
SET IDENTITY_INSERT tennisVlaanderen.Abonnement OFF

SET IDENTITY_INSERT tennisVlaanderen.TerreinReservatie ON
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (1,'5','1','Gravel','enkel');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (2,'3','2','Gras','enkel');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (3,'1','3','gravel','double');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (4,'4','4','Gras','double');
INSERT INTO tennisVlaanderen.TerreinReservatie (Id,SpelerID,TerreinNummer,TypeOndergrond,TypeTennis) 
VALUES (5,'2','5','Gravel','enkel');
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
VALUES (1,'2','5','1');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (2,'3','4','3');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (3,'4','3','2');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (4,'1','2','5');
INSERT INTO tennisVlaanderen.SpelerClubTornooi (Id,ClubID,SpelerID,TornooiID) 
VALUES (5,'5','1','4');
SET IDENTITY_INSERT tennisVlaanderen.SpelerClubTornooi OFF