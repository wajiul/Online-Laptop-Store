using LaptopStoreAPI.Mapping;
using LaptopStoreAPI.Middlewares;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LaptopStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<LaptopStoreRepository, LaptopStoreRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDistributedMemoryCache(); // In-memory distributed cache for demonstration purposes

// Configure session management
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MyShoppingCartSession";
    options.IdleTimeout = TimeSpan.FromDays(1); // Set session expiration to 1 day
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        b =>
        {
            b.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
