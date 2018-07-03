-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	§R°£¯d¨¥
-- =============================================
CREATE PROCEDURE usp_Message_Delete
    (
	  @Id int,
	  @Delete bit
    )
AS
    BEGIN      
                UPDATE  [Message]
        SET     
				[Delete] = @Delete

        WHERE   Id = @Id; 
    END; 
GO