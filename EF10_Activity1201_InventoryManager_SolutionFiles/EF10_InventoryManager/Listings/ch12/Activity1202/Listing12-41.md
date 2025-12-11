# Listing 12-41: Arranging and Acting for the AddAsync Test

Use the following code to arrange the system and act to add a new item

## The Code  

```cs
//Listing 12-41: Arrange and Act for AddAsync
var repo = new ItemRepository(_itf.Db);
var categoryRepo = new CategoryRepository(_itf.Db);
var genreRepo = new GenreRepository(_itf.Db);
var contributorRepo = new ContributorRepository(_itf.Db);

var movieCategory = await categoryRepo.GetByNameAsync("Movie");
var genres = await genreRepo.GetAllAsync();
var contributors = await contributorRepo.GetAllAsync();
var genre1 = genres
    .SingleOrDefault(x => x.GenreName == "Drama") ?? genres.FirstOrDefault();
var genre2 = genres
    .SingleOrDefault(x => x.GenreName == "Thriller") ?? genres.LastOrDefault();
var contributor1 = contributors
    .SingleOrDefault(x => x.ContributorName == "Christopher Nolan") 
    ?? contributors.FirstOrDefault();
var contributor2 = contributors
    .SingleOrDefault(x => x.ContributorName == "Chrisitan Bale") 
    ?? contributors.LastOrDefault();
var itemContributors = new List<ItemContributor>
{
    new ItemContributor { Contributor = contributor1
        , ContributorType = ContributorType.Director },
    new ItemContributor { Contributor = contributor2
        , ContributorType = ContributorType.Actor }
};
var Genres = new List<Genre> { genre1, genre2 };

var toAdd = new Item
{
    Name = "The Prestige"
    , CategoryId = movieCategory?.Id ?? 1
    , ItemContributors = itemContributors
    , Genres = Genres
    , Description = "A mind-bending thriller by Christopher Nolan"
    , IsActive = true
};
var result = await repo.AddAsync(toAdd);
```  