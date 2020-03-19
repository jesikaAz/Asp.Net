using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_pizzas.Models;

namespace TP_pizzas.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            pizzas = this.GetPizzas();
        }

        public static FakeDbPizza Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbPizza();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        private List<Pizza> GetPizzas()
        {
            var i = 1;
            return new List<Pizza>
            {
                new Pizza{Id=i++,Nom = "Marguarita",Pate = "fine",Ingredient = "Fromage"},
                new Pizza{Id=i++,Nom = "Hawaienne",Pate = "epaisse",Ingredient = "Poulet"},
                new Pizza{Id=i++,Nom = "Oceane",Pate = "fine",Ingredient = "Thon"},
            };
        }
    }
}