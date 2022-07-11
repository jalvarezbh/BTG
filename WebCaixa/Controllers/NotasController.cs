using CaixaDomain.Interfaces;
using CaixaDomain.Models;
using CaixaService.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebCaixa.Models;

namespace WebCaixa.Controllers
{
    public class NotasController : Controller
    {
        private IBaseService<Notas> _baseNotasService;

        public NotasController(IBaseService<Notas> baseNotasService)
        {
            _baseNotasService = baseNotasService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var quantidadesNotas = _baseNotasService.Get<NotasBancoViewModel>();

            var retorno = new NotasViewModel();

            if(quantidadesNotas != null)
            {
                retorno.IdNotas10 = quantidadesNotas.FirstOrDefault(f => f.Valor == 10)?.Id;
                retorno.QuantidadeNotas10 = quantidadesNotas.FirstOrDefault(f => f.Valor == 10)?.Quantidade;
                retorno.IdNotas20 = quantidadesNotas.FirstOrDefault(f => f.Valor == 20)?.Id;
                retorno.QuantidadeNotas20 = quantidadesNotas.FirstOrDefault(f => f.Valor == 20)?.Quantidade;
                retorno.IdNotas50 = quantidadesNotas.FirstOrDefault(f => f.Valor == 50)?.Id;
                retorno.QuantidadeNotas50 = quantidadesNotas.FirstOrDefault(f => f.Valor == 50)?.Quantidade;
                retorno.IdNotas100 = quantidadesNotas.FirstOrDefault(f => f.Valor == 100)?.Id;
                retorno.QuantidadeNotas100 = quantidadesNotas.FirstOrDefault(f => f.Valor == 100)?.Quantidade;
            }

            return View(retorno);
        }

        [HttpPost]
        public IActionResult Gravar([FromForm] NotasViewModel notas)
        {
            var notas10 = new NotasBancoViewModel() { Id = notas.IdNotas10 };

            AtualizarNota(notas10, notas.QuantidadeNotas10, 10);

            var notas20 = new NotasBancoViewModel() { Id = notas.IdNotas20 };

            AtualizarNota(notas20, notas.QuantidadeNotas20, 20);

            var notas50 = new NotasBancoViewModel() { Id = notas.IdNotas50 };

            AtualizarNota(notas50, notas.QuantidadeNotas50, 50);

            var notas100 = new NotasBancoViewModel() { Id = notas.IdNotas100 };

            AtualizarNota(notas100, notas.QuantidadeNotas100, 100);


            return View("Index", notas);
        }

        private void AtualizarNota(NotasBancoViewModel nota, int? quantidade, decimal valor)
        {
            nota.Valor = valor;
            nota.Quantidade = quantidade.HasValue ? quantidade.Value : 0;
            nota.DataAtualizacao = DateTime.Now;

            if (nota.Id == null)
            {
                _baseNotasService.Add<NotasBancoViewModel, NotasBancoViewModel, NotasValidator>(nota);
            }
            else
            {
                _baseNotasService.Update<NotasBancoViewModel, NotasBancoViewModel, NotasValidator>(nota);
            }
        }

    }
}
