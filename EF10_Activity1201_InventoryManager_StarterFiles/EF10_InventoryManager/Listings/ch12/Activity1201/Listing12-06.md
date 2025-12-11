# Listing 12-6: Create Mocks for the Generic methods - GetAllAsync

Set up the mock to return all Items when the `GetAllAsync` method is called

## The code

This mock sets up the call so that making a call to the repository for getting all items just returns the list of items as created earlier:

```cs
_mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_items.ToList());
```  

>**Note:** there are no parameters for the method so you don't need to add any parameters the `r.GetAllAsync()` method call.