﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class SelectHeroBLL
    {
        public static List<Hero> SelectHeroByHeroType(string heroType) 
        {
            return HeroDAL.SelectHeroByHeroType(heroType);
        }
    }
}
