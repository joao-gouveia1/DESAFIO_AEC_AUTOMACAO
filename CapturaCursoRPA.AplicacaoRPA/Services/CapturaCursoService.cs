using CapturaCursoRPA.AplicacaoRPA.Interfaces;
using CapturaCursoRPA.Dominio.Entities;
using CapturaCursoRPA.Dominio.Repositories;

namespace CapturaCursoRPA.AplicacaoRPA.Services
{
    public class CapturaCursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IBrowserDriver _browserDriver;

        public CapturaCursoService(ICursoRepository cursoRepository, IBrowserDriver browserDriver)
        {
            this._cursoRepository = cursoRepository;
            this._browserDriver = browserDriver;
        }

        public void CapturarCurso()
        {
            // Acessar o site da Alura
            _browserDriver.AcessarUrl("https://www.alura.com.br/");

            // Mandar texto para barra de pesquisa
            _browserDriver.EnviarTextoPorId("header-barraBusca-form-campoBusca", "RPA");

            // Enviar submit para fazer a pesquisa
            _browserDriver.EnviarSubmitPorId("header-barraBusca-form-campoBusca");

            // Verificar se apareceu botão de opções e filtros
            bool carregouBotao = _browserDriver.VerificarElementoExistePorXPath("/html/body/div[2]/div[2]/section/ul");

            if (carregouBotao)
            {
                // Clicar no botão de opções e filtros
                _browserDriver.ClicarElementoPorXPath("/html/body/div[2]/div[2]/div/span");
            }

            // Clicar no filtro "Cursos"
            _browserDriver.ClicarElementoPorXPath("/html/body/div[2]/div[1]/div[2]/ul/li[1]/label");
            //_browserDriver.ClicarElementoPorId("type-filter--0");

            // Digitar a pesquisa novamente
            _browserDriver.EnviarTextoPorId("busca-form-input", "RPA");

            // Enviar submit de pesquisa
            _browserDriver.EnviarSubmitPorId("busca-form-input");

            // Verificar se apareceu pesquisa
            bool carregouResultado = _browserDriver.VerificarElementoExistePorXPath("/html/body/div[2]/div[2]/section/ul");

            if (carregouResultado)
            {
                // Capturar título do primeiro curso
                string titulo = _browserDriver.CapturarTextoPorXPath("/html/body/div[2]/div[2]/section/ul/li/a/div/h4").Trim();

                // Clicar no curso
                _browserDriver.ClicarElementoPorXPath("/html/body/div[2]/div[2]/section/ul/li/a/div/h4");

                // Capturar carga horária
                string cargaHoraria = _browserDriver.CapturarTextoPorXPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]");

                // Capturar nome professor
                string nomeProfessor = _browserDriver.CapturarTextoPorXPath("/html/body/section[2]/div[1]/section/div/div/div/h3");

                // Capturar descrição
                string descricao = _browserDriver.CapturarTextoPorXPath("/html/body/section[2]/div[1]/div/ul");

                // Adicionar no BD
                Curso curso = new Curso(titulo, nomeProfessor, cargaHoraria, descricao);
                _cursoRepository.Adicionar(curso);
            }
            else
            {
                // Log dizendo que pesquisa não teve resultado
            }

            _browserDriver.EncerrarWebDriver();
        }
    }
}
