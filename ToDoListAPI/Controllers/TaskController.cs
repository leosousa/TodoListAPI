using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpGet("tasks")]
        public string Index()
        {
            return "Teste";
        }
    }
}
