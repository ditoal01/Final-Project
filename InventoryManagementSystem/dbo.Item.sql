CREATE TABLE [dbo].[Item] (
    [Id]          INT           NOT NULL,
    [upc]         NVARCHAR (12) NOT NULL,
    [dept]        INT           NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [inventory]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

