# Listing 12-1: Set up the Local Variables for Mocking

The first thing you need is the Mock of the `IItemRepository`, and then you need the service to leverage the Mock as an injected object.

## The Code

Add the following to the top of the `TestItemService` where you find the `TODO: (Listing 12-1)...` comment.  

```cs
private readonly Mock<IItemRepository> _mockRepository;
private readonly IItemService _service;
//TODO: add Lists here
```  