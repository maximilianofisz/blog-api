using api_blog;
using api_blog.Models;
using Blog.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Messaging.Api.Controllers
{
    [Route("api/users")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository repository;

        public UsersController(UsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpHead]
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<Users> users = this.repository.FindAll();
            IEnumerable<UserDTO> result = new List<UserDTO>();
            foreach(Users user in users)
            {
                UserDTO userdto = new UserDTO();
                userdto.Id = user.Id;
                userdto.Name = user.Name;
            }

            return Ok(result);
        }


        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserById([FromRoute] int id)
        {
            Users user = repository.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            UserDTO response = new UserDTO();
            response.Id = user.Id;
            response.Name = user.Name;

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<UserDTO> AddUser([FromBody][Required] UserForCreationDTO userToCreate)
        {
            Users user = new Users();
            user.Name = userToCreate.Name;
            user.CreatedBy = userToCreate.CreatedBy;
            user.CreatedDate = DateTime.Now;

            this.repository.Save(user);
            this.repository.SaveChanges();

            return NoContent();
        }
    }
}
