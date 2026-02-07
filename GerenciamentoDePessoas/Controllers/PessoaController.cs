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

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Index()
        {
            var pessoaServiceResponse = await _pessoaService.BuscarTodos();
            return View(pessoaServiceResponse);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _pessoaService.Criar(pessoa);

                    TempData["Sucesso"] = $"Usuário {pessoa.Nome} craido com sucesso!";
                    return RedirectToAction("Index", "Pessoa");
                }
                return View(pessoa);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View(pessoa);
            }


        }
    }
}
