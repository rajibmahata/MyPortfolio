using Microsoft.EntityFrameworkCore;
using MyPortfolio.API;
using MyPortfolio.API.GraphQL;
using MyPortfolio.API.Services;
using MyPortfolio.API.Services.Interface;
using GraphQL.Server.Ui.Voyager;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = MyPortfolio.API.GraphQL.Query;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyPortfolio.API.Utility;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//using (var db = new MyPortfolioDbContext())
//{
//    db.Database.EnsureCreated();
//    db.Database.Migrate();
//}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Global Exception Handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
//End Global Exception Handling

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });

    // Enable Swagger examples
    c.EnableAnnotations();
    c.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

builder.Services.AddScoped(typeof(IPortfolioService<>), typeof(PortfolioService<>));

//builder.Services.AddDbContext<MyPortfolioDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MyPortfolioSQLContext")));

builder.Services.AddDbContext<MyPortfolioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyPortfolioSQLContext"))
           .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

//builder.Services.AddEntityFrameworkSqlite().AddDbContext<MyPortfolioDbContext>();
//builder.Services.AddScoped<Query>();
//builder.Services.AddScoped<Mutuation>();
//builder.Services.AddGraphQLServer()
//   .AddQueryType<Query>()
//   .AddMutationType<Mutuation>()
//   .AddProjections()
//   .RegisterDbContext<MyPortfolioDbContext>();

var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyPortfolioDbContext>();
    dbContext.Database.EnsureCreated();
   // dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGraphQL();

//app.UseGraphQLVoyager();

//Global Exception Handling
app.UseExceptionHandler();
//End Global Exception Handling

app.Run();
