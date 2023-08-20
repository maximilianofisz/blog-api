CREATE TABLE Comments
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[BlogId] INT NOT NULL,
	[Body] NVARCHAR(MAX) NOT NULL,
	[CreatedBy]        INT NOT NULL,
    [CreatedDate]      DATETIME2 (7) DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   INT NULL,
    [LastModifiedDate] DATETIME2 (7) NULL,
    [DeletedBy]        INT NULL,
    [DeletedDate]      DATETIME2 (7) NULL,
    [Version]          ROWVERSION    NOT NULL,
	CONSTRAINT [PK_Comments_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Comments_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES Blogs([Id])
)