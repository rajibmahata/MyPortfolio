using Microsoft.AspNetCore.Mvc;
using MyPortfolio.API.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPortfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioTypeController : ControllerBase
    {
        // GET: api/<PortfolioTypeController>
        [HttpGet]
        public IEnumerable<PortfolioType> Get()
        {
            IEnumerable<PortfolioType> portfolioTypes;
            using (var dbContext = new MyPortfolioDbContext())
            {
               
                if (!dbContext.PortfolioTypes.Any())
                {
                    dbContext.PortfolioTypes.AddRange(new PortfolioType[]
                        {
                             new PortfolioType{ ID=1, Type="Individual", },
                             new PortfolioType{ ID=2, Type="Organizational", },
                        });
                    dbContext.SaveChanges();
                }
                portfolioTypes = dbContext.PortfolioTypes.ToList();
            }
            return portfolioTypes;
        }

        // GET api/<PortfolioTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PortfolioTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PortfolioTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PortfolioTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
