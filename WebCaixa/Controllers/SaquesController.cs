using CaixaDomain.Interfaces;
using CaixaDomain.Models;
using CaixaService.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebCaixa.Models;

namespace WebCaixa.Controllers
{
    public class SaquesController : Controller
    {
        private IBaseService<Notas> _baseNotasService;
        private IBaseService<Saques> _baseSaquesService;

        public SaquesController(IBaseService<Notas> baseNotasService, IBaseService<Saques> baseSaquesService)
        {
            _baseNotasService = baseNotasService;
            _baseSaquesService = baseSaquesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var quantidadesNotas = _baseNotasService.Get<NotasBancoViewModel>();

            var retorno = new SolicitarSaqueViewModel();

            if (quantidadesNotas != null)
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
        public IActionResult EfetuarSaque([FromForm] SolicitarSaqueViewModel saque)
        {
            try
            {
                decimal valor10 = saque.QuantidadeNotas10.Value * 10;
                decimal valor20 = saque.QuantidadeNotas20.Value * 20;
                decimal valor50 = saque.QuantidadeNotas50.Value * 50;
                decimal valor100 = saque.QuantidadeNotas100.Value * 100;
                decimal valorTotal = valor10 + valor20 + valor50 + valor100;

                if (saque.ValorSaque < 0)
                    throw new Exception("Valo do Saque não pode ser negativo.");

                if (saque.ValorSaque > valorTotal)
                    throw new Exception("Valo do Saque acima do Valor Limite.");

                var retorno = new EfetivarSaqueViewModel();
                int valorEmAnalise = (int)saque.ValorSaque.Value;
                retorno.ValorSaque = valorEmAnalise;

                int teste100 = valorEmAnalise / 100;
                if (teste100 > 0 && valorEmAnalise > 0)
                {
                    retorno.QuantidadeNotas100 = (int)teste100;
                    valorEmAnalise -= teste100 * 100;
                }

                int teste50 = valorEmAnalise / 50;
                if (teste50 > 0 && valorEmAnalise > 0)
                {
                    retorno.QuantidadeNotas50 = (int)teste50;
                    valorEmAnalise -= teste50 * 50;
                }

                int teste20 = valorEmAnalise / 20;
                if (teste20 > 0 && valorEmAnalise > 0)
                {
                    retorno.QuantidadeNotas20 = (int)teste20;
                    valorEmAnalise -= teste20 * 20;
                }

                int teste10 = valorEmAnalise / 10;
                if (teste10 > 0 && valorEmAnalise > 0)
                {
                    retorno.QuantidadeNotas10 = (int)teste10;
                    valorEmAnalise -= teste10 * 10;
                }

                if (valorEmAnalise > 0)
                {
                    throw new Exception("Não foi possível realizar o Saque com as Notas disponiveis.");
                }

                var atualizaNota10 = saque.QuantidadeNotas10.Value - retorno.QuantidadeNotas10;
                AtualizarNota(saque.IdNotas10.Value, atualizaNota10, 10);
                var atualizaNota20 = saque.QuantidadeNotas20.Value - retorno.QuantidadeNotas20;
                AtualizarNota(saque.IdNotas20.Value, atualizaNota20, 20);
                var atualizaNota50 = saque.QuantidadeNotas50.Value - retorno.QuantidadeNotas50;
                AtualizarNota(saque.IdNotas50.Value, atualizaNota50, 50);
                var atualizaNota100 = saque.QuantidadeNotas100.Value - retorno.QuantidadeNotas100;
                AtualizarNota(saque.IdNotas100.Value, atualizaNota100, 100);

                SaquesViewModel saqueHistorico = new SaquesViewModel();
                saqueHistorico.Valor = saque.ValorSaque.Value;
                saqueHistorico.QuantidadeNotas = retorno.QuantidadeNotas10 + retorno.QuantidadeNotas20 + retorno.QuantidadeNotas50 + retorno.QuantidadeNotas100;
                saqueHistorico.Data = DateTime.Now;
                _baseSaquesService.Add<SaquesViewModel, SaquesViewModel, SaquesValidator>(saqueHistorico);

                return View("Extrato", retorno);
            }
            catch (Exception ex)
            {
                saque.Erro = ex.Message;
                return View("Index", saque);
            }
        }

        private void AtualizarNota(int id, int? quantidade, decimal valor)
        {
            NotasBancoViewModel nota = new NotasBancoViewModel();
            nota.Id = id;
            nota.Valor = valor;
            nota.Quantidade = quantidade.HasValue ? quantidade.Value : 0;
            nota.DataAtualizacao = DateTime.Now;            
            _baseNotasService.Update<NotasBancoViewModel, NotasBancoViewModel, NotasValidator>(nota);            
        }
    }
}
