-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: 讀取留言資料

-- =============================================
CREATE PROCEDURE msp_GetMessage
AS
    BEGIN
        SELECT  *
        FROM    "Message";
    END;
GO 