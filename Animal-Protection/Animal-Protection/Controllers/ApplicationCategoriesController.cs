﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Animal_Protection.Data;
using Protection_Animal.Model.Entities;

namespace Animal_Protection.Controllers
{
    public class ApplicationCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public ApplicationCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categories.ToListAsync());
        }

        // GET: ApplicationCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var applicationCategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationCategory == null)
            {
                return NotFound();
            }

            return View(applicationCategory);
        }

        // GET: ApplicationCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ApplicationCategory applicationCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationCategory);
        }

        // GET: ApplicationCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var applicationCategory = await _context.Categories.FindAsync(id);
            if (applicationCategory == null)
            {
                return NotFound();
            }
            return View(applicationCategory);
        }

        // POST: ApplicationCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ApplicationCategory applicationCategory)
        {
            if (id != applicationCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationCategoryExists(applicationCategory.Id))
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
            return View(applicationCategory);
        }

        // GET: ApplicationCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var applicationCategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationCategory == null)
            {
                return NotFound();
            }

            return View(applicationCategory);
        }

        // POST: ApplicationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'AppDbContext.Categories'  is null.");
            }
            var applicationCategory = await _context.Categories.FindAsync(id);
            if (applicationCategory != null)
            {
                _context.Categories.Remove(applicationCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationCategoryExists(int id)
        {
          return _context.Categories.Any(e => e.Id == id);
        }
    }
}