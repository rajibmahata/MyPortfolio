using HotChocolate;
using MyPortfolio.API.Entities;
using MyPortfolio.API.Services.Interface;

namespace MyPortfolio.API.GraphQL
{
    public class Query
    {
        #region Property  
        private readonly IPortfolioService<PortfolioType> _portfolioTypeService;
        private readonly IPortfolioService<Skill> _skillService;
        private readonly IPortfolioService<Portfolio> _portfolioService;
        private readonly IPortfolioService<PortfolioSummary> _portfolioSummaryService;
        private readonly IPortfolioService<PortfolioUser> _portfolioUserService;
        #endregion

        #region Constructor  
        public Query(IPortfolioService<PortfolioType> portfolioTypeService, IPortfolioService<Skill> skillService, 
            IPortfolioService<Portfolio> portfolioService, IPortfolioService<PortfolioSummary> portfolioSummaryService,
            IPortfolioService<PortfolioUser> portfolioUserService)
        {
            _portfolioTypeService = portfolioTypeService;
            _skillService = skillService;
            _portfolioService = portfolioService;
            _portfolioSummaryService = portfolioSummaryService;
            _portfolioUserService = portfolioUserService;
        }
        #endregion
        public Task<IQueryable<PortfolioType>> PortfolioTypes => _portfolioTypeService.GetAll();
        public Task<IQueryable<Skill>> Skills => _skillService.GetAll();
        public Task<IQueryable<Portfolio>> Portfolios => _portfolioService.GetAll();
        public Task<IQueryable<PortfolioSummary>> PortfolioSummaries => _portfolioSummaryService.GetAll();
        public Task<IQueryable<PortfolioUser>> PortfolioUsers => _portfolioUserService.GetAll();
    }
}
