using ApplicationCollector.Application.Interfaces;
using ApplicationCollector.Application.UseCases;
using ApplicationCollector.Infrastructure.Core;
using ApplicationCollector.Infrastructure.Core.Implementations;
using ApplicationCollector.Infrastructure.Core.Interfaces;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("AppDb"),
    x => x.MigrationsAssembly("ApplicationCollector.Infrastructure.Core")));


builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
builder.Services.AddScoped<IConfApplicationDraftRepository, ConfApplicationDraftRepository>();

builder.Services.AddScoped<ICreateSpeakerAppUseCase, CreateSpeakerAppUseCase>();
builder.Services.AddScoped<IEditConfApplicationDraftUseCase, EditConfApplicationDraftUseCase>();
builder.Services.AddScoped<IDeleteConfApplicationDraftUseCase, DeleteConfApplicationDraftUseCase>();
builder.Services.AddScoped<IGetConfApplicationDraftUseCase, GetConfApplicationDraftUseCase>();
builder.Services.AddScoped<IGetConfApplicationDraftBySpeakerIdUseCase, GetConfApplicationDraftBySpeakerIdUseCase>();


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
