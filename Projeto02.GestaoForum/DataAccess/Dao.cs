using Dapper.Contrib.Extensions;
using Projeto02.GestaoForum.Models;
using System.Data.SqlClient;

namespace Projeto02.GestaoForum.DataAccess
{
    public class Dao
    {
        string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_FORUM;Integrated Security=SSPI;TrustServerCertificate=True";

        public IEnumerable<Forum> ListarForuns()
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.GetAll<Forum>();
            }
        }

        public long IncluirForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Insert<Forum>(forum);
            }
        }

        public Forum BuscarForum(int id)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Get<Forum>(id);
            }
        }

        public bool AlterarForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Update<Forum>(forum);
            }
        }

        public bool RemoverForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Delete<Forum>(forum);
            }
        }
    }
}
