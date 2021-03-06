/*
   Sunday, 17 July 20162:22:57 PM
   User: 
   Server: PROMETHEUS\BGRADESOFTWARE
   Database: ContentManagementSystem
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PageContent
	DROP CONSTRAINT DF_PageContent_DateUpdated
GO
CREATE TABLE dbo.Tmp_PageContent
	(
	PageContentId int NOT NULL IDENTITY (1, 1),
	PageId int NOT NULL,
	ModelType nvarchar(150) NOT NULL,
	Title nvarchar(150) NOT NULL,
	[Content] ntext NOT NULL,
	LastEditedByUserId int NOT NULL,
	PublishStatus int NOT NULL,
	UTCDateUpdated datetime2(2) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PageContent SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_PageContent ADD CONSTRAINT
	DF_PageContent_ModelType DEFAULT N'Default' FOR ModelType
GO
ALTER TABLE dbo.Tmp_PageContent ADD CONSTRAINT
	DF_PageContent_DateUpdated DEFAULT (getutcdate()) FOR UTCDateUpdated
GO
SET IDENTITY_INSERT dbo.Tmp_PageContent ON
GO
IF EXISTS(SELECT * FROM dbo.PageContent)
	 EXEC('INSERT INTO dbo.Tmp_PageContent (PageContentId, PageId, Title, [Content], LastEditedByUserId, PublishStatus, UTCDateUpdated)
		SELECT PageContentId, PageId, Title, [Content], LastEditedByUserId, PublishStatus, UTCDateUpdated FROM dbo.PageContent WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PageContent OFF
GO
DROP TABLE dbo.PageContent
GO
EXECUTE sp_rename N'dbo.Tmp_PageContent', N'PageContent', 'OBJECT' 
GO
ALTER TABLE dbo.PageContent ADD CONSTRAINT
	PK_PageContent PRIMARY KEY CLUSTERED 
	(
	PageContentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
