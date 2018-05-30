CREATE PROCEDURE spSaveMessage
    (
	  @Id int,
      @UserId int, 
      @UserName NVARCHAR(20) ,
      @Context NVARCHAR(100) , 
      @CreatDate DateTime 
    )
AS
    BEGIN      
        UPDATE  [Message]
        SET     UserName = @UserName ,
				Context  = @Context ,
                CreatDate = getdate() ,

        WHERE   UserId = @UserId ; 
    END; 
GO

