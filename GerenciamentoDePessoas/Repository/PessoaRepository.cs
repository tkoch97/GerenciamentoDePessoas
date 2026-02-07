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

        public async Task<List<Pessoa>> BuscarTodosAsync()
        {
            var usariosBanco = await _context.Pessoas.ToListAsync();

            return usariosBanco;
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
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

            return pessoa;
        }

        public async Task<bool> VerificarSeUsuarioExiste(string cpf)
        {
            var usuarioExiste = await _context.Pessoas.AnyAsync(user => user.CPF == cpf);
            return usuarioExiste;
        }
    }
}
