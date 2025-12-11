using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Moq;
using Shouldly;
using System.Linq.Expressions;

namespace EF10_InventoryManagerUnitTests;

public class TestCategoryService
{
    private readonly Mock<ICategoryRepository> _mockRepository;
    private readonly ICategoryService _service;
    private List<Category> _categories;

    public TestCategoryService()
    {
        // Create per-test copy of stub data to avoid shared state issues
        _categories = StaticTestingHelpers.Categories.Select(c => new Category
        {
            Id = c.Id,
            CategoryName = c.CategoryName,
            Items = c.Items?.Select(i => new Item { Id = i.Id, Name = i.Name, CategoryId = i.CategoryId }).ToList()
        }).ToList();

        _mockRepository = new Mock<ICategoryRepository>();

        // Setup generic methods
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_categories.ToList());
        _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => _categories.FirstOrDefault(c => c.Id == id));
        _mockRepository.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) => _categories.FirstOrDefault(c => c.CategoryName == name));
        _mockRepository.Setup(r => r.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category entity) =>
        {
            entity.Id = _categories.Max(c => c.Id) + 1;
            _categories.Add(entity);
            return true;
        });
        _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Category>())).ReturnsAsync((Category entity) =>
        {
            var existing = _categories.FirstOrDefault(c => c.Id == entity.Id);
            if (existing != null)
            {
                _categories.Remove(existing);
                _categories.Add(entity);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var existing = _categories.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                _categories.Remove(existing);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Category, bool>>>())).ReturnsAsync((Expression<Func<Category, bool>> predicate) => _categories.Where(predicate.Compile()).ToList());

        _service = new CategoryService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ReturnsAllCategories()
    {
        // Act
        var result = await _service.GetAllCategoriesAsync();

        // Assert
        result.Count().ShouldBe(2);
        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ReturnsCategoryWhenExists()
    {
        // Act
        var result = await _service.GetCategoryByIdAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        result.CategoryName.ShouldBe("Movie");
        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ReturnsNullWhenNotExists()
    {
        // Act
        var result = await _service.GetCategoryByIdAsync(999);

        // Assert
        result.ShouldBeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    [Fact]
    public async Task AddCategoryAsync_AddsAndReturnsCategory()
    {
        // Arrange
        var newCategory = new Category { CategoryName = "New Category" };

        // Act
        var result = await _service.AddCategoryAsync(newCategory);

        // Assert
        result.ShouldNotBeNull();
        result.CategoryName.ShouldBe("New Category");
        result.Id.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.AddAsync(It.Is<Category>(c => c.CategoryName == "New Category")), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsync_UpdatesAndReturnsCategory()
    {
        // Arrange
        var categoryToUpdate = new Category { Id = 1, CategoryName = "Updated Category" };

        // Act
        var result = await _service.UpdateCategoryAsync(categoryToUpdate);

        // Assert
        result.ShouldNotBeNull();
        result.CategoryName.ShouldBe("Updated Category");
        _mockRepository.Verify(r => r.UpdateAsync(It.Is<Category>(c => c.Id == 1 && c.CategoryName == "Updated Category")), Times.Once);
    }

    [Fact]
    public async Task DeleteCategoryAsync_DeletesAndReturnsCategory()
    {
        // Act
        var result = await _service.DeleteCategoryAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        _mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task FindCategoriesAsync_ReturnsMatchingCategories()
    {
        // Arrange
        Expression<Func<Category, bool>> predicate = c => c.CategoryName.Contains("Movie");

        // Act
        var result = await _service.FindCategoriesAsync(predicate);

        // Assert
        result.Count().ShouldBe(1);
        _mockRepository.Verify(r => r.FindAsync(predicate), Times.Once);
    }
}
