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
    public class ProductsController : ControllerBase
    {
        Sabji_MartContext context = new Sabji_MartContext();

        ProductsRepository repository = new ProductsRepository();
        // GET: api/<User1Controller>
        [HttpGet]

        public IEnumerable<Productlist> Get()
        {
            return repository.GetProducts().ToList();
        }


        // GET api/<User1Controller>/5
        [HttpGet("{id}")]
        public Productlist Details(int id)
        {
            return repository.GetProductId(id);
        }




        [HttpPost]
        //public IActionResult AddProductlist(Productlist productlist)
        //{
        //    return Ok(repository.AddProductlist(productlist));

        //}

        public IActionResult Create(Productlist productlist)
        {

            var id = repository.getCount();
            productlist.Id = id + 1;
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                // employee.Id = obj();

                return Ok(repository.AddProductlist(productlist));
            }
            return BadRequest();
        }


        [HttpPut]
        public IActionResult Edit([FromBody] Productlist productlist)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateProductlist(productlist);
                return Ok();
            }
            return BadRequest();
        }


        //DELETE api/<User1Controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = repository.GetProductId(id);
            if (data == null)
            {
                return NotFound();
            }
            repository.DeleteProductRecord(id);
            return Ok();
        }


    }
}

