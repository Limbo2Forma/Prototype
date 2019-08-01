CREATE PROCEDURE GetEventDetailFromEventID (
	@EventID INT
)
AS
BEGIN
	SELECT * FROM dbo.EventDetail 
	WHERE dbo.Event.ID = @EventID
	AND dbo.Event.ID = dbo.EventDetail.EventID
END