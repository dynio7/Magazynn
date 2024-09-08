namespace Magazyn.Models
{
    public class Category:MainModel
    {
        public string Name { get; set; } = string.Empty;


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
