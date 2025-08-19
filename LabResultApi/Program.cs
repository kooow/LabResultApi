using LabResultApi.Services;
using LabResultApi.Services.DbContext;
using LabResultApi.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LabResultDbContext>(opt => opt.UseInMemoryDatabase("LabResultTest"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILabResultRepository, LabResultRepository>();

builder.Services.AddSingleton<ILoaderService, FileLoaderService>();
builder.Services.AddTransient<TestDataSeeder>();

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

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<TestDataSeeder>();
    seeder.Seed();
}

app.Run();