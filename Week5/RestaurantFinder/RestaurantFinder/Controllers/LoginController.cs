using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantFinder.DataAccess;
using RestaurantFinder.Helpers;
using RestaurantLibrarys.Entities.DTO;
using RestaurantLibrarys.Entities.EntitiesModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //user ın apimiz ile token vasıtasıyla haberleşmek için giriş yapabişleceği token alabileceği kullanıcı bilgisini görüntüleyebileceği endpointleri yazdık.  
        Result _result = new Result();

        private readonly AppSettings _appSettings;
        private readonly RestaurantDbContext _context;

        public LoginController(IOptions<AppSettings> appSettings, RestaurantDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public List<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        [HttpPost("login")]
        public AutResponseDTO Login(AutRequestDTO model)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            // burada başarıyla giriş yapmış ve sistemde kayıtlı olan kullanıcıya kullanıcı bilgilerini dönmek için data taşıma amacıyla oluşturduğumuz autresponsedto sınıfımızdan bir nesne oluşturup kullanıcı bilgilerini bu nesneye atıp bu nesneyi de kullanıcıya döndük.
            var response = new AutResponseDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Token = token
            };

            return response;
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
