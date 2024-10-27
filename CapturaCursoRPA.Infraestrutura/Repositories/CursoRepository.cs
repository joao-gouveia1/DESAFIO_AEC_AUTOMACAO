using CapturaCursoRPA.Dominio.Entities;
using CapturaCursoRPA.Dominio.Repositories;
using CapturaCursoRPA.Infraestrutura.Data;

namespace CapturaCursoRPA.Infraestrutura.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly RPADbContext _context;

        public CursoRepository(RPADbContext _context)
        {
            this._context = _context;
        }

        public void Adicionar(Curso curso)
        {
            try
            {
                _context.Cursos.Add(curso);
                int retorno = _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o curso capturado.", e);
            }
        }

        public IEnumerable<Curso> ObterTodos()
        {
            try
            {
                return _context.Cursos.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter lista com todos os cursos capturados.", e);
            }
        }
    }
}
