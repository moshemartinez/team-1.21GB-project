--Note: Only Run The create database once and then comment it again. 
--Uncomment, highight create database, then comment over and run query
--  DROP DATABASE [GamingPlatform]
--  CREATE DATABASE [GamingPlatform]

--Creating Person Table
CREATE TABLE [Person] (
    [ID]              INT           PRIMARY KEY IDENTITY(1, 1),
    [AuthorizationID] NVARCHAR(450),
    [RoleID]          INT,
    [CurrentlyPlayingListID] INT,
    [CompletedListID] INT,
    [WantToPlayListID] INT
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

CREATE TABLE [List] (
    [ID] INT PRIMARY KEY IDENTITY(1,1),
    [Title] NVARCHAR(64),
    [PersonId] INT NOT NULL,
    CONSTRAINT [FK_GameList_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([ID])
);

CREATE TABLE [GameList] (
    [ListID] INT,
    [GameID] INT,
    CONSTRAINT [FK_GameList_List] FOREIGN KEY ([ListID]) REFERENCES [List]([ID]),
    CONSTRAINT [FK_GameList_Game] FOREIGN KEY ([GameID]) REFERENCES [Game]([ID]),
    CONSTRAINT [PK_GameList] PRIMARY KEY CLUSTERED ([ListID] ASC, [GameID] ASC)
);

ALTER TABLE [Person] ADD CONSTRAINT [FK_CurrentlyPlayingList] FOREIGN KEY ([CurrentlyPlayingListID]) REFERENCES [List]([ID]);
ALTER TABLE [Person] ADD CONSTRAINT [FK_CompletedList] FOREIGN KEY ([CompletedListID]) REFERENCES [List]([ID]);
ALTER TABLE [Person] ADD CONSTRAINT [FK_WantToPlayList] FOREIGN KEY ([WantToPlayListID]) REFERENCES [List]([ID]);
