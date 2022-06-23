using MyPortfolio.API.Entities;
using MyPortfolio.API.Services.Interface;

namespace MyPortfolio.API.GraphQL
{
    public class Mutuation
    {
        #region Property  
        private readonly IPortfolioService<PortfolioType> _portfolioTypeService;
        private readonly IPortfolioService<Skill> _skillService;
        private readonly IPortfolioService<Portfolio> _portfolioService;
        private readonly IPortfolioService<PortfolioSummary> _portfolioSummaryService;
        private readonly IPortfolioService<PortfolioUser> _portfolioUserService;
        #endregion

        #region Constructor  
        public Mutuation(IPortfolioService<PortfolioType> portfolioTypeService, IPortfolioService<Skill> skillService,
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
        public async Task<PortfolioType> CreatePortfolioType(PortfolioType portfolioTypes) => await _portfolioTypeService.Insert(portfolioTypes);
        public async Task<PortfolioType> UpdatePortfolioType(PortfolioType portfolioTypes) => await _portfolioTypeService.Update(portfolioTypes);
        public async Task<bool> DeletePortfolioType(long id) => await _portfolioTypeService.Delete(id);

        public async Task<Skill> CreateSkill(Skill skill) => await _skillService.Insert(skill);
        public async Task<Skill> UpdateSkill(Skill skill) => await _skillService.Update(skill);
        public async Task<bool> DeleteSkill(long id) => await _skillService.Delete(id);

        public async Task<Portfolio> CreatePortfolio(Portfolio portfolio) => await _portfolioService.Insert(portfolio);
        public async Task<Portfolio> UpdatePortfolio(Portfolio portfolio) => await _portfolioService.Update(portfolio);
        public async Task<bool> DeletePortfolio(long id) => await _portfolioService.Delete(id);

        public async Task<PortfolioSummary> CreatePortfolioSummary(PortfolioSummary portfolioSummary) => await _portfolioSummaryService.Insert(portfolioSummary);
        public async Task<PortfolioSummary> UpdatePortfolioSummary(PortfolioSummary portfolioSummary) => await _portfolioSummaryService.Update(portfolioSummary);
        public async Task<bool> DeletePortfolioSummary(long id) => await _portfolioSummaryService.Delete(id);

        public async Task<PortfolioUser> CreatePortfolioUser(PortfolioUser portfolioUser) => await _portfolioUserService.Insert(portfolioUser);
        public async Task<PortfolioUser> UpdatePortfolioUser(PortfolioUser portfolioUser) => await _portfolioUserService.Update(portfolioUser);
        public async Task<bool> DeletePortfolioUser(long id) => await _portfolioUserService.Delete(id);
    }
}
