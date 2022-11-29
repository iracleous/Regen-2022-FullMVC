namespace Regen_2022.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
     //   public string photoPath{ get; set; } = "";
        public CustomerCategory CustomerCategory { get; set; } = new();
        public BuyingCategory BuyingCategory { get; set; }  
    }


    public class CustomerCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }= "";
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
    }


    public enum BuyingCategory
    {
        RETAIL, GROSS, INDIVIDUAL
    }

}
