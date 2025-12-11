using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using EF10_InventoryServiceLayer;
using Moq;
using Shouldly;
using System.Linq.Expressions;

namespace EF10_InventoryManagerUnitTests;

public class TestItemService
{
    //(Listing 12-1): Define the mocks and service to be used in the tests
    private readonly Mock<IItemRepository> _mockRepository;
    private readonly IItemService _service;
    // add Lists here
    private List<Item> _items;
    private List<Genre> _genres;
    private List<Category> _categories;
    private List<Contributor> _contributors;
    private List<ItemContributor> _itemContributors;

    public TestItemService()
    {
        //(Listing 12-2) Define the mocks and service to be used in the tests
        _mockRepository = new Mock<IItemRepository>();

        // Create per-test copies of stub data to avoid shared state issues
        //(Listings 12-4 through 12-15 follow):
        _genres = StaticTestingHelpers.Genres
                    .Select(g => new Genre { Id = g.Id, GenreName = g.GenreName, Items = new List<Item>() })
                    .ToList();
        _categories = StaticTestingHelpers.Categories
                        .Select(c => new Category { Id = c.Id, CategoryName = c.CategoryName, Items = new List<Item>() })
                        .ToList();
        _contributors = StaticTestingHelpers.Contributors
                            .Select(con => new Contributor
                            {
                                Id = con.Id,
                                ContributorName = con.ContributorName
                                ,
                                ItemContributors = new List<ItemContributor>()
                            })
                            .ToList();
        _itemContributors = StaticTestingHelpers.ItemContributors
                                .Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId })
                                .ToList();
        _items = StaticTestingHelpers.Items.Select(i => new Item
        {
            Id = i.Id,
            Name = i.Name,
            CategoryId = i.CategoryId,
            Category = _categories.FirstOrDefault(c => c.Id == i.CategoryId),
            Genres = i.Genres?.Select(g => _genres.FirstOrDefault(gg => gg.Id == g.Id)).ToList(),
            ItemContributors = i.ItemContributors?
                .Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId })
                .ToList()
        }).ToList();

        // Make sure relationships are set in both directions
        foreach (var category in _categories)
        {
            category.Items = _items.Where(i => i.CategoryId == category.Id).ToList();
        }
        foreach (var genre in _genres)
        {
            genre.Items = _items.Where(i => i.Genres != null && i.Genres.Any(g => g.Id == genre.Id)).ToList();
        }
        foreach (var contributor in _contributors)
        {
            contributor.ItemContributors = _itemContributors.Where(ic => ic.ContributorId == contributor.Id).ToList();
        }
        foreach (var item in _items)
        {
            if (item.ItemContributors != null)
            {
                foreach (var ic in item.ItemContributors)
                {
                    ic.Item = item;
                    ic.Contributor = _contributors.FirstOrDefault(c => c.Id == ic.ContributorId);
                }
            }
        }

        //Setup Mocks for the Generic Repository methods used in ItemService
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_items.ToList());
        _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) 
                                => _items.FirstOrDefault(i => i.Id == id));
        _mockRepository.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) 
                                => _items.FirstOrDefault(i => i.Name == name));

        _mockRepository.Setup(r => r.AddAsync(It.IsAny<Item>())).ReturnsAsync((Item entity) =>
        {
            entity.Id = _items.Max(i => i.Id) + 1;
            _items.Add(entity);
            return true;
        });

        _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Item>())).ReturnsAsync((Item entity) =>
        {
            var existing = _items.FirstOrDefault(i => i.Id == entity.Id);
            if (existing != null)
            {
                _items.Remove(existing);
                _items.Add(entity);
                return true;
            }
            return false;
        });

        _mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var existing = _items.FirstOrDefault(i => i.Id == id);
            if (existing != null)
            {
                _items.Remove(existing);
                return true;
            }
            return false;
        });

        _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Item, bool>>>()))
                                        .ReturnsAsync((Expression<Func<Item, bool>> predicate) 
                                        => _items.Where(predicate.Compile()).ToList());

        //Setup Mocks for the Custom Repository methods used in ItemService 
        _mockRepository.Setup(r => r.GetItemByNameWithCategoryAsync(It.IsAny<string>()))
                                        .ReturnsAsync((string name) => _items.FirstOrDefault(i => i.Name == name));
        _mockRepository.Setup(r => r.GetItemByNameWithGenreAsync(It.IsAny<string>()))
                                        .ReturnsAsync((string name) => _items.FirstOrDefault(i => i.Name == name));
        _mockRepository.Setup(r => r.GetItemByNameWithGenreByNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                                        .ReturnsAsync((string itemName, string genreName) 
                                        => _items.FirstOrDefault(i => i.Name == itemName && i.Genres != null 
                                                                && i.Genres.Any(g => g.GenreName == genreName)));
        _mockRepository.Setup(r => r.GetItemsByFilterAsync(It.IsAny<string>()))
                                        .ReturnsAsync((string filter) 
                                        => _items.Where(i => i.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList());
        _mockRepository.Setup(r => r.GetAllItemsWithCategoryAsync()).ReturnsAsync(_items.ToList());

        _mockRepository.Setup(r => r.UpdateRangeAsync(It.IsAny<List<Item>>())).ReturnsAsync((List<Item> itemsToUpdate) =>
        {
            int updatedCount = 0;
            foreach (var updatedItem in itemsToUpdate)
            {
                var existing = _items.FirstOrDefault(i => i.Id == updatedItem.Id);
                if (existing != null)
                {
                    _items.Remove(existing);
                    _items.Add(updatedItem);
                    updatedCount++;
                }
            }
            return updatedCount;
        });


        _mockRepository.Setup(r => r.BulkLoadItemDataAsync(It.IsAny<List<ParsedItemDataDTO>>())).ReturnsAsync((List<ParsedItemDataDTO> parsedItems) =>
        {
            foreach (var dto in parsedItems)
            {
                dto.Item.Id = _items.Max(i => i.Id) + 1;
                dto.Item.CategoryId = _categories.FirstOrDefault(c => c.Items.Any(i => i.Id == dto.Item.Id))?.Id ?? dto.Item.CategoryId;
                dto.Item.Genres = _genres.Where(g => dto.GenreIds.Contains(g.Id)).ToList();
                dto.Item.ItemContributors = dto.ContributorData.Select(cd => new ItemContributor
                {
                    ContributorId = cd.Key,
                    // Assuming the string is perhaps a role or something, but since not used in add, just create the link
                }).ToList();
                _items.Add(dto.Item);
            }
            return true;
        });

        //Initialize the service with the mocked repository
        _service = new ItemService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllItemsAsync_ReturnsAllItems()
    {
        //Test GetAllItemsAsync method (Listing 12-16)
        // Act
        var result = await _service.GetAllItemsAsync();

        // Assert
        result.Count.ShouldBe(20);
        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);

        //could also test specific items are contained, etc.
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsItemWhenExists()
    {
        //Test GetItemByIdAsync method when item exists  (Listing 12-17)
        // Act
        var result = await _service.GetItemByIdAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        result.Name.ShouldBe("Inception");
        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsNullWhenNotExists()
    {
        //Test GetItemByIdAsync method when item does not exist  (Listing 12-18)
        // Act
        var result = await _service.GetItemByIdAsync(999);

        // Assert
        result.ShouldBeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    [Fact]
    public async Task AddItemAsync_AddsAndReturnsItem()
    {
        //AddItemAsync method  (Listing 12-19)
        // Arrange
        var newItem = new Item { Name = "New Item", CategoryId = 1 };

        // Act
        var result = await _service.AddItemAsync(newItem);

        // Assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("New Item");
        result.Id.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.AddAsync(It.Is<Item>(i => i.Name == "New Item")), Times.Once);
    }

    [Fact]
    public async Task UpdateItemAsync_UpdatesAndReturnsItem()
    {
        //Test UpdateItemAsync method  (Listing 12-20)
        // Arrange
        var itemToUpdate = new Item { Id = 1, Name = "Updated Item", CategoryId = 1 };

        // Act
        var result = await _service.UpdateItemAsync(itemToUpdate);

        // Assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Updated Item");
        _mockRepository.Verify(r => r.UpdateAsync(It.Is<Item>(i => i.Id == 1 && i.Name == "Updated Item")), Times.Once);
    }

    [Fact]
    public async Task DeleteItemAsync_DeletesAndReturnsItem()
    {
        //Test DeleteItemAsync method (Listing 12-21)
        // Act
        var result = await _service.DeleteItemAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        _mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task FindItemsAsync_ReturnsMatchingItems()
    {
        //Test FindItemsAsync method (Listing 12-22)
        // Arrange
        Expression<Func<Item, bool>> predicate = i => i.Name.Contains("The");

        // Act
        var result = await _service.FindItemsAsync(predicate);

        // Assert
        result.Count.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.FindAsync(predicate), Times.Once);
    }

    [Fact]
    public async Task GetItemByNameWithCategoryAsync_ReturnsItemWithCategory()
    {
        //Test GetItemByNameWithCategoryAsync method   (Listing 12-23)
        // Act
        var result = await _service.GetItemByNameWithCategoryAsync("Inception");

        // Assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Inception");
        result.Category.ShouldNotBeNull();
        result.Category.CategoryName.ShouldBe("Movie");
        _mockRepository.Verify(r => r.GetItemByNameWithCategoryAsync("Inception"), Times.Once);
    }

    [Fact]
    public async Task GetItemByNameWithGenreAsync_ReturnsItemWithGenres()
    {
        //Test GetItemByNameWithGenreAsync method (Listing 12-24)
        // Act
        var result = await _service.GetItemByNameWithGenreAsync("Inception");

        // Assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Inception");
        result.Genres.ShouldNotBeNull();
        result.Genres.Count.ShouldBe(2);
        _mockRepository.Verify(r => r.GetItemByNameWithGenreAsync("Inception"), Times.Once);
    }

    [Fact]
    public async Task GetItemByNameWithGenreByNameAsync_ReturnsItemIfGenreMatches()
    {
        //Test GetItemByNameWithGenreByNameAsync method (Listing 12-25)
        // Act
        var result = await _service.GetItemByNameWithGenreByNameAsync("Inception", "Sci-Fi");

        // Assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Inception");
        _mockRepository.Verify(r => r.GetItemByNameWithGenreByNameAsync("Inception", "Sci-Fi"), Times.Once);
    }

    [Fact]
    public async Task GetItemsByFilterAsync_ReturnsFilteredItems()
    {
        //Test GetItemsByFilterAsync method (Listing 12-26)
        // Act
        var result = await _service.GetItemsByFilterAsync("The");

        // Assert
        result.Count.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.GetItemsByFilterAsync("The"), Times.Once);
    }

    [Fact]
    public async Task GetAllItemsWithCategoryAsync_ReturnsItemsWithCategories()
    {
        //Test GetAllItemsWithCategoryAsync method (Listing 12-27)
        // Act
        var result = await _service.GetAllItemsWithCategoryAsync();

        // Assert
        result.Count.ShouldBe(20);
        result.ShouldAllBe(i => i.Category != null);
        _mockRepository.Verify(r => r.GetAllItemsWithCategoryAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateRangeAsync_UpdatesMultipleItems()
    {
        //Test UpdateRangeAsync method (Listing 12-28)
        // Arrange
        var itemsToUpdate = new List<Item>
        {
            new Item { Id = 1, Name = "Updated1", CategoryId = 1 },
            new Item { Id = 2, Name = "Updated2", CategoryId = 1 }
        };

        // Act
        var result = await _service.UpdateRangeAsync(itemsToUpdate);

        // Assert
        result.ShouldBe(2);
        _mockRepository.Verify(r => r.UpdateRangeAsync(itemsToUpdate), Times.Once);
    }

    [Fact]
    public async Task BulkLoadItemDataAsync_LoadsItems()
    {
        //Test BulkLoadItemDataAsync method  (Listing 12-29)
        // Arrange
        var parsedItems = new List<ParsedItemDataDTO>
        {
            new ParsedItemDataDTO
            {
                Item = new Item { Name = "Bulk Item", CategoryId = 1 },
                GenreIds = new List<int> { 1 }, // Sci-Fi
                ContributorData = new Dictionary<int, string> { { 1, "Tom Hanks" } } // ContributorId to name or role
            }
        };

        // Act
        var result = await _service.BulkLoadItemDataAsync(parsedItems);

        // Assert
        result.ShouldBeTrue();
        _mockRepository.Verify(r => r.BulkLoadItemDataAsync(parsedItems), Times.Once);
    }
}
