using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingApi : ControllerBase
    {
        private readonly DbHelper _db;

        //constructor of the controller class

        public ShoppingApi(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        // GET: api/<ShoppingApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShoppingApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShoppingApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShoppingApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShoppingApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
