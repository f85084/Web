-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	讀取留言資料
-- =============================================
CREATE PROCEDURE usp_MessageRely_Get
AS
    BEGIN
		SET NOCOUNT ON;

SELECT*From (SELECT  Id Message_Id,
		UserId Message_UserId,
		UserName Message_UserName,
		Context Message_Context,
		CreatDate Message_CreatDate,
		[Delete] Message_Delete
		FROM    [Message]
		where [Delete]  = 0) AS [Message]
left outer join (SELECT 	Id Reply_Id,
		UserId Reply_UserId,
		MessageId Reply_MessageId,
		UserName Reply_UserName,
		Context Reply_Context,
		CreatDate Reply_CreatDate
		,[Delete] Reply_Delete
		FROM    Reply
		where  [Delete] = 0)  AS Reply 
		on [Message].Message_Id = Reply.Reply_MessageId
		order by Message.Message_Id;
    END;
GO 


