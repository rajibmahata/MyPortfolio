using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.API.Entities
{
    public class PortfolioSummary : BaseEntity
    {
        [ForeignKey("Portfolio")]
        public long PortfolioID { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Summary { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
