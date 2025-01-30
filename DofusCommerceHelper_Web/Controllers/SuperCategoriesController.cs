using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommerceHelperDB.Models;

namespace DofusCommerceHelper_Web.Controllers
{
    public class SuperCategoriesController : Controller
    {
        private readonly CommerceHelperContext _context;

        public SuperCategoriesController(CommerceHelperContext context)
        {
            _context = context;
        }

        // GET: SuperCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperCategory.ToListAsync());
        }

        // GET: SuperCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategory
                .FirstOrDefaultAsync(m => m.SuperCategoryId == id);
            if (superCategory == null)
            {
                return NotFound();
            }

            return View(superCategory);
        }

        // GET: SuperCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperCategoryId,SuperCategoryInGameId,SuperCategoryName")] SuperCategory superCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superCategory);
        }

        // GET: SuperCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategory.FindAsync(id);
            if (superCategory == null)
            {
                return NotFound();
            }
            return View(superCategory);
        }

        // POST: SuperCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuperCategoryId,SuperCategoryInGameId,SuperCategoryName")] SuperCategory superCategory)
        {
            if (id != superCategory.SuperCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperCategoryExists(superCategory.SuperCategoryId))
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
            return View(superCategory);
        }

        // GET: SuperCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategory
                .FirstOrDefaultAsync(m => m.SuperCategoryId == id);
            if (superCategory == null)
            {
                return NotFound();
            }

            return View(superCategory);
        }

        // POST: SuperCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superCategory = await _context.SuperCategory.FindAsync(id);
            if (superCategory != null)
            {
                _context.SuperCategory.Remove(superCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperCategoryExists(int id)
        {
            return _context.SuperCategory.Any(e => e.SuperCategoryId == id);
        }
    }
}
