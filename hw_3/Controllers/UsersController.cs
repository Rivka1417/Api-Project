using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
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
        UserService userService=new UserService();

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
            User user = userService.GetUserById(id);
            if (user != null)
                return CreatedAtAction(nameof(Get), user);
            return NotFound();
        }
        

        // POST api/<LoginController>
        [HttpPost]
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
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            return CreatedAtAction(nameof(Get),userService.UpdateUser(id,userToUpdate));
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
