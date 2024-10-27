using CapturaCursoRPA.Dominio.Entities;
using CapturaCursoRPA.Dominio.Repositories;

namespace CapturaCursoRPA.AplicacaoRPA.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            this._cursoRepository = cursoRepository;
        }

        public void AdicionarCurso(Curso curso)
        {
            _cursoRepository.Adicionar(curso);
        }

        public IEnumerable<Curso> ObterTodosCursos()
        {
            return _cursoRepository.ObterTodos();
        }
    }
}
