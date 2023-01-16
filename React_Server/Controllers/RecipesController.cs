using Microsoft.AspNetCore.Mvc;
using React_Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        // GET: api/<RecipesController>
        [HttpGet]
        public List<Recipe> Get()
        {
            return Recipe.GetRecs();
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipesController>
        [HttpPost]
        public bool Post([FromBody] Recipe rec)
        {
            return rec.PostRec();
        }


        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
