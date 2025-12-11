using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Moq;
using Shouldly;
using System.Linq.Expressions;

namespace EF10_InventoryManagerUnitTests;

public class TestContributorService
{
    private readonly Mock<IContributorRepository> _mockRepository;
    private readonly IContributorService _service;
    private List<Contributor> _contributors;
    private List<ItemContributor> _itemContributors;
    private List<Item> _items;

    public TestContributorService()
    {
        // Create per-test copies of stub data to avoid shared state issues
        _contributors = StaticTestingHelpers.Contributors.Select(con => new Contributor
        {
            Id = con.Id,
            ContributorName = con.ContributorName,
            ItemContributors = con.ItemContributors?.Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId }).ToList()
        }).ToList();
        _itemContributors = StaticTestingHelpers.ItemContributors.Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId }).ToList();
        _items = StaticTestingHelpers.Items.Select(i => new Item { Id = i.Id, Name = i.Name }).ToList();

        // Assign reverse links for copies
        foreach (var contributor in _contributors)
        {
            if (contributor.ItemContributors != null)
            {
                foreach (var ic in contributor.ItemContributors)
                {
                    ic.Contributor = contributor;
                    ic.Item = _items.FirstOrDefault(it => it.Id == ic.ItemId);
                }
            }
        }

        _mockRepository = new Mock<IContributorRepository>();

        // Setup generic methods
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_contributors.ToList());
        _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => _contributors.FirstOrDefault(c => c.Id == id));
        _mockRepository.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) => _contributors.FirstOrDefault(c => c.ContributorName == name));
        _mockRepository.Setup(r => r.AddAsync(It.IsAny<Contributor>())).ReturnsAsync((Contributor entity) =>
        {
            entity.Id = _contributors.Max(c => c.Id) + 1;
            _contributors.Add(entity);
            return true;
        });
        _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Contributor>())).ReturnsAsync((Contributor entity) =>
        {
            var existing = _contributors.FirstOrDefault(c => c.Id == entity.Id);
            if (existing != null)
            {
                _contributors.Remove(existing);
                _contributors.Add(entity);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var existing = _contributors.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                _contributors.Remove(existing);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Contributor, bool>>>())).ReturnsAsync((Expression<Func<Contributor, bool>> predicate) => _contributors.Where(predicate.Compile()).ToList());

        // Setup custom methods
        _mockRepository.Setup(r => r.AddRangeAsync(It.IsAny<List<Contributor>>())).ReturnsAsync((List<Contributor> contributorsToAdd) =>
        {
            int addedCount = 0;
            foreach (var contrib in contributorsToAdd)
            {
                contrib.Id = _contributors.Max(c => c.Id) + 1;
                _contributors.Add(contrib);
                addedCount++;
            }
            return addedCount;
        });
        _mockRepository.Setup(r => r.GetContributorByNameWithItemsAsync(It.IsAny<string>())).ReturnsAsync((string name) =>
        {
            var contributor = _contributors.FirstOrDefault(c => c.ContributorName == name);
            if (contributor != null)
            {
                contributor.ItemContributors = _itemContributors.Where(ic => ic.ContributorId == contributor.Id).ToList();
                foreach (var ic in contributor.ItemContributors ?? new List<ItemContributor>())
                {
                    ic.Item = _items.FirstOrDefault(i => i.Id == ic.ItemId);
                }
            }
            return contributor;
        });

        _service = new ContributorService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllContributorsAsync_ReturnsAllContributors()
    {
        // Act
        var result = await _service.GetAllContributorsAsync();

        // Assert
        result.Count().ShouldBe(15);
        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetContributorByIdAsync_ReturnsContributorWhenExists()
    {
        // Act
        var result = await _service.GetContributorByIdAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        result.ContributorName.ShouldBe("Tom Hanks");
        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetContributorByIdAsync_ReturnsNullWhenNotExists()
    {
        // Act
        var result = await _service.GetContributorByIdAsync(999);

        // Assert
        result.ShouldBeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    [Fact]
    public async Task AddContributorAsync_AddsAndReturnsContributor()
    {
        // Arrange
        var newContributor = new Contributor { ContributorName = "New Contributor" };

        // Act
        var result = await _service.AddContributorAsync(newContributor);

        // Assert
        result.ShouldNotBeNull();
        result.ContributorName.ShouldBe("New Contributor");
        result.Id.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.AddAsync(It.Is<Contributor>(c => c.ContributorName == "New Contributor")), Times.Once);
    }

    [Fact]
    public async Task UpdateContributorAsync_UpdatesAndReturnsContributor()
    {
        // Arrange
        var contributorToUpdate = new Contributor { Id = 1, ContributorName = "Updated Contributor" };

        // Act
        var result = await _service.UpdateContributorAsync(contributorToUpdate);

        // Assert
        result.ShouldNotBeNull();
        result.ContributorName.ShouldBe("Updated Contributor");
        _mockRepository.Verify(r => r.UpdateAsync(It.Is<Contributor>(c => c.Id == 1 && c.ContributorName == "Updated Contributor")), Times.Once);
    }

    [Fact]
    public async Task DeleteContributorAsync_DeletesAndReturnsContributor()
    {
        // Act
        var result = await _service.DeleteContributorAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        _mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task FindContributorsAsync_ReturnsMatchingContributors()
    {
        // Arrange
        Expression<Func<Contributor, bool>> predicate = c => c.ContributorName.Contains("Tom Hanks");

        // Act
        var result = await _service.FindContributorsAsync(predicate);

        // Assert
        result.Count().ShouldBe(1);
        _mockRepository.Verify(r => r.FindAsync(predicate), Times.Once);
    }

    [Fact]
    public async Task AddRangeAsync_AddsMultipleContributors()
    {
        // Arrange
        var contributorsToAdd = new List<Contributor>
        {
            new Contributor { ContributorName = "Bulk1" },
            new Contributor { ContributorName = "Bulk2" }
        };

        // Act
        var result = await _service.AddRangeAsync(contributorsToAdd);

        // Assert
        result.ShouldBe(2);
        _mockRepository.Verify(r => r.AddRangeAsync(contributorsToAdd), Times.Once);
    }

    [Fact]
    public async Task GetContributorByNameWithItemsAsync_ReturnsContributorWithItems()
    {
        // Act
        var result = await _service.GetContributorByNameWithItemsAsync("Tom Hanks");

        // Assert
        result.ShouldNotBeNull();
        result.ContributorName.ShouldBe("Tom Hanks");
        result.ItemContributors.ShouldNotBeNull();
        result.ItemContributors.Count.ShouldBeGreaterThan(0);
        result.ItemContributors.ShouldAllBe(ic => ic.Item != null);
        _mockRepository.Verify(r => r.GetContributorByNameWithItemsAsync("Tom Hanks"), Times.Once);
    }
}
