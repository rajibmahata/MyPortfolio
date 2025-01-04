using MyPortfolio.API.Entities.RequestModel;

namespace MyPortfolio.API.Entities.SwaggerExamples
{
    public class LoginRequestExample : Swashbuckle.AspNetCore.Filters.IExamplesProvider<LoginRequestModel>
    {
        public LoginRequestModel GetExamples()
        {
            return new LoginRequestModel
            {
                Username = "rajibmahata",
                Password = "12345678",
            };

        }
    }

   
}
