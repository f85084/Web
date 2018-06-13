-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	新增回覆資料
-- =============================================
CREATE PROCEDURE usp_Reply_Add
    (
      @UserId INT ,
      @MessageId INT ,
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
        INSERT  INTO [Reply]
        VALUES  ( @UserId,@MessageId, @UserName, @Context, getdate() ,@Delete);  
    END;
GO
