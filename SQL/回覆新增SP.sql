CREATE PROCEDURE spAddReply
    (
      @UserId INT ,
      @MessageId INT ,
      @UserName NVARCHAR(20) , 
      @Context NVARCHAR(200) , 
      @CreatDate DateTime
    )
AS
    BEGIN  
--	ALTER TABLE [Message]
--ADD FOREIGN KEY (UserId)
--REFERENCES [User](Id)
        INSERT  INTO [Reply]
        VALUES  ( @UserId,@MessageId, @UserName, @Context, getdate() );  
    END;
GO
