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
            var pessoasBanco = await _pessoaRepository.BuscarTodos();

            return pessoasBanco;
        }

        public async Task Criar(Pessoa pessoa)
        {
            var pessoaExiste = await _pessoaRepository.VerificarSePessoaExiste(pessoa.CPF);
            if (pessoaExiste)
            {
                throw new Exception("Pessoa já cadastrada no sistema");
            }
            else
            {
                await _pessoaRepository.Criar(pessoa);
            }
        }

        public async Task<Pessoa> BuscarPorIdParaExibir(int id)
        {
            var pessoaNoBanco = await _pessoaRepository.BuscarPorIdParaExibir(id);
            if (pessoaNoBanco == null)
                throw new Exception("Pessoa não encontrada no banco");
            return pessoaNoBanco;
        }

        public async Task Editar(Pessoa pessoa)
        {
            var pessoaParaEditar = await _pessoaRepository.BuscarPorIdParaEditar(pessoa.Id);

            pessoaParaEditar!.Nome = pessoa.Nome;
            pessoaParaEditar.Sobrenome = pessoa.Sobrenome;
            pessoaParaEditar.DataNascimento = pessoa.DataNascimento;
            pessoaParaEditar.CPF = pessoa.CPF;
            pessoaParaEditar.TipoSanguineo = pessoa.TipoSanguineo;

            await _pessoaRepository.Editar(pessoaParaEditar);
        }
    }
}
