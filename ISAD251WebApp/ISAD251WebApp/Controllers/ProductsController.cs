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
    public class ProductsController : Controller
    {
        private readonly StoredContext _context;

        public ProductsController(StoredContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Products> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44362/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));




                return View(await _context.Products.ToListAsync());
            }
        }
        
   
    }
}
