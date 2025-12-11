using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagerWeb.Controllers;

[Authorize]
public class GenresController : Controller
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    // GET: Genres
    public async Task<IActionResult> Index()
    {
        return View(await _genreService.GetAllGenresAsync());
    }

    // GET: Genres/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genre = await _genreService.GetGenreByIdAsync(id.Value);
        if (genre == null)
        {
            return NotFound();
        }

        return View(genre);
    }

    // GET: Genres/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Genres/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("GenreName,Id,IsActive")] Genre genre)
    {
        if (ModelState.IsValid)
        {
            await _genreService.AddGenreAsync(genre);
            return RedirectToAction(nameof(Index));
        }
        return View(genre);
    }

    // GET: Genres/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genre = await _genreService.GetGenreByIdAsync(id.Value);
        if (genre == null)
        {
            return NotFound();
        }
        return View(genre);
    }

    // POST: Genres/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("GenreName,Id,IsActive")] Genre genre)
    {
        if (id != genre.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _genreService.UpdateGenreAsync(genre);
            }
            catch (DbUpdateConcurrencyException)
            {
                var genreMatch = await _genreService.GetGenreByIdAsync(id);
                if (genreMatch is null)
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
        return View(genre);
    }

    // GET: Genres/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genre = await _genreService.GetGenreByIdAsync(id.Value);
        if (genre == null)
        {
            return NotFound();
        }

        return View(genre);
    }

    // POST: Genres/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _genreService.DeleteGenreAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
