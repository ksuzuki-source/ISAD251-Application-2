using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251WebApp.Models;

namespace ISAD251WebApp.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly StoredContext _context;

        public OrderDetailsController(StoredContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails

        [HttpGet]

        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {

            IList<OrderDetails> orders = null;

            using (var ctx = new StoredContext())
            {
                orders = ctx.OrderDetails.Select(o => new OrderDetails()
                {
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    Date = o.Date,
                    Product = o.Product

                }).ToList<OrderDetails>();

                return await _context.OrderDetails.ToListAsync();

            }
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return orderDetails;
        }

        

        // POST: api/OrderDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

         
                _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetOrderDetails", new { id = orderDetails.OrderId }, orderDetails);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDetails>> DeleteOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();

            return orderDetails;
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderId == id);
        }
    }
}
