using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommerceHelperDB.Models;
using System.Globalization;
using UtilsLibrary;

namespace DofusCommerceHelper_Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly CommerceHelperContext _context;

        public ItemsController(CommerceHelperContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string SearchString, int Page = 1, int Amount = 25, int CategoryId = -1, int SuperCategoryId = -1)
        {
            TempData["PageNbr"] = Page;
            ViewData["SearchString"] = SearchString;
			ViewData["CategoryId"] = CategoryId;
			TempData["CategoryList"] = _context.Category.Include(p=>p.SuperCategory).ToList().OrderBy(p=>p.CategoryName.RemoveAccents()).ToList();
            ((List<Category>)TempData["CategoryList"]).Insert(0, new Category() { CategoryName = "----", CategoryId = -1 });
			IEnumerable<Item> ItemsList = _context.Item.Include(p => p.Category).ThenInclude(p => p.SuperCategory);

            if (CategoryId != -1 )
				ItemsList= ItemsList.Where(p=>p.Category.CategoryId == CategoryId);
			if (SuperCategoryId != -1)
				ItemsList = ItemsList.Where(p => p.Category.SuperCategory.SuperCategoryId == SuperCategoryId);
            if (SearchString != null && SearchString != "")
            {
                string[] SearchList = SearchString.Split();
				ItemsList = ItemsList.ToList().Where(x => SearchList.All(s => x.ItemName.RemoveAccents().Contains(s.RemoveAccents())));
            }
            return View(ItemsList.Skip(Amount * (Page-1)).Take(Amount).ToList());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,InGameId,ItemName,ItemDescription,ItemLvl,IconUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,InGameId,ItemName,ItemDescription,ItemLvl,IconUrl")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemId == id);
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
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
