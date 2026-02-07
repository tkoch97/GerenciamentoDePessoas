using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodosAsync();
        Task<bool> VerificarSeUsuarioExiste(string cpf);
        Task<Pessoa> Criar(Pessoa pessoa);
    }
}
