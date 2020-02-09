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
            
            TypeOfPizza.TypesOfPizzas = 0;
            Pizzas = new List<TypeOfPizza>();

            for (int i = 2; i < menu.Length; i++)
            {
                var res3 = int.TryParse(menu[i], out int slices);
                if (res3)
                {
                    if (menu[i] != "")
                    {
                        var pizza = new TypeOfPizza(slices);
                        Pizzas.Add(pizza);
                    }
                }
            }
        }

        public List<TypeOfPizza> GenerateOrder()
        {
            var SumOfSlices = Pizzas.Sum(pizza => pizza.Slices);
            if (SumOfSlices <= MaximumSlice) return Pizzas;
        
            Pizzas = Pizzas.OrderByDescending(pizza => pizza.Slices).ToList();
            var resultOrder = new List<TypeOfPizza>();
            int CurrentSlices = 0;

            foreach (var pizza in Pizzas)
            {
                if (pizza.Slices + CurrentSlices <= MaximumSlice)
                {
                    CurrentSlices += pizza.Slices;
                    resultOrder.Add(pizza);
                }
            }
            return resultOrder.OrderBy(pizza => pizza.ID).ToList();
        }

    }
}