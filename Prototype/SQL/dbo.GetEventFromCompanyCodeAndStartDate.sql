CREATE PROCEDURE GetEventFromCompanyCodeAndStartDate (
		@CompanyCode varchar(10), -- the companycode of the company whom data is to be returned
		@Date datetime = null -- The date from 
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Event 
	WHERE CompanyCode = @CompanyCode 
	AND DATEDIFF(hour,@Date,StartDate) < 24
	AND DATEDIFF(hour,@Date,StartDate) > 0
	ORDER BY StartDate
END