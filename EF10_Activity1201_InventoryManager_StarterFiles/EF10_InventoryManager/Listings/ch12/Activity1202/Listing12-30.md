# Listing 12-30: The Collection Attribute

The Collection Definition allows you to group all of your tests to only have to create the database one time for the entire run. Optionally, you can disable parallelization as I have here to keep tests from running in parallel.

## The Code

Adding the collection definition attribute will group your tests together and only create the database one time.   

```cs
[CollectionDefinition(nameof(DatabaseTestCollection), DisableParallelization = true)]
```  