namespace EpiShipment.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerBusinessName { get; set; }
        public string CustomerTaxIdCode { get; set; }
        public string CustomerVATNumber { get; set; }
        public CustomerType CustomerType { get; set; }
        public int UserId { get; set; }
    }

    public enum CustomerType
    {
        Private,
        Business
    }

}
