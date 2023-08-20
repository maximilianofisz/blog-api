CREATE TABLE [Users]
(
	[Id] INT NOT NULL IDENTITY (1, 1), 
    [Name] VARCHAR(150) NOT NULL,
	[CreatedBy]        INT NOT NULL,
    [CreatedDate]      DATETIME2 (7) DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   INT NULL,
    [LastModifiedDate] DATETIME2 (7) NULL,
    [DeletedBy]        INT NULL,
    [DeletedDate]      DATETIME2 (7) NULL,
    [Version]          ROWVERSION    NOT NULL,
	CONSTRAINT [PK_Users_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)	