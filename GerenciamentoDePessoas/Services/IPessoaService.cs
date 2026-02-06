using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        List<Pessoa> BuscarTodos();
    }
}
