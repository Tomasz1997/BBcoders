using System.Threading;
namespace MorePizza
{
    public class TypeOfPizza
    {
        public static int TypesOfPizzas = 0;
        public int ID { get; set; }
        public int Slices { get; set; }

        public TypeOfPizza(int Slices)
        {
            this.ID = TypesOfPizzas++;
            this.Slices = Slices;
        }
    }
}