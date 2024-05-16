using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Photolabs.DAL;
using Photolabs.Models;
using PhotolabsCSharp.Helpers;
using SQLitePCL;
using System.Linq;
using System.Linq.Expressions;

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

    List<PhotoExtended> getPhotos(string serverUrl, string[] searchTerms) {

      
      var query = _context.Photos
        .Join(
          _context.UserAccounts,
          p => p.UserAccountId,
          ua => ua.Id,
          (p, ua) => new {
            Id = p.Id,
            FullUrl = p.FullUrl,
            RegularUrl = p.RegularUrl,
            City = p.City,
            Country = p.Country,
            Username = ua.Username,
            FullName = ua.FullName,
            ProfileUrl = ua.ProfileUrl,
            TopicId = p.TopicId
          }
        )
        .Join(
          _context.Topics,
          p => p.TopicId,
          t => t.Id,
          (p, t) => new {
            Id = p.Id,
            FullUrl = p.FullUrl,
            RegularUrl = p.RegularUrl,
            City = p.City,
            Country = p.Country,
            Username = p.Username,
            FullName = p.FullName,
            ProfileUrl = p.ProfileUrl,
            TopicTitle = t.Title,
            TopicId = t.Id
          }
        );

      if (searchTerms != null) {
        foreach (string searchTerm in searchTerms) {
          query = query.Where(photo =>
            photo.City.ToLower().Contains(searchTerm) ||
            photo.Country.ToLower().Contains(searchTerm) ||
            photo.Username.ToLower().Contains(searchTerm) ||
            photo.FullName.ToLower().Contains(searchTerm) ||
            photo.TopicTitle.ToLower().Contains(searchTerm)
          );
        }
      }

      return query.Select(photo => new PhotoExtended
        {
          Id = photo.Id,
          Urls = new Dictionary<string, string> {
            {"full", $"{serverUrl}{photo.FullUrl}"},
            {"regular",$"{serverUrl}{photo.RegularUrl}"}
          },
          User = new Dictionary<string, string> {
            {"username", photo.Username},
            {"name", photo.FullName},
            {"profile", $"{serverUrl}{photo.ProfileUrl}"}
          },
          Location = new Dictionary<string, string> {
            {"city", photo.City},
            {"country", photo.Country}
          },
          TopicTitle = photo.TopicTitle,
          SimilarPhotos = (
            from simPhoto in _context.Photos
            join simUserAccount in _context.UserAccounts
            on simPhoto.UserAccountId equals simUserAccount.Id
            where simPhoto.Id != photo.Id && simPhoto.TopicId == photo.TopicId
            select new PhotoExtended
            {
              Id = simPhoto.Id,
              Urls = new Dictionary<string, string> {
                {"full",  $"{serverUrl}{simPhoto.FullUrl}"},
                {"regular",$"{serverUrl}{simPhoto.RegularUrl}"}
              },
              User = new Dictionary<string, string> {
                {"username", simUserAccount.Username},
                {"name", simUserAccount.FullName},
                {"profile", $"{serverUrl}{simUserAccount.ProfileUrl}"}
              },
              Location = new Dictionary<string, string> {
                {"city", simPhoto.City},
                {"country", simPhoto.Country}
              },
            }
          ).Take(4).ToList()
        }).ToList();
    }

    // GET: Photos
    [HttpGet]
    [HttpGet("index")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhotoExtended>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Index()
    {
      string serverUrl = $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}/";

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

      string serverUrl = $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}/";
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
