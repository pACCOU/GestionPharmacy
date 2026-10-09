-- =====================================================================
--  GestionPharmacy — création de la base MaPharmacie (SQL Server / LocalDB)
--  Exécuter dans SSMS ou :  sqlcmd -S "(LocalDB)\MSSQLLocalDB" -i MaPharmacie.sql
-- =====================================================================
IF DB_ID('MaPharmacie') IS NULL CREATE DATABASE MaPharmacie;
GO
USE MaPharmacie;
GO

IF OBJECT_ID('MedicamentTbl') IS NOT NULL DROP TABLE MedicamentTbl;
IF OBJECT_ID('FabricantTbl')  IS NOT NULL DROP TABLE FabricantTbl;
IF OBJECT_ID('AgentTbl')      IS NOT NULL DROP TABLE AgentTbl;
GO

CREATE TABLE AgentTbl (
    AgNum       INT IDENTITY(1,1) PRIMARY KEY,
    AgNom       NVARCHAR(100) NOT NULL UNIQUE,
    AgDateNaiss DATE          NULL,
    AgTel       NVARCHAR(30)  NULL,
    AgSex       NVARCHAR(10)  NULL,
    AgPdw       NVARCHAR(100) NOT NULL   -- mot de passe (voir README : à hacher avant mise en production)
);

CREATE TABLE FabricantTbl (
    FabNum  INT IDENTITY(1,1) PRIMARY KEY,
    FabNom  NVARCHAR(100) NOT NULL,
    FabAd   NVARCHAR(200) NULL,
    FabDesc NVARCHAR(400) NULL,
    FabTel  NVARCHAR(30)  NULL
);

CREATE TABLE MedicamentTbl (
    MedNum  INT IDENTITY(1,1) PRIMARY KEY,
    MedNom  NVARCHAR(150)  NOT NULL,
    MedPrix DECIMAL(10,2)  NOT NULL DEFAULT 0,
    MedQte  INT            NOT NULL DEFAULT 0,
    MedFab  INT            NOT NULL REFERENCES FabricantTbl(FabNum),
    MedExp  DATE           NULL
);
GO

-- Données de démonstration
INSERT INTO AgentTbl (AgNom, AgDateNaiss, AgTel, AgSex, AgPdw) VALUES
 ('admin', '1990-01-01', '0000000000', 'Homme', 'admin');

INSERT INTO FabricantTbl (FabNom, FabAd, FabDesc, FabTel) VALUES
 ('Sanofi',  'Paris, France',   'Laboratoire pharmaceutique', '+33 1 00 00 00 00'),
 ('Cipla',   'Mumbai, Inde',    'Génériques',                 '+91 22 0000 0000');

INSERT INTO MedicamentTbl (MedNom, MedPrix, MedQte, MedFab, MedExp) VALUES
 ('Paracétamol 500 mg', 1.50, 200, 1, DATEADD(year, 2, GETDATE())),
 ('Amoxicilline 1 g',   4.20,  80, 2, DATEADD(year, 1, GETDATE()));
GO
