using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;

using Application.Common;
using DataAccessLayer.Model.Core;

using Application.Domains.Core.User.Queries.GetUser;
using Application.Domains.Core.User.Queries.GetUserList;
using Application.Domains.Core.User.Commands.CreateUser;
using Application.Domains.Core.User.Commands.UpdateUser;
using Application.Domains.Core.User.Commands.DeleteUser;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _mediator.Send(new GetUserQuery { Id = id });

            return User;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateUserCommand { User = User});

            return result; //  CreatedAtAction("CreateUser", result); // NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            //            _context.User.Add(User);
            var result = await _mediator.Send(new CreateUserCommand { User = User});

            return result;
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {

            await _mediator.Send(new DeleteUserCommand { Id = id});

            return NoContent();
        }


        // GET: api/User/5
        [Route("UserView")]
        [HttpGet]
        public async Task<ActionResult> GetUserView(
            
      )
        {
            var result = await _mediator.Send(new GetUserListQuery
            {
                
            }
            );

            return Ok(result.ToList());
        }

    }
}
