CREATE TABLE [dbo].[Repairs] (
    [repairID]     INT            IDENTITY (1, 1) NOT NULL,
    [instrumentID] INT            NOT NULL,
    [owner]        NVARCHAR (MAX) NOT NULL,
    [phone]        NVARCHAR (MAX) NOT NULL,
    [email]        NVARCHAR (MAX) NOT NULL,
    [address]      NVARCHAR (MAX) NOT NULL,
    [city]         NVARCHAR (MAX) NOT NULL,
    [province]     NVARCHAR (MAX) NOT NULL,
    [postalCode]   NVARCHAR (MAX) NOT NULL,
	FOREIGN KEY (instrumentID) REFERENCES Instruments (instrumentID),
    CONSTRAINT [PK_Repairs] PRIMARY KEY CLUSTERED ([repairID] ASC)
);

