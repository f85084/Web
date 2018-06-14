-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	讀取留言資料
-- =============================================
CREATE PROCEDURE usp_MessageRely_Get
AS
    BEGIN
		SET NOCOUNT ON;

        SELECT  [Message].Id Message_Id,[Message].UserId Message_UserId,[Message].UserName Message_UserName,[Message].Context Message_Context,[Message].CreatDate Message_CreatDate,[Message].[Delete] Message_Delete,
		        Reply.Id Reply_Id,Reply.UserId Reply_UserId,Reply.MessageId Reply_MessageId,Reply.UserName Reply_UserName,Reply.Context Reply_Context,Reply.CreatDate Reply_CreatDate,Reply.[Delete] Reply_Delete
        FROM    [Message]
		left outer join Reply 
		on Message.Id = Reply.MessageId
		where [Message].[Delete]  = 0
		order by Message.Id;
    END;
GO 


