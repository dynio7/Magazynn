using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Magazyn.Models
{
    public class Product:MainModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }


        public string ImageURL { get; set; } = string.Empty;


        public int CategoryID { get; set; }


        public Category Category { get; set; } =new Category();
    }
}
