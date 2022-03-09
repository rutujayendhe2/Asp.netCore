using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sabji_MartDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        Sabji_MartContext context = new Sabji_MartContext();
        OrderRepository repository = new OrderRepository();

        [HttpGet]
        public IActionResult GetOrderRecord()
        {

            var order2 = repository.GetOrderRecord();

            return Ok(order2);
        }





        [HttpPost]

        public IActionResult AddOrderRecord(Order order)
        {
            return Ok( repository.AddOrderRecord(order));

        }

        
        [HttpPut]
        public IActionResult Edit([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateOrderRecord(order);
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("{id}")]
        public Order Details(int id)
        {
            return repository.GetOrderSingleRecord(id);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = repository.GetOrderSingleRecord(id);
            if (data == null)
            {
                return NotFound();

            }
            repository.DeleteOrderRecord(id);
            return Ok();
        }

    }
}

