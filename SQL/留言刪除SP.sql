CREATE PROCEDURE spDeleteMessage ( @Id int )
AS
    BEGIN
        DELETE  FROM Message
        WHERE   Id = @Id;
    END;
GO 