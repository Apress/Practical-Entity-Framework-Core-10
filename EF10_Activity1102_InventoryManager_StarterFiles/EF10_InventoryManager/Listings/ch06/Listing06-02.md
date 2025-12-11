# Listing 6-2: Update the database

Use the terminal for VSCode or the Package Manager Console (PMC) for Visual studio to Update the Database

## Update Database VS Code

Navigate to the root level directory

1. Run the command

	```bash
	dotnet ef database update --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
	```  

## Update Database Visual Studio

Open the Package Manager Console from Tools -> NuGet Package Manager -> Package Manager Console

1. Run the command

	```PowerShell
	update-database
	```  

## End

This concludes Listing 6-2