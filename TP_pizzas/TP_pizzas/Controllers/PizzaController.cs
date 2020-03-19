using System.Linq;
using System.Web.Mvc;
using BO;
using Utils;
using TP_pizzas.Models;

namespace TP_pizzas.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDbPizza.Instance.Pizzas);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM vm = new PizzaVM();

            vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            try
            {
                Pizza pizza = vm.Pizza;

                pizza.Pate = FakeDbPizza.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);

                pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Where(
                    x => vm.IdsIngredients.Contains(x.Id))
                    .ToList();

                // Insuffisant
                //pizza.Id = FakeDb.Instance.Pizzas.Count + 1;

                pizza.Id = FakeDbPizza.Instance.Pizzas.Count == 0 ? 1 : FakeDbPizza.Instance.Pizzas.Max(x => x.Id) + 1;

                FakeDbPizza.Instance.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaVM vm = new PizzaVM();

            vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

            vm.Pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM vm)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDbPizza.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDbPizza.Instance.Pizzas.FirstOrDefault(x => x.Id == id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                FakeDbPizza.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}