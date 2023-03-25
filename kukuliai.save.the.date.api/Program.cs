using kukuliai.save.the.date.api.Persistence.Clients;
using kukuliai.save.the.date.api.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KukuliaiDB");
if (connectionString is null)
{
    throw new ApplicationException("Connection string not found");
}

builder.Services.AddSingleton(connectionString);
builder.Services.AddTransient<ISqlClient, SqlClient>();
builder.Services.AddSingleton<IRespondPleaseRepository, RespondPleaseRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "RSVP",
        Version = "v1"
    });
});

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