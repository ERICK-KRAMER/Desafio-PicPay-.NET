using Microsoft.EntityFrameworkCore;
using PicPay.Data;
using PicPay.Data.Repository.Transfer;
using PicPay.Data.Repository.Wallet;
using PicPay.Services.Authorization;
using PicPay.Services.Notification;
using PicPay.Services.Transfer;
using PicPay.Services.Wallet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database config
var connectionString =  builder.Configuration.GetConnectionString("PicPayDb");
builder.Services.AddDbContext<PicPayDbContext>(options => options.UseNpgsql(connectionString));

//dependency injection
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddHttpClient<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
