using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto04.APIForum.Class;

namespace Projeto04.APIForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string GetInfo()
        {
            return "TESTE";
        }

        [HttpGet("empresa")]
        public string Empresa()
        {
            return "ATOS";
        }
        [HttpGet("{id}")]
        public string Index(int id)
        {
            return $"Carga Horaria: {id}";
        }
        [HttpGet]
        [Route("lista")]
        public IEnumerable<Curso> GetCursos()
        {
            return Listas.ListAll();
        }
        [HttpGet]
        [Route("lista/{id}")]
        public Curso? GetCurso(int id)
        {
            return Listas.ListAll().Select(x => (x)).Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
