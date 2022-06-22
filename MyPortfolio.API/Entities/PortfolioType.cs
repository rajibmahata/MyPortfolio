using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.API.Entities
{
    public class PortfolioType : BaseEntity
    {
     
        [Required]
        public string Type { get; set; }
       
    }
}
