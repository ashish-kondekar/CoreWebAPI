using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Core;
using User.Core.Interfaces.Core;
using User.Repo;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCoreService userService;

        public UserController(IUserCoreService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await userService.GetUsers().ConfigureAwait(false);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await userService.GetUser(id).ConfigureAwait(false);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
