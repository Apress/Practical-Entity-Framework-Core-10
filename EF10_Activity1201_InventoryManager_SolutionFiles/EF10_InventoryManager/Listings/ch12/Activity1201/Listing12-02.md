# Listing 12-2: Create the Mock ni the constructor

With the two variables in place, leverage the mock in the constructor and declare a new service object for testing.

## The Code

Add the following to the `TestItemService` constructor

```cs
_mockRepository = new Mock<IItemRepository>();

//TODO: Set up the mocks here that will be used independently in each test

_service = new ItemService(_mockRepository.Object);
```  

At this point, you *could* test the system, but it wouldn't do anything correctly since the mock data is not set up yet.