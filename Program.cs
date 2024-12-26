using Microsoft.EntityFrameworkCore;
using PicPay.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database config
var connectionString =  builder.Configuration.GetConnectionString("PicPayDb");
builder.Services.AddDbContext<PicPayDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
