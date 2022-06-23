using MyPortfolio.API.Entities;

namespace MyPortfolio.API.GraphQL
{
    public class GraphQLPortfolioType : ObjectType<PortfolioType>
    {
    }
    public class GraphQLPortfolio : ObjectType<Portfolio>
    {
    }
    public class GraphQLPortfolioSummary : ObjectType<PortfolioSummary>
    {
    }

    public class GraphQLSkill : ObjectType<Skill>
    {
    }

    public class GraphQLPortfolioUser : ObjectType<PortfolioUser>
    {
    }
}
