using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Entities
{
    public class Households
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hshd_Num { get; set; }
        public string Loyality_flag { get; set; }
        public string Age_range { get; set; }
        public string Marital_status { get; set; }
        public string Income_range { get; set; }
        public string Homeowner_desc { get; set; }
        public string Hshd_composition { get; set; }
        public string Hshd_size { get; set; }
        public string Children { get; set; }

        public List<Transactions> Transactions { get; set;}
    }
}