CREATE TABLE [Blogs]
(
	[Id] INT NOT NULL IDENTITY (1, 1), 
    [Title] VARCHAR(150) NOT NULL,
	[Body] NVARCHAR(MAX) NOT NULL,
	[CreatedBy]        INT NOT NULL,
    [CreatedDate]      DATETIME2 (7) DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   INT NULL,
    [LastModifiedDate] DATETIME2 (7) NULL,
    [DeletedBy]        INT NULL,
    [DeletedDate]      DATETIME2 (7) NULL,
    [Version]          ROWVERSION    NOT NULL,
	CONSTRAINT [PK_Blogs_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Blogs_Users_AuthorId] FOREIGN KEY (CreatedBy) REFERENCES Users([Id])
)