using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ToDo.Configurations;
using ToDo.Datas;
using ToDo.Repository;
using ToDo.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

var x = builder.Configuration.GetConnectionString("TodoDbConnectionString");

// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TodoDbConnectionString");
    var serverVersion = ServerVersion.AutoDetect(connectionString);

    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TodoDbContext>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        p => p.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoTypeRepository, TodoTypeRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

