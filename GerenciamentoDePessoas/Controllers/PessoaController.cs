using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task<ActionResult<List<Pessoa>>> Index()
        {
            var pessoaServiceResponse = await _pessoaService.BuscarTodos();
            return View(pessoaServiceResponse);
        }
    }
}
