-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: 讀取回覆資料

-- =============================================
CREATE PROCEDURE msp_GetReply
AS
    BEGIN
        SELECT  *
        FROM    "Reply";
    END;
GO 