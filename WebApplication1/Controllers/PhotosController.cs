using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photolabs.DAL;
using Photolabs.Models;
using PhotolabsCSharp.Helpers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhotoExtended>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Index()
    {
      string serverUrl = $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}/Images/";

      PhotoHelper photoHelper = new PhotoHelper(_context);
      var photos = photoHelper.getPhotos(serverUrl);

      return photos != null ?
        Ok(photos) :
        NotFound();
    }

    // GET: Photos/5
    //we are not going to retrieve by id for this interface
    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Photo>))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> Details(int? id) {
    //  if (id == null || _context.Photos == null) {
    //    return NotFound();
    //  }

    //  var photo = await _context.Photos
    //    .FirstOrDefaultAsync(m => m.Id == id);
    //  if (photo == null) {
    //    return NotFound();
    //  }

    //  return Ok(photo);
    //}



    // GET: Photos/5
    [HttpGet("{searchString}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhotoExtended>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Search(string searchString) {

      string serverUrl = $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}/Images/";
      string[] searchItems = searchString.ToLower().Split(' ');

      PhotoHelper photoHelper = new PhotoHelper(_context);
      var photos = photoHelper.getPhotos(serverUrl, searchItems);

      return photos != null ?
        Ok(photos) :
        NotFound();
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
