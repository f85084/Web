-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	新增會員資料
-- =============================================
CREATE PROCEDURE usp_User_Add
    (
      @UserAccount NVARCHAR(50) , 
      @UserClass tinyint , 
      @Email NVARCHAR(50) , 
      @Password NVARCHAR(20) , 
      @UserName NVARCHAR(20) , 
      @CreatDate DateTime , 
      @MofiyDate DateTime ,
	  @Delete bit
    )
AS
    BEGIN  
		if not exists(select Id from [User] where UserAccount=@UserAccount)
		begin
        INSERT  INTO [User] 
        VALUES  ( @UserAccount, @UserClass, @Email, @Password, @UserName, getdate(), getdate() , @Delete) 

		SET @Id = @@IDENTITY  
		end;
    END;
GO 

