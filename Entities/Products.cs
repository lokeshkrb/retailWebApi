using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_num { get; set; }
        public string Department { get; set; }
        public string Comodity { get; set; }
        public string Brand_ty { get; set; }
        public string Natural_organic_flag { get; set; }

        public List<Transactions> Transactions { get; set;}
    }
}