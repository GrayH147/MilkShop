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
    public class BlogController : Controller
    {
        private readonly DemoWebSuaContext _context;
      
        public BlogController(DemoWebSuaContext context)
        {
            _context = context;
        }

        [Route("blogs.html", Name = ("Blog"))]
        public IActionResult Index(int? page)
        {

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lsTinTuc = _context.TblTinTucs
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<TblTinTuc> models = new PagedList<TblTinTuc>(lsTinTuc, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            var lsBaiVietLienQuan = _context.TblTinTucs.Include(x => x.Account)
                                        .Include(x => x.Account.Role).Include(x => x.Cat).AsNoTracking()
                                       .Where(x => x.Published == true).Take(3).OrderByDescending(x => x.PostId).ToList();
            ViewBag.BaiVietLienQuan = lsBaiVietLienQuan;
            return View(models);
        }

        [Route("/tin-tuc/{Alias}-{id}.html", Name = "TinChiTiet")]
        // GET: Admin/TblTinTucs/Details/
        public IActionResult Details(int id)
        {
            var tindang = _context.TblTinTucs.Include(x=>x.Account).Include(x=>x.Account.Role).Include(x=>x.Cat).AsNoTracking().SingleOrDefault(x => x.PostId == id);
            if (tindang == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaiVietLienQuan = _context.TblTinTucs.Include(x => x.Account)
                                         .Include(x => x.Account.Role).Include(x => x.Cat).AsNoTracking()
                                        .Where(x => x.Published == true && x.PostId != id).Take(3).OrderByDescending(x => x.PostId).ToList();
            ViewBag.BaiVietLienQuan = lsBaiVietLienQuan;
            return View(tindang);
        }
    }
}
