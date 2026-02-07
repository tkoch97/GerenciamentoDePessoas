using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;

namespace GerenciamentoDePessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _pessoaRepository.BuscarTodosAsync();

            return usuariosBanco;
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            var usuarioExiste = await _pessoaRepository.VerificarSeUsuarioExiste(pessoa.CPF);
            if (usuarioExiste)
            {
                throw new Exception("Usuário já cadastrado no sistema");
            }
            else
            {
                var usuarioCriado = await _pessoaRepository.Criar(pessoa);
                return usuarioCriado;
            }
        }
    }
}
