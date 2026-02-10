using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _context;

        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var pessoasBanco = await _context.Pessoas.AsNoTracking().ToListAsync();

            return pessoasBanco;
        }

        public async Task Criar(Pessoa pessoa)
        {
            try
            {
                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados: {ex.Message}");
            }
        }

        public async Task<bool> VerificarSePessoaExiste(string cpf)
        {
            var pessoaExiste = await _context.Pessoas.AnyAsync(user => user.CPF == cpf);
            return pessoaExiste;
        }

        public async Task<Pessoa?> BuscarPorIdParaExibir(int id)
        {
            return await _context.Pessoas.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<Pessoa?> BuscarPorIdParaEditar(int id)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task Editar(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
