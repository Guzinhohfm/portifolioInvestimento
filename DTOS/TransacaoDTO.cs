using System.ComponentModel.DataAnnotations;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.DTOS
{
    public class TransacaoDTO
    {
        public int InvestimentoId { get; set; }
        public int ClientId { get; set; }

        public string? NomeInvestimento { get; set; }

        [Required(ErrorMessage = "valor da transação é obrigatório")]
        public decimal ValorTransacao {  get; set; }

        public TipoTransacao TipoTransacao { get; set; }

    }
}
