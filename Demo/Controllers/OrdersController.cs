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
            //return JsonConvert.DeserializeObject<List<Order>>(order2);
        }

        //public IEnumerable<Order> Get()
        // {
        //  return _orderdata.GetOrderRecord();
        // }



        [HttpPost]

        public IActionResult AddOrderRecord(Order order)
        {
            return Ok( repository.AddOrderRecord(order));

        }

        //[HttpPost]
        //public IActionResult Create([FromBody] Order order)
        //{
        // var order1 = new Order();
        //order1.fullname = order.fullname;
        //order1.address = order.address;
        //order1.city = order.city;
        // order1.country = order.country;
        // order1.email = order.email;
        // order1.phone = order.phone;
        // order1.state = order.state;
        // order1.status = order.status;
        // order1.totalprice = order.totalprice;
        // order1.updatedAt = order.updatedAt;
        // order1.createdAt = order.createdAt;
        // order1.zip = order.zip;
        //order1.user = order.user;
        //order1.productList = order.productList;
        //_orderdata.AddOrderRecord(order);
        //return Ok();

        //}
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

