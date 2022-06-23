namespace MyPortfolio.API.Entities
{
    public class Portfolio :BaseEntity
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string SkypeId { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Others { get; set; }
        public ICollection<PortfolioSummary> PortfolioSummaries { get; set; }

        public ICollection<PortfolioUser> PortfolioUsers { get; set; }

    }
}
