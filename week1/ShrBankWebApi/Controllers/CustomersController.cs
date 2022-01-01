using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShrBankWebApi.Models;

namespace ShrBankWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customer> CustomerList = new List<Customer>() 
        { 
            new Customer {  Id = 1, name = "Seher", LastName = "Cevik", password = 123, debt = 0, asset = 1000000, GSM = "5437612095" },
            new Customer { Id = 2, name = "Tamer", LastName = "Omeroglu", password = 2322, debt = 0, asset = 1000000, GSM = "5437456132" }
         };
        Result _result = new Result();

        [HttpPost]
        public Result AddCustomer(Customer customer)
        {

            //CustomerList.Add(new Customer { Id = 1, name = "Seher", LastName = "Cevik", password = 123, debt = 0, asset = 1000000, GSM = "5437612095" });
            //Customer.Add(new Models.Customer { Id = 2, name = "Tamer", LastName = "Omeroglu", password = 2322, debt = 0, asset = 1000000, GSM = "5437456132" });

            if (customer is not null)
            {
                CustomerList.Add(customer);
                _result.status = 1;
                _result.Message = "Kayıt başarıyla eklendi";

            }
            else
            {
                _result.status = 0;
                _result.Message = "Kayıt eklenemedi.";
            }

            return _result;
        }

        [HttpGet("{Id}")]
        public Result GetCustomer(int Id)
        {

           // List<Customer> customer = new List<Customer>();

          //buradaki firstordefault u silip where e çektim ve sonuna tolist() ekledim çünkü bizim result nesnemizdeki data  property miz list tipinde. firstordefault ifadesi bize bir liste dönmediği için where ifade ile sorgulayıp tolist ifadesi ile de sorgusonucunu listeye dönüştürdüm.
            var resultCustomer = CustomerList.Where(x => x.Id == Id).ToList();

            if (resultCustomer.Count > 0)
            {

                _result.status = 1;
                _result.Message = "Kayıt Bulundu";
                _result.CustomerList = resultCustomer;
            }
            else
            {
                _result.status = 1;
                _result.Message = "Kayıt Bulunamadı";
            }

            return _result;
        }

        [HttpPut("{Id}")]
        //birden çok dönüş türü varsa IActionResult uygulanabilir.
        //Türler ActionResult çeşitli HTTP durum kodlarını temsil ediyor. 'den türetilmeyen herhangi bir soyut ActionResult sınıf, geçerli bir dönüş türü olarak niteler.
        public Result Update(int Id, Customer newValue)
        {
            //Listenin dolduğu yer
            //CustomerList = AddCustomer();
            Customer? _OldValue = CustomerList.Find(o => o.Id == Id);
            if (_OldValue != newValue)
            {
                _OldValue = newValue;
                _result.status = 1;
                _result.Message = "müşteri bilgileri güncellendi!";
            }
            else
            {
                _result.status = 0;
                _result.Message = "Bu kayıtlı bir müşteri değil!";
            }
            return _result;
        }


        
    }
}
