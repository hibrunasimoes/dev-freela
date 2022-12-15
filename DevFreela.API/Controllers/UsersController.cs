using System;
using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class UsersController : ControllerBase
    {
        public UsersController(ExampleClass exampleClass)
        {
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }

        [HttpPost("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}