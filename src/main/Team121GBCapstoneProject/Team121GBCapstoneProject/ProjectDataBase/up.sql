--Note: Only Run The create database once and then comment it again. 
--Uncomment, highight create database, then comment over and run query

-- CREATE DATABASE [GamingPlatform]

--Creating Person Table
CREATE TABLE [Person] (
    [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
    [AuthorizationID] INT,   
);

CREATE TABLE [Game] (
    [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
    [Title]           NVARCHAR(64),
    [Description]     NVARCHAR(526),
    [YearPublished]   INT,
    [ESRBRatingID]    INT,
    [AverageRating]   FLOAT,
    [CoverPicture]    NVARCHAR(MAX),
    [IGDBUrl]         NVARCHAR(MAX)
);
CREATE TABLE [GamePlayListType] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [ListKind] NVARCHAR(64)
);

CREATE TABLE [ListName] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [NameOfList] NVARCHAR(64) 
)

CREATE TABLE [PersonGameList] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [PersonID] INT NOT NULL, --Had to make FK nullable
    [GameID] INT,
    [ListKindID] INT NOT NULL,
    [ListNameID] INT NOT NULL,
    CONSTRAINT [FK_PersonID] FOREIGN KEY ([PersonId]) REFERENCES [Person]([ID]),
    CONSTRAINT [FK_GameID] FOREIGN KEY ([GameID]) REFERENCES [Game]([ID]),
    CONSTRAINT [FK_ListKindID] FOREIGN KEY ([ListKindID]) REFERENCES [GamePlayListType]([ID]),
    CONSTRAINT [FK_ListNameID] FOREIGN KEY ([ListNameID]) REFERENCES [ListName]([ID])
);

CREATE TABLE [Genre] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL
);

CREATE TABLE [GameGenre] (
    [GameID] INT NOT NULL,
    [GenreID] INT NOT NULL,
    CONSTRAINT [FK_GameGenreID] FOREIGN KEY ([GameID]) REFERENCES [Game]([ID]),
    CONSTRAINT [FK_GenreID] FOREIGN KEY ([GenreID]) REFERENCES [Genre]([ID])
)

CREATE TABLE [Platform] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    NAME NVARCHAR(64) NOT NULL
)

CREATE TABLE [GamePlatform] (
    [GameID] INT NOT NULL,
    [PlatformID] INT NOT NULL,
    CONSTRAINT [FK_GamePlatformID] FOREIGN KEY ([GameID]) REFERENCES [Game]([ID]),
    CONSTRAINT [FK_PlatformID] FOREIGN KEY ([PlatformID]) REFERENCES [Platform]([ID])
)