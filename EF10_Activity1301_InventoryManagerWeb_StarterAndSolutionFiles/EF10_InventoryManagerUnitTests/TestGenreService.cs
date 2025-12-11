using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace EF10_InventoryManagerUnitTests;

public class TestGenreService
{
    private readonly Mock<IGenreRepository> _mockRepository;
    private readonly IGenreService _service;
    private List<Genre> _genres;

    public TestGenreService()
    {
        _mockRepository = new Mock<IGenreRepository>();

        // Create per-test copy of stub data to avoid shared state issues
        _genres = StaticTestingHelpers.Genres.Select(g => new Genre
        {
            Id = g.Id,
            GenreName = g.GenreName,
            Items = g.Items?.Select(i => new Item { Id = i.Id, Name = i.Name }).ToList()
        }).ToList();

        // Setup generic methods
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_genres.ToList());
        _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => _genres.FirstOrDefault(g => g.Id == id));
        _mockRepository.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) => _genres.FirstOrDefault(g => g.GenreName == name));
        _mockRepository.Setup(r => r.AddAsync(It.IsAny<Genre>())).ReturnsAsync((Genre entity) =>
        {
            entity.Id = _genres.Max(g => g.Id) + 1;
            _genres.Add(entity);
            return true;
        });
        _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Genre>())).ReturnsAsync((Genre entity) =>
        {
            var existing = _genres.FirstOrDefault(g => g.Id == entity.Id);
            if (existing != null)
            {
                _genres.Remove(existing);
                _genres.Add(entity);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var existing = _genres.FirstOrDefault(g => g.Id == id);
            if (existing != null)
            {
                _genres.Remove(existing);
                return true;
            }
            return false;
        });
        _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Genre, bool>>>())).ReturnsAsync((Expression<Func<Genre, bool>> predicate) => _genres.Where(predicate.Compile()).ToList());

        _service = new GenreService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllGenresAsync_ReturnsAllGenres()
    {
        // Act
        var result = await _service.GetAllGenresAsync();

        // Assert
        result.Count.ShouldBe(5);
        _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetGenreByIdAsync_ReturnsGenreWhenExists()
    {
        // Act
        var result = await _service.GetGenreByIdAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        result.GenreName.ShouldBe("Sci-Fi");
        _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetGenreByIdAsync_ReturnsNullWhenNotExists()
    {
        // Act
        var result = await _service.GetGenreByIdAsync(999);

        // Assert
        result.ShouldBeNull();
        _mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
    }

    [Fact]
    public async Task AddGenreAsync_AddsAndReturnsGenre()
    {
        // Arrange
        var newGenre = new Genre { GenreName = "New Genre" };

        // Act
        var result = await _service.AddGenreAsync(newGenre);

        // Assert
        result.ShouldNotBeNull();
        result.GenreName.ShouldBe("New Genre");
        result.Id.ShouldBeGreaterThan(0);
        _mockRepository.Verify(r => r.AddAsync(It.Is<Genre>(g => g.GenreName == "New Genre")), Times.Once);
    }

    [Fact]
    public async Task UpdateGenreAsync_UpdatesAndReturnsGenre()
    {
        // Arrange
        var genreToUpdate = new Genre { Id = 1, GenreName = "Updated Genre" };

        // Act
        var result = await _service.UpdateGenreAsync(genreToUpdate);

        // Assert
        result.ShouldNotBeNull();
        result.GenreName.ShouldBe("Updated Genre");
        _mockRepository.Verify(r => r.UpdateAsync(It.Is<Genre>(g => g.Id == 1 && g.GenreName == "Updated Genre")), Times.Once);
    }

    [Fact]
    public async Task DeleteGenreAsync_DeletesAndReturnsGenre()
    {
        // Act
        var result = await _service.DeleteGenreAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        _mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task FindGenresAsync_ReturnsMatchingGenres()
    {
        // Arrange
        Expression<Func<Genre, bool>> predicate = g => g.GenreName.Contains("Sci-Fi");

        // Act
        var result = await _service.FindGenresAsync(predicate);

        // Assert
        result.Count.ShouldBe(1);
        _mockRepository.Verify(r => r.FindAsync(predicate), Times.Once);
    }
}