USE [EmbraceHomeLoans]
GO
/****** Object:  Trigger [Live].[BackUpMenuDeleted]    Script Date: 11/27/2011 17:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [Live].[BackUpMenuDeleted] ON [Live].[Menus]
    AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    SET NOCOUNT ON ;

    -- Insert statements for trigger here
    INSERT  INTO [Backup].[Menus]
            ( [MenuNodeID]
            ,[Title]
            ,[PageAbsoluteUrl]
            ,[ParentNodeID]
            ,[LeafOridinal]
            ,[LeafLevel]
            ,[CategoryName]
            ,[ExcludeFromMenu]
            ,[IsArchive]
            ,[Date]
            ,[Action]
            )
            ( SELECT
                [MenuNodeID]
               ,[Title]
               ,[PageAbsoluteUrl]
               ,[ParentNodeID]
               ,[LeafOridinal]
               ,[LeafLevel]
               ,[CategoryName]
               ,[ExcludeFromMenu]
               ,[IsArchived]
               ,[Date]
               ,'deleted'
              FROM
                deleted
            )
END

