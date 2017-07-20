CREATE TABLE [dbo].[Term] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [StartDate]       DATETIME       NOT NULL,
    [EndDate]         DATETIME       NOT NULL,
    [Organization_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Term] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Term_dbo.Organization_Organization_Id] FOREIGN KEY ([Organization_Id]) REFERENCES [dbo].[Organization] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Organization_Id]
    ON [dbo].[Term]([Organization_Id] ASC);

