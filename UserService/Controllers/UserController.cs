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

        /// <summary>
        /// Get single user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await userService.GetUsers().ConfigureAwait(false);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserDTO> Get([FromRoute] int userId)
        {
            return await userService.GetUser(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var sysUser = await userService.CreateUser(user).ConfigureAwait(false);
            return Created(HttpContext.Request.Path, sysUser);
        }

        /// <summary>
        /// Update user 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        [HttpPut("{userId}")]
        public async Task<ActionResult> Put([FromRoute] int userId, [FromBody] UserDTO user)
        {
            await userService.UpdateUser(userId, user).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete([FromRoute] int userId)
        {
            await userService.DeleteUser(userId).ConfigureAwait(false);
            return Ok();
        }
    }
}
