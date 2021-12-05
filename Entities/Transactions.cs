namespace WebApi.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public int Basket_num { get; set; }
        public int Hshd_Num { get; set; }
        public Households Households { get; set;}
        public string Purchase { get; set; }
        public int Product_num { get; set; }
        public Products Products { get; set;}
        public string Spend { get; set; }
        public string Units { get; set; }
        public string Stock_r { get; set; }
        public string Week_num { get; set; }
        public string Year { get; set; }
        
    }
}