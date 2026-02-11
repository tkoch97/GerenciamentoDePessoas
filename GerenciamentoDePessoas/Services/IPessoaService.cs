using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodos();
        Task Criar(Pessoa pessoa);
        Task<Pessoa> BuscarPorIdParaExibir(int id);
        Task Editar(Pessoa pessoa);
        Task Apagar(int id);
    }
}
