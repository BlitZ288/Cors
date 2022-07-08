using Cors.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cors.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]        
        public User GetUser()
        {
           return new User("Roma",25);
        }
        [HttpPost]
        public User AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            
            return user;
        }
        [HttpPut]
        public string PutUser()
        {
            return "Value: PUT";
        }
    }
}