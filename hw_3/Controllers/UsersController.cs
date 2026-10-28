using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
//fix: Removed "using Microsoft.Extensions.Configuration.UserSecrets;" and "using Microsoft.OpenApi;" - they were added by mistake and are not used

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hw_3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        readonly string filePath = "./users.txt";
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
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        //CreatedAtAction returns 201 (Created), but nothing was created here. Return Ok(user) instead
                        return CreatedAtAction(nameof(Get), user);
                }
                return NotFound();
            }
            
        }
        

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserId },user);
        }


        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("login")]

        public IActionResult Post([FromBody] UserLogin userLogin)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == userLogin.Email && user.Password == userLogin.Password)
                        //Login doesn't create anything, so return Ok(user) instead of CreatedAtAction (201)
                        return CreatedAtAction(nameof(Get), user);
                }
            }
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }





        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                //fix: Keep the id, otherwise the updated user is saved without it
                userToUpdate.UserId = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
            //The assignment asks PUT to return Ok(): return Ok() here instead of CreatedAtAction (201 means something was created)
            return CreatedAtAction(nameof(Get),userToUpdate);
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
