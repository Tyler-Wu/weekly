
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2014 17:06:00
-- Generated from EDMX file: F:\code\WeeklyReprot\WeeklyReport.Models\WeeklyReportModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WeeklyReport];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Project_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_User];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkItem_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkItem] DROP CONSTRAINT [FK_WorkItem_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkItem_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkItem] DROP CONSTRAINT [FK_WorkItem_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectUser_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectUser] DROP CONSTRAINT [FK_ProjectUser_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectUser] DROP CONSTRAINT [FK_ProjectUser_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[WorkItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItem];
GO
IF OBJECT_ID(N'[dbo].[ProjectUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [PorjectId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [LeaderId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [Status] varchar(10)  NULL,
    [Color] varchar(10)  NULL,
    [StartDate] datetime  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [RoleId] int  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UserName] nvarchar(20)  NULL,
    [Passwrod] nvarchar(20)  NULL
);
GO

-- Creating table 'WorkItem'
CREATE TABLE [dbo].[WorkItem] (
    [ItemId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [ProjectId] uniqueidentifier  NOT NULL,
    [Body] nvarchar(500)  NULL,
    [StartTime] time  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [EndTime] time  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [CreateUser] uniqueidentifier  NULL,
    [UpdateUser] uniqueidentifier  NULL,
    [AllDay] bit  NOT NULL,
    [Duration] float  NOT NULL,
    [CalendarId] int  NOT NULL
);
GO

-- Creating table 'ProjectUser'
CREATE TABLE [dbo].[ProjectUser] (
    [ProjectUser_User_PorjectId] uniqueidentifier  NOT NULL,
    [ProjectUser_Project_UserId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PorjectId] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([PorjectId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ItemId] in table 'WorkItem'
ALTER TABLE [dbo].[WorkItem]
ADD CONSTRAINT [PK_WorkItem]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [ProjectUser_User_PorjectId], [ProjectUser_Project_UserId] in table 'ProjectUser'
ALTER TABLE [dbo].[ProjectUser]
ADD CONSTRAINT [PK_ProjectUser]
    PRIMARY KEY CLUSTERED ([ProjectUser_User_PorjectId], [ProjectUser_Project_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LeaderId] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_Project_User]
    FOREIGN KEY ([LeaderId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_User'
CREATE INDEX [IX_FK_Project_User]
ON [dbo].[Project]
    ([LeaderId]);
GO

-- Creating foreign key on [ProjectId] in table 'WorkItem'
ALTER TABLE [dbo].[WorkItem]
ADD CONSTRAINT [FK_WorkItem_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([PorjectId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkItem_Project'
CREATE INDEX [IX_FK_WorkItem_Project]
ON [dbo].[WorkItem]
    ([ProjectId]);
GO

-- Creating foreign key on [RoleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[User]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'WorkItem'
ALTER TABLE [dbo].[WorkItem]
ADD CONSTRAINT [FK_WorkItem_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkItem_User'
CREATE INDEX [IX_FK_WorkItem_User]
ON [dbo].[WorkItem]
    ([UserId]);
GO

-- Creating foreign key on [ProjectUser_User_PorjectId] in table 'ProjectUser'
ALTER TABLE [dbo].[ProjectUser]
ADD CONSTRAINT [FK_ProjectUser_Project]
    FOREIGN KEY ([ProjectUser_User_PorjectId])
    REFERENCES [dbo].[Project]
        ([PorjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectUser_Project_UserId] in table 'ProjectUser'
ALTER TABLE [dbo].[ProjectUser]
ADD CONSTRAINT [FK_ProjectUser_User]
    FOREIGN KEY ([ProjectUser_Project_UserId])
    REFERENCES [dbo].[User]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUser_User'
CREATE INDEX [IX_FK_ProjectUser_User]
ON [dbo].[ProjectUser]
    ([ProjectUser_Project_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------