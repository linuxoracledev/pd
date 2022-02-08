using Microsoft.EntityFrameworkCore;
using PaymentAPI.DbConTexts;

var builder = WebApplication.CreateBuilder(args);
//1 For Cors
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(
        builder.Configuration.GetConnectionString("connect-to-oracle")
        );
});

//2 Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//3 CORS
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
