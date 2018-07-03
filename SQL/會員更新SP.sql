-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	編輯會員資料
-- =============================================
CREATE PROCEDURE usp_User_Update
    (
	  @Id int,
      @UserAccount NVARCHAR(50), 
      @UserClass tinyint , 
      @Email NVARCHAR(50) , 
      @Password NVARCHAR(30) , 
      @UserName NVARCHAR(20) , 
      @MofiyDate DateTime ,
	  @Delete bit
    )
AS
    BEGIN      
                UPDATE  [User]
        SET     UserAccount = @UserAccount ,
                UserClass = @UserClass ,
				Email = @Email ,
				Password = @Password ,
				UserName = @UserName ,
				MofiyDate = getdate(),
				[Delete] =@Delete

        WHERE   Id = @Id; 
    END; 
GO

