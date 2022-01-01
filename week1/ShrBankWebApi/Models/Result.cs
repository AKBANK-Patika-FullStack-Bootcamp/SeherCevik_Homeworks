namespace ShrBankWebApi.Models
{
    public class Result
    {
        public int status { get; set; }
        public string? Message { get; set; }
        public List<Customer>? CustomerList { get; set; }
    }
}
