using TildeDeclensions.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();

// Register rules
RuleRegistrationExtensions.AddRules(services);

//Register declenion handlers
DeclensionRegistrationExtensions.AddHandlers(services);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
