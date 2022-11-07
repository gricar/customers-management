using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersManagement.Models;

namespace CustomersManagement.Controllers
{
  public class CustomersController : Controller
  {
    private readonly DataContext _context;

    public CustomersController(DataContext context)
    {
      _context = context;
    }

    // GET: Customers
    public async Task<IActionResult> Index()
    {
      return _context.Customers != null ?
                  View(await _context.Customers.ToListAsync()) :
                  Problem("Entity set 'DataContext.Customer'  is null.");
    }

    // GET: Customers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Customers == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // GET: Customers/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Cpf,Name,Birthday,Genre,Cep,Address,State,City")] Customer customer)
    {
      if (ModelState.IsValid)
      {
        _context.Add(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: Customers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.Customers == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers.FindAsync(id);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }

    // POST: Customers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Name,Birthday,Genre,Cep,Address,State,City")] Customer customer)
    {
      if (id != customer.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(customer);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CustomerExists(customer.Id))
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
      return View(customer);
    }

    // GET: Customers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.Customers == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Customers == null)
      {
        return Problem("Entity set 'DataContext.Customers'  is null.");
      }
      var customer = await _context.Customers.FindAsync(id);
      if (customer != null)
      {
        _context.Customers.Remove(customer);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CustomerExists(int id)
    {
      return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
