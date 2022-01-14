namespace ShrBankWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }
        public int password { get; set; }
        public double debt { get; set; }
        public double asset { get; set; }
        public string GSM { get; set; }

    }
}
