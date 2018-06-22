-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/22
-- Description:	登入檢查會員帳號密碼
-- =============================================
CREATE PROCEDURE usp_User_CheckLoginAccount_Get 
	( 
		@UserAccount NVARCHAR(50), 
		@Password NVARCHAR(20)  )
AS
    BEGIN
        SELECT  [Id],[UserAccount],[Password]
		FROM     [User]
		WHERE  UserAccount = @UserAccount and [Password] =@Password;
    END;
GO 
