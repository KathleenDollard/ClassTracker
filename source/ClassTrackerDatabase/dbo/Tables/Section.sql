CREATE TABLE [dbo].[Section] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Course_Id]     INT NULL,
    [Instructor_Id] INT NULL,
    [Term_Id]       INT NULL,
    CONSTRAINT [PK_dbo.Section] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Section_dbo.Course_Course_Id] FOREIGN KEY ([Course_Id]) REFERENCES [dbo].[Course] ([Id]),
    CONSTRAINT [FK_dbo.Section_dbo.Instructor_Instructor_Id] FOREIGN KEY ([Instructor_Id]) REFERENCES [dbo].[Instructor] ([Id]),
    CONSTRAINT [FK_dbo.Section_dbo.Term_Term_Id] FOREIGN KEY ([Term_Id]) REFERENCES [dbo].[Term] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Course_Id]
    ON [dbo].[Section]([Course_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Instructor_Id]
    ON [dbo].[Section]([Instructor_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Term_Id]
    ON [dbo].[Section]([Term_Id] ASC);

