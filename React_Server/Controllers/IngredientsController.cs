using Microsoft.AspNetCore.Mvc;
using React_Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        // GET: api/<IngredientsController>
        [HttpGet]
        public List<Ingredient> Get()
        {
            return Ingredient.GetIngs();
        }

        // GET api/<IngredientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public bool Post([FromBody] Ingredient ing)
        {
            return ing.PostIng();
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
