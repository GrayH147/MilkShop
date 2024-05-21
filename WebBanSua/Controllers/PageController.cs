using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanSua.Models;

namespace WebBanSua.Controllers
{
    public class PageController : Controller
    {
        private readonly DemoWebSuaContext _context;
        public PageController(DemoWebSuaContext context)
        {
            _context = context;
        }

       

        [Route("/page/{Alias}", Name = "PageDetails")]
        // GET: Page/Alias/
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");
            var _page = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (_page == null)
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View(_page);
        }
    }
}
