namespace Projeto04.APIForum.Class
{
    public class Listas
    {
        public static IEnumerable<Curso> ListAll()
        {

            return new List<Curso>()
            {
                new Curso() { Id = 10, Descricao = "Asp.NetCore", Ch=80, Preco =1000},
                new Curso() { Id = 11, Descricao = "DevOps", Ch = 50, Preco = 2000 },
                new Curso() { Id = 12, Descricao = "Azure", Ch = 30, Preco = 4000 },
                new Curso() { Id = 13, Descricao = "React", Ch = 80, Preco = 5000 },
                new Curso() { Id = 14, Descricao = "Angular", Ch = 80, Preco = 9000 }
            };
        }
    }
}
