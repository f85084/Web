-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	讀取留言資料
-- =============================================
CREATE PROCEDURE usp_MessageRely_Get
AS
    BEGIN
		SET NOCOUNT ON;

        SELECT  [Id],[UserId],[UserName],[Context],[CreatDate],[Delete]
        FROM    [Message]
		left outer join Reply 
		on Message.Id = Reply.MessageId
		order by Message.Id;
    END;
GO 


