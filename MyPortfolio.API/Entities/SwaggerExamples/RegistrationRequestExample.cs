using MyPortfolio.API.Entities.RequestModel;

namespace MyPortfolio.API.Entities.SwaggerExamples
{
    public class RegistrationRequestExample : Swashbuckle.AspNetCore.Filters.IExamplesProvider<MyPortalRequest>
    {
        public MyPortalRequest GetExamples()
        {
            return new MyPortalRequest
            {
                Username = "rajibmahata",
                Password = "12345678",
                IsActive = true
            };

        }
    }

   
}
