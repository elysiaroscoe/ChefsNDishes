using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class ViewModel
    {
        public List<Chef> AllChefs {get;set;}
        public List<Dish> AllDishes {get;set;}
    }
}