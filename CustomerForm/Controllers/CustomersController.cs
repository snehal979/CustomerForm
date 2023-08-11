using CustomerForm.Data;
using CustomerForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerForm.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder) //SORTING
        {
            ViewData["DOB"] = string.IsNullOrEmpty(sortOrder) ? "DOB_desc" : "";
            var customer = await _context.Customers.ToListAsync();
            switch (sortOrder)
            {
                case "DOB_desc":
                    customer = customer.OrderByDescending(e => e.DOB).ToList();
                    break;
                default:
                    customer = customer.OrderBy(e => e.DOB).ToList();
                    break;
            }

            return View(customer);


        }
        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create Post method
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid) //Server Validation
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                TempData["success"] = "Welcome !";
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
            
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var detatil = await _context.Customers.FindAsync(id);
            if (detatil == null)
            {
                return NotFound();
            }
           
            return View(detatil);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer detatil)
        {
            if (id != detatil.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(detatil);
                    await _context.SaveChangesAsync();
                
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(detatil);
        }

       
    }
}
