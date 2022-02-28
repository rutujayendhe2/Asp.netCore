using Demo.Helper;
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
    public class UsersController : ControllerBase
    {
        Sabji_MartContext context = new Sabji_MartContext();

        UserRepository repository = new UserRepository();
        // GET: api/<User1Controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return repository.GetUsers().ToList();
        }


        // GET api/<User1Controller>/5
        [HttpGet("{id}")]
        public User Details(int id)
        {
            return repository.GetUserId(id);
        }




        [HttpPost]

        public IActionResult Create([FromBody] User user)
        {
            var id = repository.getCount();
            user.Id = id + 1;

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                user.Password = EncDscPassword.EncryptPassword(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Registeration succesfully"
                });
            }
        }
        

        //public IActionResult Create(User user)
        //{
        //    var id = repository.getCount();
        //    user.Id = id + 1;
        //    if (ModelState.IsValid)
        //    {
        //        //Guid obj = Guid.NewGuid();
        //        // employee.Id = obj();
        //        repository.AddUser(user);
        //        return Ok(user);
        //    }
        //    return BadRequest();
        //}



        // PUT api/<User1Controller>/5

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateUser(user);
                return Ok();
            }
            return BadRequest();
        }


        //DELETE api/<User1Controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = repository.GetUserId(id);
            if (data == null)
            {
                return NotFound();
            }
            repository.DeleteUserRecord(id);
            return Ok();
        }



    }
}

