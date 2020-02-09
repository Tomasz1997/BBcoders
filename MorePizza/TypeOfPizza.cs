using System.Threading;
namespace MorePizza
{
    public class TypeOfPizza
    {
        public int ID { get; set; }
        public int Slices { get; set; }

        public TypeOfPizza(int ID, int Slices)
        {
            this.ID = ID;
            this.Slices = Slices;
        }
    }
}