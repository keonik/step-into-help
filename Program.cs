using Microsoft.EntityFrameworkCore;
using StepIntoHelp.Data;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.WebHost.UseStaticWebAssets();
builder.WebHost.UseUrls("http://0.0.0.0:5000");
#endif

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
