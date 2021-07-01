

DECLARE @ID AS INT 
EXEC Employe_Create @EmployeID = @ID OUTPUT, 
	 @EmployeName = 'Alonso Lares',
	 @RFC = 'LAMA940810HBCRJL00',
	 @Salary = 100,
	 @Active = 1

PRINT @ID

EXEC Employe_Create @EmployeID = @ID OUTPUT, 
	 @EmployeName = 'Beatriz Baldenebro',
	 @RFC = 'LAMA940810HBCRJL11',
	 @Salary = 200,
	 @Active = 0

PRINT @ID

EXEC Employe_Create @EmployeID = @ID OUTPUT, 
	 @EmployeName = 'Jesus Firman',
	 @RFC = 'LAMA940810HBCRJL22',
	 @Salary = 300,
	 @Active = 0

PRINT @ID

EXEC Employe_Create @EmployeID = @ID OUTPUT, 
	 @EmployeName = 'Emilce Castillo',
	 @RFC = 'LAMA940810HBCRJL33',
	 @Salary = 400,
	 @Active = 1

PRINT @ID

EXEC Employe_Create @EmployeID = @ID OUTPUT, 
	 @EmployeName = 'Raul Ronkally',
	 @RFC = 'LAMA940810HBCRJL44',
	 @Salary = 500,
	 @Active = 1

PRINT @ID