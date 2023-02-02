using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto03.AcessoDados.DAL;
using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;
using Projeto03.AcessoDados.ViewModels;

namespace Projeto04.APIForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentariosDao comentariosDao;

        public ComentariosController(ForumContext context)
        {
            comentariosDao = new ComentariosDao(context);
        }
        [HttpGet]
        public IEnumerable<Comentario> GetComentarios()
        {
            return comentariosDao.Listar();
        }
        [HttpGet("{idForum}")]
        public IEnumerable<ForumComentariosVM> GetForumComentario(int idForum)
        {
            return comentariosDao.ListarComentariosPorForum(idForum);
        }
    }
}
