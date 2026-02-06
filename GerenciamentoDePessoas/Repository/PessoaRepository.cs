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
    }
}
