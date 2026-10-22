using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hw_3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        string filePath = "./users.txt";
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public ActionResult<UserRegeister> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserRegeister user = JsonSerializer.Deserialize<UserRegeister>(currentUserInFile);
                    if (user.UserId == id)
                        return CreatedAtAction(nameof(Get), user);
                }
                return NotFound();
            }
            
        }
        

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] UserRegeister user)
        {
            
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserId },user);
        }


        [HttpPost("login")]

        public IActionResult Post([FromBody] UserLogin userLogin)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserRegeister user = JsonSerializer.Deserialize<UserRegeister>(currentUserInFile);
                    if (user.Email == userLogin.Email && user.Password == userLogin.Password)
                        return CreatedAtAction(nameof(Get), user);
                }
            }
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }





        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public ActionResult<UserRegeister> Put(int id, [FromBody] UserRegeister userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserRegeister user = JsonSerializer.Deserialize<UserRegeister>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
            return CreatedAtAction(nameof(Get), userToUpdate);
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
