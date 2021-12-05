using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Retail
{
    public class ProductModel
    {
        [Required]
        public int Product_num { get; set; }
        public string Department { get; set; }
        public string Comodity { get; set; }
        public string Brand_ty { get; set; }
        public string Natural_organic_flag { get; set; }
    }
}