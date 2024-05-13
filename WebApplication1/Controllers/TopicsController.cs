using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photolabs.DAL;
using Photolabs.Models;

namespace PhotolabsCSharp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TopicsController : Controller
  {
    private readonly PhotolabContext _context;

    public TopicsController(PhotolabContext context)
    {
        _context = context;
    }

    // GET: Topics
    [HttpGet]
    [HttpGet("index")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Topic>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Index()
    {
      return _context.Topics != null ? 
        Ok(await _context.Topics.ToListAsync()) :
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
