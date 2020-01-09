using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251WebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Net.Http.Headers;


namespace ISAD251WebApp.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly StoredContext _context;

        public OrderDetailsController(StoredContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var storedContext = _context.OrderDetails.Include(o => o.Product);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://cent-5-534.uopnet.plymouth.ac.uk/ISAD251/ksuzuki/api/OrderDetails");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var context = _context.OrderDetails.Include(o => o.Product);
                return View(await storedContext.ToListAsync());
            }

        }





        // GET: OrderDetails/Details/5

        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://cent-5-534.uopnet.plymouth.ac.uk/ISAD251/ksuzuki/api/OrderDetails");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (orderDetails == null)
                {
                    return NotFound();
                }

                return View(orderDetails);

            }
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductDetails");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity,Date")] OrderDetails orderDetails)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://cent-5-534.uopnet.plymouth.ac.uk/ISAD251/ksuzuki/api/OrderDetails");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = orderDetails.OrderId });
            }
            }



        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://cent-5-534.uopnet.plymouth.ac.uk/ISAD251/ksuzuki/api/OrderDetails");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                {
                    var orderDetails = await _context.OrderDetails.FindAsync(id);
                    _context.OrderDetails.Remove(orderDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

        }
    }
}
