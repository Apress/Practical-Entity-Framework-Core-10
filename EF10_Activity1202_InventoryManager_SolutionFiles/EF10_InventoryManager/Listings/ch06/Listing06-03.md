# Listing 6-3: Get a Single Category By Id

The ability to get a Category from the database by passing in the Id key field.

## The Method Declaration

Retrieve a single category by Id using the `Find` method from `DbSet`.

1. The final method code 

	```cs
	public async Task<Category> GetCategoryById_Find(int id)
	{
		return await _db.Categories.FindAsync(id);
	}
	```  

## Update the method

Find the `TODO` item for updating Listing 6-3.  It is located in the `ReadOperationsMenu.cs` file in the method `GetCategoryById_Find`.

1. Replace the code

	Replace:  

	```cs
	throw new NotImplementedException();
	```  

	With

	```cs
	return await _db.Categories.FindAsync(id);
	```  

## End

This concludes Listing 6-3.