using portifolioInvestimento.Models;

namespace portifolioInvestimento.DTOS
{
    public class TransacaoDTO
    {
        public int investimentoId { get; set; }
        public int clientId { get; set; }
        public decimal valor {  get; set; }

    }
}
