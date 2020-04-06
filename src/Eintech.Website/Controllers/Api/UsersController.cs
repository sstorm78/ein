using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Eintech.Services;
using Eintech.Website.Extensions;
using Eintech.Website.UiModels;
using Microsoft.AspNetCore.Mvc;

namespace Eintech.Website.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]User resource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userModel = resource.ToModel();
                var newUserId = await _userService.Create(userModel);
                return Created(new Uri("http://localhost:5000/api/users/" + newUserId), newUserId);
            }
            catch (Exception ex)
            {
                //logging is not implemented because it is out of scope
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("keyword parameter is required");
            }

            try
            {
                var users = await _userService.Search(keyword);

                var result = users.Select(UserModelExtensions.ToUiModel).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //logging is not implemented because it is out of scope
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}