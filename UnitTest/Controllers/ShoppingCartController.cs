
using Microsoft.AspNetCore.Mvc;
using UnitTest.Model;
using UnitTest.Services;

namespace UnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService= shoppingCartService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var item =_shoppingCartService.GetAllItems();
            return Ok(item);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _shoppingCartService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _shoppingCartService.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var existingItem = _shoppingCartService.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _shoppingCartService.Remove(id);
            return NoContent();
        }
      
        [HttpPut]
        public IActionResult Update(ShoppingItem updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingItem = _shoppingCartService.GetById(updatedItem.Id);
            if (existingItem == null)
            {
                return NotFound();
            }

            // Update the existing item with the properties of the updated item
            existingItem.Name = updatedItem.Name;
            existingItem.Price = updatedItem.Price;
            existingItem.Manufacture = updatedItem.Manufacture;
            // Update other properties as needed

            // Call the service method to save the changes
            _shoppingCartService.Update(existingItem);

            return NoContent();
        }


    }
}
