# Listing 7-5: A Query to Get All Items from the Database by Category

Test the query in SSMS to validate that it works as epected with various inputs before creating the new procedure 

## The T-SQL Query

Open SSMS and run the following query.  Tweak it to your desire to model expected output - just make sure that you update the DTO definition (See Activity 7-1, Exercise 4) to match any changes you make here.

## The T-SQL

Use the following T-SQL to validate the expected results from your database.

```sql
DECLARE @genreName NVARCHAR(50) = 'Action'
DECLARE @isActive BIT = 1
SELECT 
    i.Id AS ItemId,                 
    i.Name AS ItemName,             
    g.Id AS GenreId, 
    i.Description AS ItemDescription,
    g.GenreName,
    i.IsActive
FROM Genres g
INNER JOIN ItemGenres ig on g.id = ig.GenreId
INNER JOIN Items i ON ig.ItemId = i.Id
WHERE g.GenreName = @genreName
AND i.IsActive = @isActive
```  

>**Note**: Use different values for @genreName to get results.