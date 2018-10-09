
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/14/2010 16:31:01
-- Generated from EDMX file: G:\LiveSync\VB 2010 EWB\German\Samples\Kapitel 30 - LINQ to Entities\ModelFirst\ModelFirst\modelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [meineNeueDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Projektleiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projekte] DROP CONSTRAINT [FK_Projektleiter];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjekteMitarbeiter_Projekte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjekteMitarbeiter] DROP CONSTRAINT [FK_ProjekteMitarbeiter_Projekte];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjekteMitarbeiter_Mitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjekteMitarbeiter] DROP CONSTRAINT [FK_ProjekteMitarbeiter_Mitarbeiter];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Mitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[Projekte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projekte];
GO
IF OBJECT_ID(N'[dbo].[ProjekteMitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjekteMitarbeiter];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Mitarbeiter'
CREATE TABLE [dbo].[Mitarbeiter] (
    [MitarbeiterID] int IDENTITY(1,1) NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Geburtstag] nvarchar(max)  NOT NULL,
    [AngestelltSeit] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projekte'
CREATE TABLE [dbo].[Projekte] (
    [ProjektID] int IDENTITY(1,1) NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [Kostenstelle] int  NOT NULL,
    [Leiter_MitarbeiterID] int  NOT NULL
);
GO

-- Creating table 'Mitarbeiter_Entwickler'
CREATE TABLE [dbo].[Mitarbeiter_Entwickler] (
    [Programmiersprache] nvarchar(max)  NOT NULL,
    [MitarbeiterID] int  NOT NULL
);
GO

-- Creating table 'ProjekteMitarbeiter'
CREATE TABLE [dbo].[ProjekteMitarbeiter] (
    [MitarbeitAn_ProjektID] int  NOT NULL,
    [Mitarbeiter_MitarbeiterID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MitarbeiterID] in table 'Mitarbeiter'
ALTER TABLE [dbo].[Mitarbeiter]
ADD CONSTRAINT [PK_Mitarbeiter]
    PRIMARY KEY CLUSTERED ([MitarbeiterID] ASC);
GO

-- Creating primary key on [ProjektID] in table 'Projekte'
ALTER TABLE [dbo].[Projekte]
ADD CONSTRAINT [PK_Projekte]
    PRIMARY KEY CLUSTERED ([ProjektID] ASC);
GO

-- Creating primary key on [MitarbeiterID] in table 'Mitarbeiter_Entwickler'
ALTER TABLE [dbo].[Mitarbeiter_Entwickler]
ADD CONSTRAINT [PK_Mitarbeiter_Entwickler]
    PRIMARY KEY CLUSTERED ([MitarbeiterID] ASC);
GO

-- Creating primary key on [MitarbeitAn_ProjektID], [Mitarbeiter_MitarbeiterID] in table 'ProjekteMitarbeiter'
ALTER TABLE [dbo].[ProjekteMitarbeiter]
ADD CONSTRAINT [PK_ProjekteMitarbeiter]
    PRIMARY KEY NONCLUSTERED ([MitarbeitAn_ProjektID], [Mitarbeiter_MitarbeiterID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Leiter_MitarbeiterID] in table 'Projekte'
ALTER TABLE [dbo].[Projekte]
ADD CONSTRAINT [FK_Projektleiter]
    FOREIGN KEY ([Leiter_MitarbeiterID])
    REFERENCES [dbo].[Mitarbeiter]
        ([MitarbeiterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Projektleiter'
CREATE INDEX [IX_FK_Projektleiter]
ON [dbo].[Projekte]
    ([Leiter_MitarbeiterID]);
GO

-- Creating foreign key on [MitarbeitAn_ProjektID] in table 'ProjekteMitarbeiter'
ALTER TABLE [dbo].[ProjekteMitarbeiter]
ADD CONSTRAINT [FK_ProjekteMitarbeiter_Projekte]
    FOREIGN KEY ([MitarbeitAn_ProjektID])
    REFERENCES [dbo].[Projekte]
        ([ProjektID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Mitarbeiter_MitarbeiterID] in table 'ProjekteMitarbeiter'
ALTER TABLE [dbo].[ProjekteMitarbeiter]
ADD CONSTRAINT [FK_ProjekteMitarbeiter_Mitarbeiter]
    FOREIGN KEY ([Mitarbeiter_MitarbeiterID])
    REFERENCES [dbo].[Mitarbeiter]
        ([MitarbeiterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjekteMitarbeiter_Mitarbeiter'
CREATE INDEX [IX_FK_ProjekteMitarbeiter_Mitarbeiter]
ON [dbo].[ProjekteMitarbeiter]
    ([Mitarbeiter_MitarbeiterID]);
GO

-- Creating foreign key on [MitarbeiterID] in table 'Mitarbeiter_Entwickler'
ALTER TABLE [dbo].[Mitarbeiter_Entwickler]
ADD CONSTRAINT [FK_Entwickler_erbt_Mitarbeiter]
    FOREIGN KEY ([MitarbeiterID])
    REFERENCES [dbo].[Mitarbeiter]
        ([MitarbeiterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------