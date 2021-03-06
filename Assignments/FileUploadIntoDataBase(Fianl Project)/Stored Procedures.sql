
ALTER procedure [dbo].[Proc_UploadSubFolder]( 
	@RootFolderId int,
	@Name nvarchar(50),
	@Path nvarchar(50),
    @CreatedBy nvarchar(50),
    @ModifiedBy nvarchar(50),  
    @CreatedOn datetime,
    @ModifiedOn datetime,
	@returnid int output
	)
as
begin
	insert into SubFolder( RootFolderId, Name,Path,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn) values(@RootFolderId,@Name,@Path,@CreatedBy,@ModifiedBy,@CreatedOn,@ModifiedOn)
	set @returnid=SCOPE_IDENTITY()
      return @returnid
end

ALTER procedure [dbo].[Proc_UploadRootFolder](
	@Name nvarchar(50),
	@Path nvarchar(50),
    @CreatedBy nvarchar(50),
    @ModifiedBy nvarchar(50),  
    @CreatedOn datetime,
    @ModifiedOn datetime,
	@returnid int output)
as
begin 
	insert into RootFolder( Name,Path,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn) 
	values(@Name,@Path,@CreatedBy,@ModifiedBy,@CreatedOn,@ModifiedOn)
	set @returnid=SCOPE_IDENTITY()
      return @returnid
end

ALTER procedure [dbo].[Proc_UploadFile](
	@SubFolderId int,
	@Name nvarchar(50),
	@Path nvarchar(50),
	@Type nvarchar(50),
	@Size nvarchar(50),
    @CreatedBy nvarchar(50),
    @ModifiedBy nvarchar(50),
    @FileAccessed datetime,
    @CreatedOn datetime,
    @ModifiedOn datetime,
    @IsFilePathOK bit,
    @IsFilesupported bit)
as
begin
	insert into FileInfo(SubFolderId,Name,Path,Type,Size,CreatedBy,ModifiedBy,FileAccessed,CreatedOn,ModifiedOn,IsFilePathOK,IsFilesupported) values(@SubFolderId,@Name,@Path,@Type,@Size,@CreatedBy,@ModifiedBy,@FileAccessed,@CreatedOn,@ModifiedOn,@IsFilePathOK,@IsFilesupported)
end