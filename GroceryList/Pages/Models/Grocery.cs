namespace GroceryList.Pages.Models
{
    public class Grocery
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;
    }
}
