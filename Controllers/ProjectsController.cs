using Hitosapi.Data;
using Hitosapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hitosapi.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController
    {
        [HttpGet]
        public async Task<ActionResult<List<Mprojects>>> GetProjects() 
        {
            var function = new Dprojects();
            var list = await function.GetMprojects();
            return list;
        
        }
    }
}
