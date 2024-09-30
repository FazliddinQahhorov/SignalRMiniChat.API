using Microsoft.EntityFrameworkCore;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Application.Mapper;
using SignalRMiniChat.Application.Services;
using SignalRMiniCHat.Data.AppDbContexts;
using SignalRMiniCHat.Data.Interfaces;
using SignalRMiniCHat.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql(
           builder.Configuration.GetConnectionString("DefoultConnection")));

builder.Services.AddSignalR();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
