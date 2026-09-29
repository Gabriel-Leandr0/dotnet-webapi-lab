using WebApiLab.Api.Services;
using WebApiLab.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

//CONFIGURATIONS
builder.AddSerilogLogging();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

//CONTROLLERS
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//SERVICES
builder.Services.AddScoped<IPersonServices, PersonService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
