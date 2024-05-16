using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photolabs.DAL;
using Photolabs.Models;
using PhotolabsCSharp.Helpers;

namespace PhotolabsCSharp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TopicsController : Controller {
    private readonly PhotolabContext _context;

    public TopicsController(PhotolabContext context) {
      _context = context;
    }

    // GET: Topics
    [HttpGet]
    [HttpGet("index")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Index() {
      //todo: return list of topics
      return _context.Topics != null ?
        Ok(await _context.Topics.ToListAsync()) :
        NotFound();
    }

    //GET: topics/photos/:id
    // todo: get photo list for supplied topic id
    [HttpGet("photos/{topicId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhotoExtended>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPhotoForTopic(int topicId) {

      string serverUrl = $"{Request.Scheme}://{Request.Host.Host}:{Request.Host.Port}/";
      PhotoHelper photoHelper = new PhotoHelper(_context);
      var photos = photoHelper.getPhotos(serverUrl, topicId);
      return photos != null ?
        Ok(photos) :
        NotFound();
    }

    // GET: Topics/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Topics == null) {
        return NotFound();
      }

      var topic = await _context.Topics
          .FirstOrDefaultAsync(m => m.Id == id);
      if (topic == null) {
        return NotFound();
      }

      return Ok(topic);
    }

    // POST: Topics/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    public async Task<IActionResult> Create([Bind("Id,Title,Slug")] Topic topic)
    {
      if (ModelState.IsValid) {
        _context.Add(topic);
        await _context.SaveChangesAsync();
        return RedirectToAction(topic.Id.ToString());
      }
      return Ok(topic);
    }

    // POST: Topics/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Slug")] Topic topic)
    {
      if (id != topic.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(topic);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!TopicExists(topic.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        return RedirectToAction(topic.Id.ToString());
      }
      return BadRequest(topic);
    }

    // POST: Topics/Delete/5
    [HttpPost, ActionName("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Topics == null) {
        return BadRequest();
      }
      var topic = await _context.Topics.FindAsync(id);
      if (topic != null) {
        _context.Topics.Remove(topic);
      }
            
      await _context.SaveChangesAsync();
      return RedirectToAction(topic.Id.ToString());
    }

    private bool TopicExists(int id)
    {
      return (_context.Topics?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
