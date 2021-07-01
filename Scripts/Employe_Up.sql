USE C000001103  


CREATE TABLE Employe (
  EmployeID INT PRIMARY KEY IDENTITY (1,1),
  EmployeName VARCHAR (255) NOT NULL,
  RFC VARCHAR (50) NOT NULL,
  Salary DECIMAL(18,2),
  Active BIT
);
GO

CREATE PROCEDURE [dbo].[Employe_Update](   
 @EmployeID  INT,  
 @EmployeName VARCHAR(255),    
 @RFC VARCHAR(50),    
 @Salary DECIMAL(18,2),    
 @Active BIT )    
AS    
BEGIN    
 UPDATE Employe 
 SET EmployeName = @EmployeName,
	 RFC = @RFC,
	 Salary = @Salary,
	 Active = @Active
 WHERE EmployeID = @EmployeID

 RETURN @@ERROR  

END
GO

CREATE PROCEDURE [dbo].[Employe_Create](   
 @EmployeID  INT OUTPUT,  
 @EmployeName varchar(255),    
 @RFC varchar(50),    
 @Salary DECIMAL(18,2),    
 @Active BIT )    
AS    
BEGIN    
 DECLARE @ErrorID FolioID  
 INSERT INTO Employe (EmployeName, RFC, Salary, Active )    
 VALUES (@EmployeName, @RFC, @Salary, @Active )  

  SET @ErrorID = @@ERROR
  SET @EmployeID  = SCOPE_IDENTITY()  

   RETURN @ErrorID  
    
END
GO

