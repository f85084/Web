-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	刪除留言資料
-- =============================================
CREATE PROCEDURE usp_Message_Delete ( @Id int )
AS
    BEGIN
        DELETE  FROM Message
        WHERE   Id = @Id;
    END;
GO 