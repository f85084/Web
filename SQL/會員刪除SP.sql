CREATE PROCEDURE spDeleteUser ( @Id int )
AS
    BEGIN
        DELETE  FROM "User" 
        WHERE   Id = @Id;
    END;
GO