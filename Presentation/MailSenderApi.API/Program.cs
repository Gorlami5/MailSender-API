using Microsoft.AspNetCore.Identity.UI.Services;
using MailSenderApi.Persistance;
using MailSenderApi.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddRegistration();
builder.Services.AddCoreServiceRegistration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
