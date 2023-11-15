using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using ProjectN.Parameter;
using ProjectN.Repository.Implement;
using ProjectN.Repository.Interface;
using ProjectN.Service.Implement;
using ProjectN.Service.Interface;
using ProjectN.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var _connectionString = builder.Configuration.GetValue<string>("ConnectionString");

// Add services to the container.
// Service
builder.Services.AddScoped<ICardService, CardService>();
// Repsitory
// ���U ICardRepository ����@�� CardRepository
builder.Services.AddScoped<ICardRepository, CardRepository>(m => {
    var connectString = _connectionString;
    return new CardRepository(connectString);
});

// Others
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // API �A��²��
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "���� API",
        Description = "�����s�V�O���d�� API",
        TermsOfService = new Uri("https://igouist.github.io/"),
        Contact = new OpenApiContact
        {
            Name = "Igouist",
            Email = string.Empty,
            Url = new Uri("https://igouist.github.io/about/"),
        },
        License = new OpenApiLicense
        {
            Name = "TEST",
            Url = new Uri("https://igouist.github.io/about/"),
        }
    });

    // Ū�� XML �ɮײ��� API ����
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CardParameterValidator>();
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
