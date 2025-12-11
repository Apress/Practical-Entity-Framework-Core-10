using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using EF10_InventoryServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventoryManagerWeb.Controllers;

[Authorize]
public class ItemsController : Controller
{
    private readonly IItemService _itemService;
    private readonly ICategoryService _categoryService;
    private readonly IGenreService _genreService;
    private readonly IContributorService _contributorService;

    public ItemsController(IItemService itemService, ICategoryService categoryService
                            , IGenreService genreService, IContributorService contributorService)
    {
        _itemService = itemService;
        _categoryService = categoryService;
        _genreService = genreService;
        _contributorService = contributorService;
    }

    // GET: Items
    public async Task<IActionResult> Index()
    {
        var items = await _itemService.GetFullItemDetails();
        return View(items);
    }

    // GET: Items/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    private async Task<List<Category>> GetCategoriesAsync()
    {
        //TODO: Add caching here
        return await _categoryService.GetAllCategoriesAsync();
    }

    private async Task SetCategoriesAsync()
    {
        var categories = await GetCategoriesAsync();
        ViewData["CategoryId"] = new SelectList(categories, "Id", "CategoryName");
    }

    private async Task<List<Genre>> GetGenresAsync()
    {
        //TODO: Add caching here
        return await _genreService.GetAllGenresAsync();
    }

    private async Task SetGenresAsync(List<int>? selectedGenreIds = null)
    {
        var genres = await GetGenresAsync();
        ViewData["GenreId"] = selectedGenreIds == null
            ? new MultiSelectList(genres, "Id", "GenreName")
            : new MultiSelectList(genres, "Id", "GenreName", selectedGenreIds);
    }

    private async Task<List<Contributor>> GetContributorsAsync()
    {
        //TODO: Add caching here
        return await _contributorService.GetAllContributorsAsync();
    }

    private async Task SetContributorsAsync(List<int>? selectedContributorIds = null)
    {
        var contributors = await GetContributorsAsync();
        ViewData["Contributors"] = selectedContributorIds == null
            ? new MultiSelectList(contributors, "Id", "ContributorName")
            : new MultiSelectList(contributors, "Id", "ContributorName", selectedContributorIds);
    }

    // GET: Items/Create
    public async Task<IActionResult> Create()
    {
        await SetCategoriesAsync();
        await SetGenresAsync();
        await SetContributorsAsync();
        return View();
    }

    private void ResetModelState()
    {
        // Clear existing model state errors
        ModelState.Clear();
        // Re-validate the model to update the ModelState with current values
        TryValidateModel(ModelState);
    }

    protected string GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return userId;
    }

    // POST: Items/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ItemEditViewModel model)
    {
        var userId = GetCurrentUserId();

        model.Item.CreatedByUserId = userId;
        ResetModelState();

        if (ModelState.IsValid)
        {
            // Map selected genres and contributors to the Item
            if (model.SelectedGenreIds != null)
            {
                // Get all genres
                var allGenres = await GetGenresAsync();
                model.Item.Genres = allGenres
                    .Where(g => model.SelectedGenreIds.Contains(g.Id))
                    .ToList();
            }
            if (model.SelectedContributorIds != null)
            {
                var allContributors = await GetContributorsAsync();
                model.Item.ItemContributors = model.SelectedContributorIds
                    .Where(id => allContributors.Any(c => c.Id == id))
                    .Select(id => new ItemContributor { ContributorId = id })
                    .ToList();
            }

            await _itemService.AddItemAsync(model.Item);
            return RedirectToAction(nameof(Index));
        }
        await SetCategoriesAsync();
        await SetGenresAsync(model.SelectedGenreIds);
        await SetContributorsAsync(model.SelectedContributorIds);
        return View(model);
    }

    // GET: Items/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);   
        if (item == null)
        {
            return NotFound();
        }

        // Map to ItemEditViewModel
        var model = new ItemEditViewModel
        {
            Item = item,
            SelectedContributorIds = item.ItemContributors?.Select(ic => ic.ContributorId).ToList() ?? new List<int>(),
            SelectedGenreIds = item.Genres?.Select(g => g.Id).ToList() ?? new List<int>()
        };

        await SetCategoriesAsync();
        await SetGenresAsync(model.SelectedGenreIds);
        await SetContributorsAsync(model.SelectedContributorIds);

        return View(model);
    }

    // POST: Items/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ItemEditViewModel itemEditViewModel)
    {
        if (id != itemEditViewModel.Item.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                //set the correct ids for genres
                if (itemEditViewModel.SelectedGenreIds != null)
                {
                    var allGenres = await GetGenresAsync();
                    itemEditViewModel.Item.Genres = allGenres
                        .Where(g => itemEditViewModel.SelectedGenreIds.Contains(g.Id))
                        .ToList();
                }
                else
                {
                    itemEditViewModel.Item.Genres = new List<Genre>();
                }

                //set the correct ids for contributors
                if (itemEditViewModel.SelectedContributorIds != null)
                {
                    var dbItem = await _itemService.GetItemByIdAsync(itemEditViewModel.Item.Id);
                    var existingContributors = dbItem?.ItemContributors ?? new List<ItemContributor>();
                    var allContributors = await GetContributorsAsync();

                    var validContributorIds = itemEditViewModel.SelectedContributorIds
                        .Where(id => allContributors.Any(c => c.Id == id))
                        .ToList();

                    // Build the new list, reusing existing ItemContributor if present
                    var newItemContributors = validContributorIds
                        .Select(contributorId =>
                        {
                            var existing = existingContributors.FirstOrDefault(ic => ic.ContributorId == contributorId);
                            if (existing != null)
                            {
                                return existing;
                            }
                            else
                            {
                                return new ItemContributor
                                {
                                    ContributorId = contributorId,
                                    ItemId = itemEditViewModel.Item.Id
                                    // Set other properties if needed
                                };
                            }
                        })
                        .ToList();

                    itemEditViewModel.Item.ItemContributors = newItemContributors;
                }
                else
                {
                    itemEditViewModel.Item.ItemContributors = new List<ItemContributor>();
                }

                await _itemService.UpdateItemWithRelationshipsAsync(itemEditViewModel.Item);
            }
            catch (DbUpdateConcurrencyException)
            {
                var itemMatch = await _itemService.GetItemByIdAsync(itemEditViewModel.Item.Id);
                if (itemMatch is null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        await SetCategoriesAsync();
        await SetGenresAsync();
        await SetContributorsAsync();
        return View(itemEditViewModel);
    }

    // GET: Items/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // POST: Items/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _itemService.DeleteItemAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
