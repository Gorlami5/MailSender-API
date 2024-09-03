using Microsoft.AspNetCore.Identity.UI.Services;
using MailSenderApi.Persistance;
using FluentValidation.AspNetCore;
using MailSenderApi.Application.Validators.Company;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CompanyValidators>());
//.ConfigureBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true) If you want to use this function you can suppress asp.net core validation filter.
//but in this case you have to control manuelly on your controller section or define custom validation filter.
builder.Services.AddRegistration();
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
