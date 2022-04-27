using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll_to_dbCinema;
using Microsoft.AspNetCore.Authorization;

namespace Web_Api_to_dbCinema.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUp : ControllerBase
    {
        dbCinemaEditor Data = new dbCinemaEditor();

        // POST <SignUp>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] Client newClient)
        {
            Data.signUp(newClient);
            return Created("user/self/" + newClient.ClientId, newClient);
        }
    }
}
