using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantFinder.DataAccess;
using RestaurantLibrarys.Entities.DTO;
using RestaurantLibrarys.Entities.EntitiesModels;



namespace RestaurantFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //Burada dependensies injection ile controllerımıza dahil edeceğimiz boş bir context nesnesi oluşturduk. Nesneyi biz dışardan gelen bir parametre ile dolduracağız ve bunu controllerımızın contructor ında yapmamız gerekiyor.
        private readonly RestaurantDbContext _context;
        //Loglama için 
        LoggerCls logger = new LoggerCls();
       

        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
            
        }
        //public List<Restaurant>? RestaurantList = new List<Restaurant>()
        //{
        //    //new Restaurant{Id=1,name="BalikRestaurant",city="Trabzon"},
        //    //new Restaurant {Id=2,name="KebapRestaurant",city="Adana"},
        //    //new Restaurant {Id=3,name="iskenderRestaurant",city="Bursa"},
        //    //new Restaurant{Id=4,name="MantiRestaurant",city="Kayseri"},
        //    //new Restaurant {Id=5,name="KofteRestaurant",city="İstanbul"}
        //};
        Result _result = new Result();


        //Tüm retoranları getirecek olan metod
        [HttpGet("GetAllR")]
        public Result GetAllRestaurant()
        {
            
            var restaurantList = _context.restaurants.ToList(); 
            if (restaurantList.Count > 0)
            {
                _result.Status = 1;
                _result.message = "Restaurant of list";
                _result.RestaurantList = restaurantList;
            }
            else
            {
                _result.Status = 0;
                _result.message = "No Records Found";
            }
            return _result;
        }

        //Sadece istenilen restoran ı getirecek metod (Id ye göre getireceği için parametreleri (int Id) olacak)
        [HttpGet("{Id}")]
        public Result GetRestaurant(int Id)
        {

            //LİNQ
            //Karmaşık veri işlemleri için farklı veri kaynaklarından tek satırlık sorgular ile çalışmaktadır. (Kaydet, Güncelle, Sil, Ekle, Filtrele, vb.)
            //  Programlama dili(C#) ile veri tabanı arasındaki bağlantıyı kurmaktadır.
            //  Nesneler ile uyumlu olarak çalışabilmektedir.
            //  SQL, Object, DataSet, Xml gibi veri sağlayıcılarıylada sorgular yürütebilmektedir.
            //https://www.hasanbaskin.com/linq-nedir-neden-kullanilir/


            var ResultRestaurant = _context.restaurants.Where(Restaurant => Restaurant.Id == Id).ToList();

            if (ResultRestaurant.Count > 0)
            {
                _result.Status = 1;
                _result.message = "Record found";
                _result.RestaurantList = ResultRestaurant;
            }
            else
            {
                _result.Status = 0;
                _result.message = "No record found";

            }
            return _result;
        }

        //Kayıt eklemek için 
        [HttpPost("AddR")]
        public Result AddRestaurant(RestaurantDTO restaurantDTO)
        {
            if (restaurantDTO is not null)
            {
                //context işlemleri sadece entity nesnelerini kabul ettiği için parametreden gelen dto daki verileri bir adet entity nesnesi oluşturup onun içine atmamız gerekiyor. bu işleme de kavram olarak mappping işlemi denir.
                var restaurant = new Restaurant()
                {
                    name = restaurantDTO.name,
                    city = restaurantDTO.city
                    //burada id ve employee property leri de çıkıyor ancak bunları biz doldurmayacağız bunları entity arka planda ayarlayacak.
                };

                _context.restaurants.Add(restaurant);
                _context.SaveChanges();

                _result.Status = 1;
                _result.message = "Registration successfully added";

            }
            else
            {
                _result.Status = 0;
                _result.message = "Failed to add record";
            }
            return _result;
        }

        //güncelleme yapacak metod
        [HttpPut("{Id}")]
        public Result Update(int Id, RestaurantDTO restaurantDTO)
        {
            //bir veritabanı ile çalışıyorsak artık bütün veritabanuı işlemlerimizde context nesnesini kullanmalıyız
            Restaurant? restaurant = _context.restaurants.FirstOrDefault(o => o.Id == Id);
            if (restaurant != null)
            {
                restaurant.name = restaurantDTO.name;
                restaurant.city = restaurantDTO.city;

                _context.SaveChanges();

                _result.Status = 1;
                _result.message = "Restaurant information updated";
            }
            else
            {
                _result.Status = 0;
                _result.message = "This restaurant information is not registered";
            }
            return _result;
        }

        //silme işlemi yapacak metod
        [HttpDelete("{Id}")]
        public Result Delete(int Id)
        {
            
            //var customer = CustomerList.FirstOrDefault(k => k.Id == Id);
            var restaurant = _context.restaurants.FirstOrDefault(k => k.Id == Id);
            if (restaurant is not null)
            {
                _context.Remove(restaurant);
                _context.SaveChanges();
                _result.Status = 1;
                _result.message = "This record has been deleted";
                //Loglama işlemi için (LoggerController ı namespace e eklememiz gerkir yoksa hata verir.)
                logger.CreateLog(Id.ToString() + "Id Li" + _result.message);
            }
            else
            {
                _result.Status = 0;
                _result.message = "This record not found";
                logger.CreateLog(Id.ToString() + "Id Li" + _result.message);
            }
            return _result;

        }


        

        
    }
}
