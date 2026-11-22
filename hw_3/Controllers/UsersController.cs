//This using isn't used in this file: you can remove it
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
//This using isn't used in this file: you can remove it
using Microsoft.OpenApi;
using Service;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hw_3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IUserService userService;

        //The assignment asks this controller to take the password service's interface and call it: where is that service, and how would this controller use it?
        public UsersController(IUserService service)
        {
            this.userService = service;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            //The assignment asks GET by id to return 200 for an existing user: this returns 201 from CreatedAtAction, so return Ok(user) instead
            User user = userService.GetUserById(id);
            if (user != null)
                return CreatedAtAction(nameof(Get), user);
            return NotFound();
        }
        

        // POST api/<LoginController>
        [HttpPost]
        //The assignment asks a weak password (score below 3) to return 400 here: where would you check the password score before AddUser?
        public IActionResult Post([FromBody] User user)
        {
             return CreatedAtAction(nameof(Get), userService.AddUser(user));
        }


        [HttpPost("login")]

        public IActionResult Post([FromBody] UserLogin userLogin)
        {
            User user = userService.Login(userLogin);
            if (user != null)
                return CreatedAtAction(nameof(Get), user);
            //The assignment asks a wrong password to return 204 NoContent: NotFound gives 404 here, what would return 204?
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            //The assignment asks PUT to return Ok() (200): this returns 201 from CreatedAtAction, return Ok(...) instead
            //The assignment asks a weak password (score below 3) to return 400 here: check the password score before updating the user
            return CreatedAtAction(nameof(Get),userService.UpdateUser(id,userToUpdate));
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
