-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	新增留言資料
-- =============================================
CREATE PROCEDURE usp_Message_Add
    (
      @UserId INT ,
      @UserName NVARCHAR(20) , 
      @Context NVARCHAR(200) , 
      @CreatDate DateTime ,
	  @Delete bit
    )
AS
    BEGIN  
--	ALTER TABLE [Message]
--ADD FOREIGN KEY (UserId)
--REFERENCES [User](Id)
        INSERT  INTO [Message]
        VALUES  ( @UserId, @UserName, @Context, getdate() ,@Delete);  
    END;
GO
