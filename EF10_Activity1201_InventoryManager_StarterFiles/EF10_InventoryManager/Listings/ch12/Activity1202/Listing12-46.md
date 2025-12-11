# Listing 12-46: Opting out of using a transaction

Utilizing the hook to opt out of the transaction allows the method that has a transaction to be tested.

## The Code  

```cs
public TestItemRepositorySpecial(IntegrationTestFixture itf)
    : base(itf) 
{
    //Listing 12-46
    EnablePerTestTransaction = false; // Disable per-test transaction for this test class
}
```  