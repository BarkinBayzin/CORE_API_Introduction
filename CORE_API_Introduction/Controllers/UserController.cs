using CORE_API_Introduction.DummyData;
using CORE_API_Introduction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CORE_API_Introduction.Controllers
{
    [Route("api/[controller]")]//api/User
    [ApiController]
    public class UserController : ControllerBase
    {
        // localhost:PortNo/api/user URL'ine istekte bulunduğumuzda bu metodu tetiklemiş oluyoruz. Sistemimiz çalışıyor.

        //public string Get()
        //{
        //    return "Merhaba Web API";
        //}

        private List<User> _userList = FakeData.GetUsers(250);

        [HttpGet]
        public List<User> Get()
        {
            return _userList;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _userList.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromQuery] User user) //FromBody, gönderilen isteğin body kısmında bir user nesnesi beklenir. Gönderilen user nesnesi karşılanır aşağıdaki yapı ile listeye eklener, .NET Core'da FromBody default olarak siz yazmasanızda karşılanacak alandır.
        {
            _userList.Add(user);
            return user;
        }

        [HttpPut] //API içerisinde bir güncelleme işlemi yapılacaksa, restful yapısı gereği de HTTPPUT atrribute'u ile işaretlememiz gerekir.
        public User Put(User user)
        {
            User guncellenecekUser = _userList.FirstOrDefault(x => x.Id == user.Id);
            guncellenecekUser.FirstName = user.FirstName;
            guncellenecekUser.LastName = user.LastName;
            guncellenecekUser.Address = user.Address;
            return user;
        }

        [HttpDelete] //Delete de keza aynı sebeplerden dolayı HttpDelete Attribute'u ile işaretlenmesi gerekir.
        public void Delete(int id)
        {
            var silinecekUser = _userList.FirstOrDefault(x => x.Id == id);
            _userList.Remove(silinecekUser);
        }
    }
}
