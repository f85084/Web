CREATE PROCEDURE spSaveUser
    (
	  @Id int,
      @UserId int, 
      @UserClass NVARCHAR , 
      @Email NVARCHAR(50) , 
      @Password NVARCHAR(30) , 
      @UserName NVARCHAR(20) , 
      @CreatDate DateTime , 
      @MofiyDate DateTime 
    )
AS
    BEGIN      
        UPDATE  [User]
        SET     UserAccount = @UserAccount ,
                UserClass = @UserClass ,
				Email = @Email ,
				Password = @Password ,
				UserName = @UserName ,
                CreatDate = getdate() ,
				MofiyDate = getdate()

        WHERE   Id = @Id; 
    END; 
GO