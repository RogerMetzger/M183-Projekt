
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2018 16:01:51
-- Generated from EDMX file: C:\Projects\M183\M183-Projekt\Mini-Blog\Mini-Blog\Models\MiniBlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [m183_project];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[Token]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Token];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLog];
GO
IF OBJECT_ID(N'[dbo].[Userlogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Userlogin];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Commet] varchar(max)  NULL,
    [CreatedOn] datetime  NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Title] varchar(50)  NOT NULL,
    [Description] varchar(500)  NOT NULL,
    [Content] varchar(max)  NOT NULL,
    [CreatedOn] datetime  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedOn] datetime  NULL
);
GO

-- Creating table 'Tokens'
CREATE TABLE [dbo].[Tokens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Token1] varchar(50)  NOT NULL,
    [UserId] int  NOT NULL,
    [Expiry] datetime  NOT NULL,
    [DeletedOn] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Firstname] varchar(50)  NOT NULL,
    [Familyname] varchar(50)  NOT NULL,
    [Mobilephonenumber] varchar(50)  NULL,
    [Role] varchar(20)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'UserLogs'
CREATE TABLE [dbo].[UserLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Action] varchar(500)  NULL
);
GO

-- Creating table 'Userlogins'
CREATE TABLE [dbo].[Userlogins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [IP] varchar(50)  NULL,
    [SessionId] varchar(50)  NULL,
    [CreatedOn] datetime  NULL,
    [ModifiedOn] datetime  NULL,
    [DeletedOn] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tokens'
ALTER TABLE [dbo].[Tokens]
ADD CONSTRAINT [PK_Tokens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [PK_UserLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Userlogins'
ALTER TABLE [dbo].[Userlogins]
ADD CONSTRAINT [PK_Userlogins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_CommentPost]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[Posts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentPost'
CREATE INDEX [IX_FK_CommentPost]
ON [dbo].[Comments]
    ([PostId]);
GO

-- Creating foreign key on [UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_CommentUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentUser'
CREATE INDEX [IX_FK_CommentUser]
ON [dbo].[Comments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_PostUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostUser'
CREATE INDEX [IX_FK_PostUser]
ON [dbo].[Posts]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Tokens'
ALTER TABLE [dbo].[Tokens]
ADD CONSTRAINT [FK_TokenUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TokenUser'
CREATE INDEX [IX_FK_TokenUser]
ON [dbo].[Tokens]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Userlogins'
ALTER TABLE [dbo].[Userlogins]
ADD CONSTRAINT [FK_UserUserlogin]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserlogin'
CREATE INDEX [IX_FK_UserUserlogin]
ON [dbo].[Userlogins]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [FK_UserUserLog]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserLog'
CREATE INDEX [IX_FK_UserUserLog]
ON [dbo].[UserLogs]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------