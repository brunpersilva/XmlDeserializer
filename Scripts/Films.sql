-- Create Databse Films 
CREATE DATABASE Films;

-- Create Table Films
USE Films
CREATE TABLE Films (
    Id int NOT NULL UNIQUE IDENTITY,
    Title NVARCHAR(150) NOT NULL,
    Release_Date DATETIME2 NOT NULL,
	Studio nvarchar(150) NOT NULL,
	 PRIMARY KEY (Id)
);

--Create Stored Procedure to insert the data into the Films table
USE Films

GO

Create PROCEDURE spInsertFilms
	-- Parameters List
	@Id int,
	@Title nvarchar(100),
	@Release_Date datetime2(7),
	@Studio nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Allows Id to be directly inserted
	SET IDENTITY_INSERT films ON

    -- Insert Values that came as parameter into the appropriate columns
	insert into dbo.Films(Id, Title, Release_Date, Studio)
	values(@Id, @Title, @Release_Date, @Studio)

	--Remove permition to insert Id
	SET IDENTITY_INSERT films OFF
END