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
public class ContributorsController : Controller
{
    private readonly IContributorService _contributorService;

    public ContributorsController(IContributorService contributorService)
    {
        _contributorService = contributorService;
    }

    // GET: Contributors
    public async Task<IActionResult> Index()
    {
        return View(await _contributorService.GetAllContributorsAsync());
    }

    // GET: Contributors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contributor = await _contributorService.GetContributorByIdAsync(id.Value);
        if (contributor == null)
        {
            return NotFound();
        }

        return View(contributor);
    }

    // GET: Contributors/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Contributors/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ContributorName,Description,Id,IsActive")] Contributor contributor)
    {
        if (ModelState.IsValid)
        {
            await _contributorService.AddContributorAsync(contributor);
            return RedirectToAction(nameof(Index));
        }
        return View(contributor);
    }

    // GET: Contributors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contributor = await _contributorService.GetContributorByIdAsync(id.Value);
        if (contributor == null)
        {
            return NotFound();
        }
        return View(contributor);
    }

    // POST: Contributors/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ContributorName,Description,Id,IsActive")] Contributor contributor)
    {
        if (id != contributor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _contributorService.UpdateContributorAsync(contributor);
            }
            catch (DbUpdateConcurrencyException)
            {
                var contributorMatch = await _contributorService.GetContributorByIdAsync(contributor.Id);
                if (contributorMatch is null)
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
        return View(contributor);
    }

    // GET: Contributors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contributor = await _contributorService.GetContributorByIdAsync(id.Value);
        if (contributor == null)
        {
            return NotFound();
        }

        return View(contributor);
    }

    // POST: Contributors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _contributorService.DeleteContributorAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
