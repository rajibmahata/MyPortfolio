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
        #endregion

        #region Constructor  
        public Query(IPortfolioService<PortfolioType> portfolioTypeService, IPortfolioService<Skill> skillService)
        {
            _portfolioTypeService = portfolioTypeService;
            _skillService = skillService;
        }
        #endregion
        public Task<IQueryable<PortfolioType>> PortfolioTypes => _portfolioTypeService.GetAll();
        public Task<IQueryable<Skill>> Skills => _skillService.GetAll();
    }
}
