using BookingSystem.BookingSystem.Application.Interfaces;
using BookingSystem.BookingSystem.Application.Services;
using .BookingSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "BookingSystem_";
});

builder.Services.AddHangfire(config => config.UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add application services.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking System API V1");
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard();
app.MapControllers();
app.Run();
