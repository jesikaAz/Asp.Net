using System.Linq;
using System.Web.Mvc;
using BO;
using TP_pizzas.Models;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace TP_pizzas.Controllers
{

    public class PizzaController : Controller
    {
        private static List<Pizza> pizzas;
        private static List<Pate> patesDisponibles;
        private static List<Ingredient> ingredientsDisponibles;

        public PizzaController()
        {
  
            if (pizzas == null)
            {
                pizzas = new List<Pizza>();
            }

            if (patesDisponibles == null)
            {
                patesDisponibles = Pizza.PatesDisponibles;
            }

            if (ingredientsDisponibles == null)
            {
                ingredientsDisponibles = Pizza.IngredientsDisponibles;
            }
        }

 
        private PizzaVM GetPizzaVM(int id)
        {
            // Nous avons besoin d'un viewModel pour porter l'objet pizza à modifier, plus la liste de tous les ingrédients et la liste des pâtes disponibles
            var vm = new PizzaVM();

            // On récupère la pizza portant l'Id désiré dans la lsite des pizzas porté par le controller
            vm.Pizza = pizzas.FirstOrDefault(p => p.Id == id);

            // On créé directement l'objet attendu par la méthode ListBoxFor du HtmlHelper, qui nous permettra de choisir plusieurs ingrédients
            vm.Ingredients = ingredientsDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            // On créer directement l'objet attendu par la méthode DropDownListFor du HtmlHelper, qui nous permettra de choisir une pâte
            vm.Pates = patesDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            // Si la pizza avait déja une pâte, elle sera selectionnée sur la vue
            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            // Si la pizza avait déja des ingrédients, ils seront pré selectionnés sur la vue de modification
            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(i => i.Id).ToList();
            }
            return vm;
        }

        // GET: Pizza
        public ActionResult Index()
        {
            // On appel la vue Index en lui passant la liste des pizzas attendu
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var vm = new PizzaVM();
            vm.Ingredients = ingredientsDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            vm.Pates = patesDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            try
            {
                if (ModelState.IsValid && ValidateVM(vm))
                {
                    Pizza pizza = vm.Pizza;

                    pizza.Pate = patesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);

                    pizza.Ingredients = ingredientsDisponibles.Where(i => vm.IdsIngredients.Contains(i.Id)).ToList();


                    pizza.Id = pizzas.Count == 0 ? 1 : pizzas.Max(x => x.Id) + 1;

                    pizzas.Add(pizza);

                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = patesDisponibles.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                    vm.Ingredients = ingredientsDisponibles.Select(
                        x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                        .ToList();

                    return View(vm);
                }
            }
            catch
            {
                vm.Pates = patesDisponibles.Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();

                vm.Ingredients = ingredientsDisponibles.Select(
                    x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                    .ToList();

                return View(vm);
            }
        }

        private bool ValidateVM(PizzaVM vm)
        {
            bool result = true;

            if (vm.IdsIngredients.Count < 2 || vm.IdsIngredients.Count > 5)
            {
                ModelState.AddModelError("IdsIngredients", "Il faut sélectionner entre 2 et 5 ingredients");
                result = false;
            }

            if (pizzas.FirstOrDefault(x => x.Nom == vm.Pizza.Nom) != null)
            {
                ModelState.AddModelError("Pizza.Nom.AlreadyExists", "Il existe déjà une pizza avec ce nom");
                result = false;
            }

            foreach (var pizza in pizzas)
            {
                if (vm.IdsIngredients.Count == pizza.Ingredients.Count)
                {
                    bool isDifferent = false;
                    List<Ingredient> pizzaDb = pizza.Ingredients.OrderBy(x => x.Id).ToList();
                    vm.IdsIngredients = vm.IdsIngredients.OrderBy(x => x).ToList();
                    for (int i = 0; i < vm.IdsIngredients.Count; i++)
                    {
                        if (vm.IdsIngredients.ElementAt(i) != pizzaDb.ElementAt(i).Id)
                        {
                            isDifferent = true;
                            break;
                        }
                    }

                    if (!isDifferent)
                    {
                        ModelState.AddModelError("Ingredient.AlreadyExists", "Il existe déjà une pizza avec ces ingredients");
                        result = false;
                    }
                }
            }


            return result;
        }


        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetPizzaVM(id));
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM vm)
        {
            try
            {
                Pizza pizza = pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = patesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = ingredientsDisponibles.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();

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
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                // on récupère l'objet pizza dans notre liste correspondant à l'id passé en paramètre, puis on le supprime.
                var pizza = pizzas.FirstOrDefault(p => p.Id == id);
                pizzas.Remove(pizza);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}