﻿CREATE TABLE [dbo].[Book]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(250) NOT NULL,
	[Description] VARCHAR(MAX) NOT NULL,
	[AuthorId] INT NOT NULL,
	[Created] DATETIME2 NULL
	CONSTRAINT FK_Book_Author FOREIGN KEY (AuthorId)
		REFERENCES [Author](AuthorId)
)