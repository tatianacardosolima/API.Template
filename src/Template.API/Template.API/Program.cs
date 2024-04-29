using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Template.API.Setup;
using Template.DatabaseRepository.Context;
using Template.Domain.Commands.Request;
using Template.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(serviceProvider =>
{
    var connectionString = configuration.GetConnectionString("ConnectionStrings"); ;
    var options = new DbContextOptionsBuilder<TemplateContext>()
        .UseSqlServer(connectionString)
        .Options;

    var userLoggedInfo = "1"; // simula o código do usuário
    var context = new TemplateContext(options, userLoggedInfo);
    return context;
});

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Corretor, NewCorretorRequest>().ReverseMap();  
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDependencyRepository();
builder.Services.AddDependencyHandler();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
