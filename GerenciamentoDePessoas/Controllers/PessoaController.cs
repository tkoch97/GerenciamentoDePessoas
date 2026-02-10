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
        public IActionResult Criar()
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
                    await _pessoaService.Criar(pessoa);

                    TempData["Sucesso"] = $"Usuário {pessoa.Nome} criado com sucesso!";
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

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um Id do usuário deve ser informado");
                }
                var pessoaNoBanco = await _pessoaService.BuscarPorIdParaExibir(id);
                return View(pessoaNoBanco);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Index", "Pessoa");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == 0)
                {
                    throw new Exception("Um Id deve ser passado.");
                }
                if (!ModelState.IsValid)
                {
                    return View(pessoa);
                }
                await _pessoaService.Editar(pessoa);

                TempData["Sucesso"] = $"Pessoa de nome {pessoa.Nome} foi editado com sucesso";
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View(pessoa);
            }
        }
    }
}
