CREATE TABLE [dbo].[Instructor] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [GivenName]       NVARCHAR (MAX) NULL,
    [SurName]         NVARCHAR (MAX) NULL,
    [Organization_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Instructor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Instructor_dbo.Organization_Organization_Id] FOREIGN KEY ([Organization_Id]) REFERENCES [dbo].[Organization] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Organization_Id]
    ON [dbo].[Instructor]([Organization_Id] ASC);

