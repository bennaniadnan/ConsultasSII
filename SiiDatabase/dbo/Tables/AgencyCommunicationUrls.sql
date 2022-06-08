CREATE TABLE [dbo].[AgencyCommunicationUrls]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Agency] VARCHAR(10) NOT NULL, 
    [DocumentType] VARCHAR(10) NOT NULL, 
    [Url] VARCHAR(256) NOT NULL,
    CONSTRAINT [UQ_UniqueAgencyDocumentType] UNIQUE ([Agency], [DocumentType])
)