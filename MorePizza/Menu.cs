using System;
using System.Collections.Generic;
using System.Linq;

namespace MorePizza
{
    public class Menu
    {
        public int MaximumSlice { get; private set; }
        public int TypesOfPizza { get; private set; }
        public List<TypeOfPizza> Pizzas { get; private set; }

        public Menu(string[] menu)
        {
            var res1 = int.TryParse(menu[0], out int maxSlice);
            var res2 = int.TryParse(menu[1], out int typesOfPizza);
            if (res1 && res2)
            {
                MaximumSlice = maxSlice;
                TypesOfPizza = typesOfPizza;
            }

            Pizzas = new List<TypeOfPizza>();

            int pizzaID = 0;
            for (int i = 2; i < menu.Length; i++)
            {
                var res3 = int.TryParse(menu[i], out int slices);
                if (res3)
                {
                    if (menu[i] != "")
                    {
                        var pizza = new TypeOfPizza(pizzaID, slices);
                        Pizzas.Add(pizza);
                        pizzaID++;
                    }
                }
            }
        }

        public List<TypeOfPizza> GenerateOrder()
        {
            // Policzenie sumy wszystkich kawałków
            var SumOfSlices = Pizzas.Sum(x => x.SlicesOfPizza);
            
            // Jeżeli wszystkie pizze mogą zostać zamówione, to zamawiamy wszystkie
            if (SumOfSlices <= MaximumSlice) return Pizzas;
        
            // Sortujemy liste pizz'cami wg. ilości kawałków malejąco
            Pizzas = Pizzas.OrderByDescending(x => x.SlicesOfPizza).ToList();

            // Tworzymy liste z gotowym zamówieniem
            var resultOrder = new List<TypeOfPizza>();

            // Aktualna ilość kawałków
            int CurrentSlices = 0;

            // Dobieramy pizze, która zmieści się w zadanym ograniczeniu
            foreach (var pizza in Pizzas)
            {
                if (pizza.SlicesOfPizza + CurrentSlices <= MaximumSlice)
                {
                    CurrentSlices += pizza.SlicesOfPizza;
                    resultOrder.Add(pizza);
                }
            }

            // Sortujemy pizze wg. identyfikatora
            resultOrder = resultOrder.OrderBy(x => x.PizzaID).ToList();
            return resultOrder;
        }

    }
}