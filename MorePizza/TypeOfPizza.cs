namespace MorePizza
{
    public class TypeOfPizza
    {
        public int PizzaID { get; set; }
        public int SlicesOfPizza { get; set; }

        public TypeOfPizza(int pizzaID, int pizzaSlices)
        {
            this.PizzaID = pizzaID;
            this.SlicesOfPizza = pizzaSlices;
        }
    }
}