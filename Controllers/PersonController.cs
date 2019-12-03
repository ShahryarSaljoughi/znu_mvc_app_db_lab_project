using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myMVCApp;
using myMVCApp.Data;

namespace myMVCApp.Controllers
{
  public class PersonController : Controller
  {
    private readonly G7Context _context;

    public PersonController(G7Context context)
    {
      _context = context;
    }

    // GET: Person
    public async Task<IActionResult> Index()
    {
      return View(await _context.Person.ToListAsync());
    }

    // GET: Person/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var person = await _context.Person
          .FirstOrDefaultAsync(m => m.Id == id);
      if (person == null)
      {
        return NotFound();
      }

      return View(person);
    }

    // GET: Person/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Person/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nationalid,Id,Fullname,Telno,Mobileno")] Person person)
    {
      if (ModelState.IsValid)
      {
        person.Id = Guid.NewGuid();
        _context.Add(person);
        // await _context.SaveChangesAsync();
        await _context.Database.ExecuteSqlRawAsync($@"
INSERT INTO public.person(
nationalid, id, fullname, telno, mobileno)
VALUES ('{person.Nationalid}', '{person.Id}', '{person.Fullname}', '{person.Telno}', '{person.Mobileno}');                
                ");
        return RedirectToAction(nameof(Index));
      }
      return View(person);
    }

    // GET: Person/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var person = await _context.Person.FindAsync(id);
      if (person == null)
      {
        return NotFound();
      }
      return View(person);
    }

    // POST: Person/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Nationalid,Id,Fullname,Telno,Mobileno")] Person person)
    {
      if (id != person.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(person);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PersonExists(person.Id))
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
      return View(person);
    }

    // GET: Person/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var person = await _context.Person
          .FirstOrDefaultAsync(m => m.Id == id);
      if (person == null)
      {
        return NotFound();
      }

      return View(person);
    }

    // POST: Person/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      var person = await _context.Person.FindAsync(id);
      _context.Person.Remove(person);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool PersonExists(Guid id)
    {
      return _context.Person.Any(e => e.Id == id);
    }
  }
}
