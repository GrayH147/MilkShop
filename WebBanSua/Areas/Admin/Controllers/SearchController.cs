using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanSua.Models;

namespace WebBanSua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly DemoWebSuaContext _context;

        public SearchController(DemoWebSuaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            ls = _context.Products.AsNoTracking()
                                  .Include(a => a.Cat)
                                  .Where(x => x.ProductName.Contains(keyword))
                                  .OrderByDescending(x => x.ProductName)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductsSearchPartial", ls);
            }
        }
        public IActionResult FindCustomer(string keywordCus)
        {
            List<Customer> ls = new List<Customer>();
            if (string.IsNullOrEmpty(keywordCus) || keywordCus.Length < 1)
            {
                return PartialView("ListCusSearchPartial", null);
            }
            ls = _context.Customers.AsNoTracking()
                                  .Include(a => a.Location)
                                  .Where(x => x.FullName.Contains(keywordCus))
                                  .OrderByDescending(x => x.FullName)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListCusSearchPartial", null);
            }
            else
            {
                return PartialView("ListCusSearchPartial", ls);
            }
        }
    }
}
