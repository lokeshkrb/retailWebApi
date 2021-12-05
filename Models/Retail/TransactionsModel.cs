using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Retail
{
    public class TransactionModel
    {
        [Required]
        public int Basket_num { get; set; }
        [Required]
        public int Hshd_Num { get; set; }
        public string Purchase { get; set; }
        [Required]
        public int Product_num { get; set; }
        public string Spend { get; set; }
        public string Units { get; set; }
        public string Stock_r { get; set; }
        public string Week_num { get; set; }
        public string Year { get; set; }
        public HouseholdModel Households { get; set;}
        public ProductModel Products { get; set;}
    }
}