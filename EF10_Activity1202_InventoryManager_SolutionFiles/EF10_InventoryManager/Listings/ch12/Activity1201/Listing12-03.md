# Listing 12-3: Create the Lists for Mocked Responses

The system will need to be able to return data for `Items`, `Categories`, `Genres`, `Contributors`, and the join for `Items` to those tables.

## The Code

Create `List<T>` object variables for each of the major tables (`Item`, `Genre`, `Category`, `Contributor`, ItemContr`ibutor). Replace the line `//TODO: add Lists here` from Listing 12=1 with the following:

```cs
private List<Item> _items;
private List<Genre> _genres;
private List<Category> _categories;
private List<Contributor> _contributors;
private List<ItemContributor> _itemContributors;
```  
