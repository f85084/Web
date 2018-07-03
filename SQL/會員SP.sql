CREATE PROCEDURE spAddUser
    (
      @UserAccount NVARCHAR(30) , 
      @UserClass NVARCHAR , 
      @Email NVARCHAR(50) , 
      @Password NVARCHAR(30) , 
      @UserName NVARCHAR(20) , 
      @CreatDate DateTime , 
      @MofiyDate DateTime 
    )
AS
    BEGIN  
        INSERT  INTO "User" 

        VALUES  ( @UserAccount, @UserClass, @Email, @Password, @UserName, getdate(), getdate()  ) 
    END;
GO 

