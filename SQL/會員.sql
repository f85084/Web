CREATE TABLE "User"   

    (   

      Id INT PRIMARY KEY   

             IDENTITY(1, 1)   

             NOT NULL ,   

      UserAccount NVARCHAR(100) NOT NULL ,   

      UserClass tinyint NOT NULL ,   

      Email  NVARCHAR(50) NOT NULL ,   

      Password NVARCHAR(50) NOT NULL ,  

      UserName NVARCHAR(20) NOT NULL ,  

      CreatDate Datetime NOT NULL ,         

      MofiyDate Datetime NULL,   

    );   

GO  