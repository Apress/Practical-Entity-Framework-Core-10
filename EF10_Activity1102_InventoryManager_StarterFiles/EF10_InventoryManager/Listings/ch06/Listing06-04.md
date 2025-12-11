# Listing 6-4: Get a Single Category By Id using SingleOrDefaultAsync LINQ.

The ability to get a Category from the database by passing in the Id key field.

## The Method Declaration

Retrieve a single category by Id using the SingleOrDefaultAsync method with a predicate to filter by the id.

1. The final method code.

	```cs
	private async Task GetCategoryById_SingleOrDefault() 
    {
        return await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
    }
	```  

## Update the method

Find the `TODO` item for updating Listing 6-4.  It is located in the `ReadOperationsMenu.cs` file in the method `GetCategoryById_SingleOrDefault`.


1. Replace the code

	Replace:  

	```cs
	throw new NotImplementedException();
	```  

	With

	```cs
	return await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
    ```  

## End

This concludes Listing 6-3.


private async Task GetCategoryById_SingleOrDefault() 
    {
        /* TODO: Update with code from Listing 6-4  */
        throw new NotImplementedException();
    }