using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Magazyn.Models
{
    public class Product:MainModel
    {
        [Required,
         MinLength(3, ErrorMessage ="Nazwa produktu powinna zawierać przynajmniej 3 znaki"),
         MaxLength(50, ErrorMessage ="Nazwa nie powinna mieć więcej niż 50 znaków"),
         Display(Name="Nazwa Produktu")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255, ErrorMessage ="Nazwa nie powinna przekraczać 255 znaków"),
         Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;

        [Required,
         DataType(DataType.Currency),
         Range(0,999999, ErrorMessage = "Cena nie powinna być ujemna lub większa od 999 999"),
         Display(Name="Cena netto")]
        public float Cost { get; set; }

        [Required,
         DataType(DataType.Currency),
         Range(0, 999999, ErrorMessage ="Cena nie powinna być ujemna lub większa od 999 999"),
         Display(Name="Cena brutto")]
        public float Price { get; set; }

        [Required,
         Range(0,999999, ErrorMessage = "Ilość nie powinna być ujemna lub większa od 999 999"),
         Display(Name="Ilość")]
        public int Count { get; set; }

        [Display(Name="Zdjęcie")]
        public string ImageURL { get; set; } = string.Empty;

        
        public int CategoryID { get; set; }

        [Display(Name = "Kategoria")]
        public Category Category { get; set; } = new Category();
    }
}
