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
    public class HomeController : Controller
    {
        private readonly DemoWebSuaContext _context;

        public HomeController(DemoWebSuaContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            ViewBag.cus = _context.Customers.ToList();
            ViewBag.Odr = _context.Orders.ToList();
            ViewBag.Odt = _context.OrderDetails.Include(x=>x.Product).ToList();
            ViewBag.p = _context.Products.ToList();
            ViewBag.nv = _context.Accounts.ToList();
            var odt= _context.OrderDetails.AsNoTracking().Include(x => x.Product);
            //int soSpBan = 0;
            //foreach (var i in odt)
            //{
            //    soSpBan +=Convert.ToInt32( odt.Count(i.ProductId));
            //}
            
            var odrDelete = _context.Orders.AsNoTracking().Where(x=>x.Deleted==true).ToList();
            var odrCompleted = _context.Orders.AsNoTracking().Where(x=>x.Paid==true).ToList();
            ViewBag.OdrDelete = odrDelete;
            ViewBag.OdrComplete = odrCompleted;
            


            return View("Index");
        }
    }
}
