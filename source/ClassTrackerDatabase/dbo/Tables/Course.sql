CREATE TABLE [dbo].[Course] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CatalogNumber]   NVARCHAR (MAX) NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Organization_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Course] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Course_dbo.Organization_Organization_Id] FOREIGN KEY ([Organization_Id]) REFERENCES [dbo].[Organization] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Organization_Id]
    ON [dbo].[Course]([Organization_Id] ASC);

