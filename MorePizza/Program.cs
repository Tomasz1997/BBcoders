using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace MorePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathsIN = new List<string>();
            pathsIN.Add(@"./ExampleData/a_example.in");
            pathsIN.Add(@"./ExampleData/b_small.in");
            pathsIN.Add(@"./ExampleData/c_medium.in");
            pathsIN.Add(@"./ExampleData/d_quite_big.in");
            pathsIN.Add(@"./ExampleData/e_also_big.in");

            var pathsOUT = new List<string>();
            pathsOUT.Add(@"./Results/a_example.out");
            pathsOUT.Add(@"./Results/b_small.out");
            pathsOUT.Add(@"./Results/c_medium.out");
            pathsOUT.Add(@"./Results/d_quite_big.out");
            pathsOUT.Add(@"./Results/e_also_big.out");

            for (int i = 0; i < pathsIN.Count(); i++)
            {                
                File file = new File();
                string[] menuCard = file.ReadFile(pathsIN[i]);

                var menu = new Menu(menuCard);
                var orders = menu.GenerateOrder();

                StringBuilder output = new StringBuilder();

                output.AppendLine(orders.Count().ToString());
                foreach (var order in orders)
                {
                    output.Append(order.ID + " ");
                }
                file.CreateFile(pathsOUT[i], output.ToString());

                Console.WriteLine("Aktualny plik: " + pathsIN[i] + " - wynik: " + orders.Sum(pizza => pizza.Slices));
            }
        }
    }
}
