using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingW2025B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        // GET: localhost:xx/api/Test -> 7
        // GET: localhost:xx/api/Test/{id} -> {id}
        [HttpGet(template:"/api/Test/{id}")]
        public int Get(int id)
        {
            int difference = id * 10;
            return difference;
        }




    }
}
