


CREATE TABLE RootFolder(
	[Id] [int] IDENTITY(1,1) primary key NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Path] [nvarchar](500) NULL unique,
	[CreatedBy] [nvarchar](100) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL)

	CREATE TABLE SubFolder(
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[RootFolderId] [int] NULL  FOREIGN KEY 
REFERENCES [dbo].[RootFolder] ([Id])
ON DELETE CASCADE,
	[Name] [nvarchar](100) NULL,
	[Path] [nvarchar](500) NULL unique,
	[CreatedBy] [nvarchar](100) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL)

	CREATE TABLE FileInfo(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubFolderId] [int] NULL foreign key references subfolder(id) on delete cascade,
	[Name] [nvarchar](100) NULL,
	[Path] [nvarchar](500) NULL unique,
	[Type] [varchar](100) NULL,
	[Size] [varchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[FileAccessed] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsFilePathOK] [bit] NULL,
	[IsFilesupported] [bit] NULL)

select * from RootFolder;
select * from SubFolder;
select * from FileInfo;
