﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanSua.Models;

namespace WebBanSua.ModelViews
{
    public class HomeViewVM
    {
        public List<TblTinTuc> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        //public QuangCao quangcao { get; set; }
    }
}
