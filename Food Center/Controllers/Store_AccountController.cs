using Food_Center.Model;
using Food_Center.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Center.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class Store_AccountController : ControllerBase
    {
        private readonly IStore_AccountRepository _store_AccountRepository;

        public Store_AccountController(IStore_AccountRepository store_AccountRepository)
        {
            _store_AccountRepository = store_AccountRepository;
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> RoleAdded(RoleModel roleModel)
        {
            var result = _store_AccountRepository.AddRole(roleModel);
            return Ok(result);
        }


        [HttpPost("Signup")]
        public async Task<IActionResult> Store_SignUp(Store_SignUpModel store_SignUpModel)
        {
            var result = _store_AccountRepository.SignUp(store_SignUpModel);
            return Ok(result.Result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]LoginModel loginModel)
        {
            var result = await _store_AccountRepository.Login(loginModel);
            if(result==null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
