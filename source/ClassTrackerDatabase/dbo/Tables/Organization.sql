CREATE TABLE [dbo].[Organization] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Organization] PRIMARY KEY CLUSTERED ([Id] ASC)
);

