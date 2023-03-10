--Note: Only Run The create database once and then comment it again. 
--Uncomment, highight create database, then comment over and run query

-- CREATE DATABASE [GamingPlatform]

--Creating Person Table
CREATE TABLE [Person] (
    [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
    [AuthorizationID] nvarchar(450)
);

CREATE TABLE [Game] (
    [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
    [Title]           NVARCHAR(64),
    [Description]     NVARCHAR(526),
    [YearPublished]   INT,
    [ESRBRatingID]    INT,
    [AverageRating]   FLOAT,
    [CoverPicture]    NVARCHAR(526)  
);

CREATE TABLE [ListKind] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [Kind] NVARCHAR(50);
);

CREATE TABLE [PersonList] (
    [ID] INT PRIMARY KEY IDENTITY (1,1),
    [PersonID] INT NOT NULL,
    [ListKindID] INT, 
    [ListKind] NVARCHAR(50),
    CONSTRAINT [FK_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Person]([ID]),
    CONSTRAINT [FK_ListKindID] FOREIGN KEY ([ListKindID]) REFERENCES [ListKind]([ID])
);

CREATE TABLE [PersonGame] (
    [ID] INT PRIMARY KEY IDENTITY (1,1),
    [PersonListID] INT NOT NULL,
    [GameID] INT NOT NULL,
    CONSTRAINT [FK_PersonListID] FOREIGN KEY ([PersonListID]) REFERENCES [PersonList] ([ID]),
    CONSTRAINT [FK_GameID] FOREIGN KEY ([GameID]) REFERENCES [Game] ([ID])
);

-- CREATE TABLE [GamePlayListType] (
--     [ID] INT PRIMARY KEY IDENTITY(1,1),
--     [ListKind] NVARCHAR(64)
-- );

-- CREATE TABLE [ListName] (
--     [ID] INT PRIMARY KEY IDENTITY(1,1),
--     [NameOfList] NVARCHAR(64) 
-- )

-- CREATE TABLE [PersonGameList] (
--     [ID] INT PRIMARY KEY IDENTITY(1,1),
--     [PersonID] INT NOT NULL, --Had to make FK nullable
--     [GameID] INT,
--     [ListKindID] INT NOT NULL,
--     [ListNameID] INT NOT NULL,
--     CONSTRAINT [FK_PersonID] FOREIGN KEY ([PersonId]) REFERENCES [Person]([ID]),
--     CONSTRAINT [FK_GameID] FOREIGN KEY ([GameID]) REFERENCES [Game]([ID]),
--     CONSTRAINT [FK_ListKindID] FOREIGN KEY ([ListKindID]) REFERENCES [GamePlayListType]([ID]),
--     CONSTRAINT [FK_ListNameID] FOREIGN KEY ([ListNameID]) REFERENCES [ListName]([ID])
-- );