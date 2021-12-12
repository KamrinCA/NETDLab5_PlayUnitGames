﻿/* Author: Kamrin Aubin
 * Last Modified: December 12, 2021
 * Description: Video Game Consoles Controller. Manages the CRUD operations and views for the VideoGameConsole Model
 *              That includes, Create, Edit, View, and Delete
 *              
 *              **GENERATED BY ENTITY FRAMEWORK**
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETDLab5.Models;

namespace NETDLab5.Controllers
{
    public class VideoGameConsolesController : Controller
    {
        private readonly VideoGameContext _context;

        public VideoGameConsolesController(VideoGameContext context)
        {
            _context = context;
        }

        // GET: VideoGameConsoles
        public async Task<IActionResult> Index()
        {
            var videoGameContext = _context.VideoGameConsole.Include(v => v.store);
            return View(await videoGameContext.ToListAsync());
        }

        // GET: VideoGameConsoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGameConsole = await _context.VideoGameConsole
                .Include(v => v.store)
                .FirstOrDefaultAsync(m => m.videoGameConsoleID == id);
            if (videoGameConsole == null)
            {
                return NotFound();
            }

            return View(videoGameConsole);
        }

        // GET: VideoGameConsoles/Create
        public IActionResult Create()
        {
            ViewData["storeID"] = new SelectList(_context.Stores, "storeID", "storeID");
            return View();
        }

        // POST: VideoGameConsoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("videoGameConsoleID,brand,name,manufacturer,isNew,storeID")] VideoGameConsole videoGameConsole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGameConsole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["storeID"] = new SelectList(_context.Stores, "storeID", "storeID", videoGameConsole.storeID);
            return View(videoGameConsole);
        }

        // GET: VideoGameConsoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGameConsole = await _context.VideoGameConsole.FindAsync(id);
            if (videoGameConsole == null)
            {
                return NotFound();
            }
            ViewData["storeID"] = new SelectList(_context.Stores, "storeID", "storeID", videoGameConsole.storeID);
            return View(videoGameConsole);
        }

        // POST: VideoGameConsoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("videoGameConsoleID,brand,name,manufacturer,isNew,storeID")] VideoGameConsole videoGameConsole)
        {
            if (id != videoGameConsole.videoGameConsoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGameConsole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameConsoleExists(videoGameConsole.videoGameConsoleID))
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
            ViewData["storeID"] = new SelectList(_context.Stores, "storeID", "storeID", videoGameConsole.storeID);
            return View(videoGameConsole);
        }

        // GET: VideoGameConsoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGameConsole = await _context.VideoGameConsole
                .Include(v => v.store)
                .FirstOrDefaultAsync(m => m.videoGameConsoleID == id);
            if (videoGameConsole == null)
            {
                return NotFound();
            }

            return View(videoGameConsole);
        }

        // POST: VideoGameConsoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoGameConsole = await _context.VideoGameConsole.FindAsync(id);
            _context.VideoGameConsole.Remove(videoGameConsole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGameConsoleExists(int id)
        {
            return _context.VideoGameConsole.Any(e => e.videoGameConsoleID == id);
        }
    }
}
