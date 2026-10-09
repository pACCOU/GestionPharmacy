# GestionPharmacy

Application Windows (C# / WinForms, .NET Framework 4.7.2) de gestion d'une
pharmacie : médicaments, fabricants, agents, avec écran de connexion et
espace administrateur.

> **English** — Pharmacy management desktop app (C# WinForms, .NET 4.7.2, SQL
> Server LocalDB). Written in 2024 as a learning project; cleaned up in 2026:
> parameterized queries, connection string in `App.config`, SQL schema script,
> several logic bugs fixed (see *Historique*).

![.NET Framework 4.7.2](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)
![C#](https://img.shields.io/badge/C%23-WinForms-239120)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927)
![Licence MIT](https://img.shields.io/badge/licence-MIT-green)

## Fonctionnalités

| Écran | Ce qu'il fait |
|-------|---------------|
| Splash + Connexion | Démarrage, authentification d'un agent (table `AgentTbl`) |
| Médicaments | Liste, ajout, modification, suppression ; fabricant choisi dans une liste ; date d'expiration |
| Fabricants | Liste, ajout, modification, suppression |
| Agents (admin) | Gestion des comptes utilisateurs, accessible via le mot de passe administrateur |

Interface construite avec [Guna.UI2](https://github.com/GunaUI/Guna.UI2.WinForms)
(restauré automatiquement par NuGet).

## Installation

Prérequis : Windows 10/11, Visual Studio 2022 (charge de travail « Développement
.NET Desktop »), SQL Server LocalDB (installé avec Visual Studio) ou SQL Express.

```powershell
git clone https://github.com/pACCOU/GestionPharmacy.git
cd GestionPharmacy

# 1. Créer la base et les données de démonstration
sqlcmd -S "(LocalDB)\MSSQLLocalDB" -i database\MaPharmacie.sql

# 2. Ouvrir GestionPharmacy.sln dans Visual Studio, restaurer les packages NuGet, F5
```

La chaîne de connexion se trouve dans `GestionPharmacy/App.config` (clé
`MaPharmacie`). Pour une instance SQL Server classique :

```xml
<add name="MaPharmacie"
     connectionString="Server=localhost;Database=MaPharmacie;Integrated Security=True"
     providerName="System.Data.SqlClient" />
```

Compte de démonstration : `admin` / `admin`. Mot de passe de l'espace
administrateur : `Admin` (constante dans `Admin.cs`, à changer).

## Schéma de la base

```
AgentTbl      (AgNum PK, AgNom, AgDateNaiss, AgTel, AgSex, AgPdw)
FabricantTbl  (FabNum PK, FabNom, FabAd, FabDesc, FabTel)
MedicamentTbl (MedNum PK, MedNom, MedPrix, MedQte, MedFab -> FabricantTbl, MedExp)
```

Script complet : [`database/MaPharmacie.sql`](database/MaPharmacie.sql).

## Structure du code

```
GestionPharmacy/
├── Db.cs            accès données unique : connexion depuis App.config, requêtes paramétrées
├── Connexion.cs     authentification
├── Medicaments.cs   CRUD médicaments
├── Fabricants.cs    CRUD fabricants
├── Agents.cs        CRUD agents (admin)
├── Admin.cs, Splash.cs, Dashboard.cs, Factures.cs
└── *.Designer.cs    formulaires générés par Visual Studio
database/MaPharmacie.sql
```

## Historique

**2026 — remise en état**
- Suppression de 43 Mo de `bin/`, `obj/`, `.vs/` et `packages/` versionnés par erreur ; `.gitignore` standard Visual Studio.
- Chaîne de connexion sortie du code (elle pointait vers `C:\Users\admin\Documents\…`) et centralisée dans `App.config`.
- Toutes les requêtes passent par `Db.cs` avec des paramètres SQL : plus d'injection possible, dates et nombres typés.
- Bugs corrigés : la connexion ne pouvait jamais réussir (comparaison avec le contrôle au lieu de son texte) ; `UPDATE` sans `WHERE` qui modifiait **tous** les médicaments / fabricants ; noms de tables erronés dans les suppressions ; le formulaire Fabricants utilisait une chaîne OLEDB Access avec un `SqlConnection` ; la liste des fabricants d'un médicament était remplie avec des numéros de médicaments ; le téléphone d'un fabricant écrasait son adresse.
- Script SQL de création de la base avec données de démonstration.

**2024 — version initiale** (projet d'apprentissage).

## Limites connues / pistes

- Les mots de passe sont stockés en clair : utiliser un hachage (PBKDF2 / BCrypt) avant tout usage réel.
- Les écrans Dashboard et Factures sont des coquilles vides.
- Portage possible vers .NET 8 WinForms (`dotnet upgrade-assistant`), Guna.UI2 est compatible.

Licence MIT — Florian Whannou
