using BO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TP_pizzas.Models
{
    public class PizzaVM
    {
            public Pizza Pizza { get; set; }
            public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

            public int IdSelectedPate { get; set; }
            public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}
