using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodos();
        Task<bool> VerificarSePessoaExiste(string cpf);
        Task Criar(Pessoa pessoa);
        Task<Pessoa?> BuscarPorIdParaExibir(int id);
        Task<Pessoa?> BuscarPorIdParaEditar(int id);
        Task Editar(Pessoa pessoa);
        Task Apagar(Pessoa pessoa);
    }
}
