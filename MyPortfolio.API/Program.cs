using Microsoft.EntityFrameworkCore;
using MyPortfolio.API;
using MyPortfolio.API.GraphQL;
using MyPortfolio.API.Services;
using MyPortfolio.API.Services.Interface;
using GraphQL.Server.Ui.Voyager;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = MyPortfolio.API.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);

using (var db = new MyPortfolioDbContext())
{
    //db.Database.EnsureCreated();
    db.Database.Migrate();
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MyPortfolioDbContext>();
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutuation>();
builder.Services.AddScoped(typeof(IPortfolioService<>), typeof(PortfolioService<>));
builder.Services.AddGraphQLServer()
   .AddQueryType<Query>()
   .AddMutationType<Mutuation>()
   .AddProjections()
   .RegisterDbContext<MyPortfolioDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.UseGraphQLVoyager();

app.Run();
