using BLL.Abstraction;
using dataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restaurant;

        public RestaurantController(IRestaurant restaurant)
        {
            _restaurant = restaurant;
        }
        // GET: api/<RestaurantController>
        [HttpGet("All")]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurant.GetListRestaurant();
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public ActionResult GetRestaurantById(int id)
        {
            var res=_restaurant.GetRestaurant(id);
            if(res==null)
                return NotFound();
            return Ok(res);

        }

        // POST api/<RestaurantController>
        [HttpPost("Add")]
        public ActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            var res= _restaurant.AddRestaurant(restaurant);
            if(!res)
                return BadRequest();
            return Ok();
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("Update")]
        public ActionResult UpdateRestaurant([FromBody] Restaurant restaurant)
        {
            var res = _restaurant.UpdateRestaurant(restaurant);
            if(!res)
                return BadRequest();
            return Ok("Update successFully");
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
           var res= _restaurant.DeleteRestaurant(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}
