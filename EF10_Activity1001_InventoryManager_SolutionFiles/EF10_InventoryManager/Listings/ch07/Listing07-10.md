
# Listing 7-10: The command to add a new Migration

Leverage the correct command to create a new migration in your solution.  Note the name of the migration should be similar to `create-ItemsByGenre-procedure,` but truly you can name it whatever you want to name it.

## The command to add a migration

### VSCODE  

The code to add the migration from VSCode at the solution root level is: 

```bash
dotnet ef migrations add create-ItemsByGenre-procedure --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager  
```  

or, from the startup (console) project folder:

```bash
dotnet ef migrations add create-ItemsByGenre-procedure --project ../EF10_InventoryDBLibrary 

>**Note:** This command assumes you are one level above the project folder as well as the DBLibrary folder and the Models folder

### Visual Studio  

The code to add the migration from Visual Studio is:

```bash
add-migration create-ItemsByGenre-procedure
```  

>**Note:** In VS, make sure you have selected the DBLibrary project from the dropdown to avoid an error for `No DbContext Found`.  
