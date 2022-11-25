namespace Regen_2022.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerCategory CustomerCategory { get; set; }    
    }


    public class CustomerCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
