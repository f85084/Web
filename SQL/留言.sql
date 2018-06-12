CREATE TABLE [Message]

    (  
      Id INT PRIMARY KEY  IDENTITY(1, 1)  NOT NULL ,  
      UserId int  NULL ,  
      UserName NVARCHAR(20) NOT NULL ,  
      Context NVARCHAR(200) NOT NULL ,  
      CreatDate Datetime NOT NULL , 
	  [Delete] bit NOT NULL ,        
    );  

GO 