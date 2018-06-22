-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	讀取會員資料
-- =============================================
CREATE PROCEDURE usp_User_CheckAccount_Get ( @UserAccount NVARCHAR(50) )
AS
    BEGIN
        SELECT  [Id],[UserAccount]
		FROM     [User]
		WHERE  UserAccount = @UserAccount;
    END;
GO 
