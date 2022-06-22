using MyPortfolio.API.Entities;
using MyPortfolio.API.Services.Interface;

namespace MyPortfolio.API.GraphQL
{
    public class Mutuation
    {
        #region Property  
        private readonly IPortfolioService<PortfolioType> _portfolioTypeService;
        private readonly IPortfolioService<Skill> _skillService;
        #endregion

        #region Constructor  
        public Mutuation(IPortfolioService<PortfolioType> portfolioTypeService, IPortfolioService<Skill> skillService)
        {
            _portfolioTypeService = portfolioTypeService;
            _skillService = skillService;
        }
        #endregion
        public async Task<PortfolioType> CreatePortfolioType(PortfolioType portfolioTypes) => await _portfolioTypeService.Insert(portfolioTypes);
        public async Task<PortfolioType> UpdatePortfolioType(PortfolioType portfolioTypes) => await _portfolioTypeService.Update(portfolioTypes);
        public async Task<bool> DeletePortfolioType(long id) => await _portfolioTypeService.Delete(id);

        public async Task<Skill> CreateSkill(Skill skill) => await _skillService.Insert(skill);
        public async Task<Skill> UpdateSkill(Skill skill) => await _skillService.Update(skill);
        public async Task<bool> DeleteSkill(long id) => await _skillService.Delete(id);
    }
}
