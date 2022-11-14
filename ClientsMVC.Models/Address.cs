namespace ClientsMVC.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressType Type { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}