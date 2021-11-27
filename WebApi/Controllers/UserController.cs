using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        public static List<User> UserList = new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Ahmet",
                Email = "ahmet@gmail.com",
                BirthDate = new DateTime(1998,09,08)
            },
            new User
            {
                Id = 2,
                Name = "Ayse",
                Email = "ayse@gmail.com",
                BirthDate = new DateTime(1995,03,12)
            }
        };

        [HttpGet]
        public List<User> GetUserList()
        {
            return UserList;
        }

        [HttpGet("{id}")]
        public User GetUserList(int id)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            return user;
        }

        [HttpPost]
        public IActionResult Register([FromBody] User newUser)
        {
            var user = UserList.SingleOrDefault(user => user.Id == newUser.Id);

            if (user is not null)
            {
                return BadRequest();
            }

            UserList.Add(newUser);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            user.Name = updatedUser.Name == user.Name ? user.Name : updatedUser.Name;
            user.Email = updatedUser.Email == user.Email ? user.Email : updatedUser.Email;
            user.BirthDate = updatedUser.BirthDate == user.BirthDate ? user.BirthDate : updatedUser.BirthDate;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            UserList.Remove(user);
            return Ok();
        }
    }
}