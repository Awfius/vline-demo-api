CREATE TABLE [VLine-DB].dbo.Timetables (
		ID varchar(64) PRIMARY KEY NOT NULL,  
		DepartStation varchar(255) NOT NULL,
		ArrivalStation varchar(255) NOT NULL,
		DepartDateTime DateTime NULL,
		ArrivalDateTime DateTime NULL
	)  
GO