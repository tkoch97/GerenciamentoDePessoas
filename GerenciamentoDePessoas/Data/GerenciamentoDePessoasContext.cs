using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoDePessoasContext : DbContext
    {
        public GerenciamentoDePessoasContext (DbContextOptions<GerenciamentoDePessoasContext> options)
            : base(options)
        {
        }

        public DbSet<GerenciamentoDePessoas.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}
