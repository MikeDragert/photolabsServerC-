﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photolabs.DAL;
using Photolabs.Models;
using SQLitePCL;

namespace PhotolabsCSharp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PhotosController : Controller
  {
    private readonly PhotolabContext _context;

    public PhotosController(PhotolabContext context)
    {
      _context = context;
    }

    // GET: Photos
    [HttpGet]
    [HttpGet("index")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Index()
    {
      var photos = (
        from photo in _context.Photos
        join userAccount in _context.UserAccounts
        on photo.UserAccountId equals userAccount.Id
        select new {
          id = photo.Id,
          urls = new Dictionary<string, string> {
            {"full", photo.FullUrl}, 
            {"regular",photo.RegularUrl}
          },
          user = new Dictionary<string, string> {
            {"username", userAccount.Username}, 
            {"name", userAccount.FullName}, 
            {"profile", userAccount.ProfileUrl}
          },
          location = new Dictionary<string, string> {
            {"city", photo.City}, 
            {"country", photo.Country}
          },
          similar_photos = (
            from simPhoto in _context.Photos
            join simUserAccount in _context.UserAccounts
            on simPhoto.UserAccountId equals simUserAccount.Id
            where simPhoto.Id != photo.Id && simPhoto.TopicId == photo.TopicId
            select new {
              id = simPhoto.Id,
              urls = new Dictionary<string, string> {
                {"full", simPhoto.FullUrl},
                {"regular",simPhoto.RegularUrl}
              },
              user = new Dictionary<string, string> {
                {"username", simUserAccount.Username},
                {"name", simUserAccount.FullName},
                {"profile", simUserAccount.ProfileUrl}
              },
              location = new Dictionary<string, string> {
                {"city", simPhoto.City},
                {"country", simPhoto.Country}
              },
            }
          ).Take(4).ToList()
        }
      ).ToList();
           
      return photos != null ?
        Ok(photos) :
        NotFound();
    }

    // GET: Photos/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Photos == null) {
        return NotFound();
      }

      var photo = await _context.Photos
        .FirstOrDefaultAsync(m => m.Id == id);
      if (photo == null) {
        return NotFound();
      }

      return Ok(photo);
    }

    // POST: Photos/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    public async Task<IActionResult> Create([Bind("Id,FullUrl,RegularUrl,City,Country")] Photo photo)
    {
      if (ModelState.IsValid) {
        _context.Add(photo);
        await _context.SaveChangesAsync();
        return RedirectToAction(photo.Id.ToString());
      }
      return BadRequest();
    }

    // POST: Photos/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FullUrl,RegularUrl,City,Country")] Photo photo)
    {
      if (id != photo.Id) {
          return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(photo);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!PhotoExists(photo.Id)) {
              return NotFound();
          } else {
              throw;
          }
        }
        return RedirectToAction(photo.Id.ToString());
      }
      return BadRequest();
    }

    // POST: Photos/Delete/5
    [HttpPost, ActionName("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Photos == null) {
        return BadRequest();
      }
      var photo = await _context.Photos.FindAsync(id);
      if (photo != null) {
        _context.Photos.Remove(photo);
      }
            
      await _context.SaveChangesAsync();
      return RedirectToAction();
    }

    private bool PhotoExists(int id)
    {
      return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
