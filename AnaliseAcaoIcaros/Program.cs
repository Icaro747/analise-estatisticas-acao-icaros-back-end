using AnaliseAcaoIcaros.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Connection = builder.Configuration.GetConnectionString("AnaliseConnection");
builder.Services.AddDbContext<AnaliseAcaoContext>(opts => opts.UseSqlServer(Connection));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

app.UseCors(option => { option.AllowAnyOrigin(); option.AllowAnyHeader(); option.AllowAnyMethod(); });

app.UseAuthorization();

app.MapControllers();

app.Run();
