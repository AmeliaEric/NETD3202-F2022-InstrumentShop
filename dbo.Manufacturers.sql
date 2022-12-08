CREATE TABLE [dbo].[Manufacturers] (
    [manufacturerID] INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (MAX) NOT NULL,
    [owner]          NVARCHAR (MAX) NOT NULL,
    [phone]          NVARCHAR (MAX) NOT NULL,
    [email]          NVARCHAR (MAX) NOT NULL,
    [address]        NVARCHAR (MAX) NOT NULL,
    [city]           NVARCHAR (MAX) NOT NULL,
    [province]       NVARCHAR (MAX) NOT NULL,
    [postalCode]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED ([manufacturerID] ASC)
);

