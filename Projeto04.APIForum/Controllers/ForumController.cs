using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto03.AcessoDados.DAL;
using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;

namespace Projeto04.APIForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly ForumDao forumDao;

        public ForumController(ForumContext context) 
        { 
            forumDao = new ForumDao(context);
        }
        [HttpGet]
        public IEnumerable<Forum> GetForums()
        {
            return forumDao.Listar();
        }

        [HttpPost]
        public Forum PostForum(Forum forum)
        {
            forumDao.Executar(forum, TipoOperacao.Added);
            return forum;
        }
        [HttpPut]
        public Forum PutForum(Forum forum)
        {
            forumDao.Executar(forum, TipoOperacao.Modified);
            return forum;
        }
        [HttpDelete]
        public IActionResult Delete(Forum forum)
        {
            try
            {
                forumDao.Executar(forum, TipoOperacao.Deleted);
                return Ok("Deletado com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
