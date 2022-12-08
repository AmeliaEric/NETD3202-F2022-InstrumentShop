CREATE TABLE [dbo].[Instruments] (
    [instrumentID]   INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (MAX) NOT NULL,
    [manufacturerID] INT            NOT NULL,
    [type]           NVARCHAR (MAX) NOT NULL,
    [color]          NVARCHAR (MAX) NOT NULL,
    [quantityBought] INT            NOT NULL,
    [priceSold]      FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Instruments] PRIMARY KEY CLUSTERED ([instrumentID] ASC),
	FOREIGN KEY (manufacturerID) REFERENCES Manufacturers (manufacturerID)
);

