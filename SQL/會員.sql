CREATE TABLE [User]   
    (   
      Id INT PRIMARY KEY  IDENTITY(1, 1)   NOT NULL ,   
      UserAccount NVARCHAR(50) NOT NULL ,  
      UserClass tinyint NOT NULL ,   
      Email  NVARCHAR(50) NOT NULL ,   
      Password NVARCHAR(20) NOT NULL ,  
      UserName NVARCHAR(20) NOT NULL ,  
      CreatDate Datetime NULL ,         
      MofiyDate Datetime NULL,   
	  [Delete] bit NOT NULL ,
    );   

GO  