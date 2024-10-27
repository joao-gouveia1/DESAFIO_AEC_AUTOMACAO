using CapturaCursoRPA.Dominio.Entities;

namespace CapturaCursoRPA.Dominio.Repositories
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> ObterTodos();
        void Adicionar(Curso curso);
    }
}
