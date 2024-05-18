using FastCell.Helpers.Seeders.BaseAdminSeeder;
using FastCell.Helpers.Seeders.BaseManufacturerSeeder;
using FastCell.Helpers.Seeders.RoleSeeder;
using FastCell_BAL.Services.ManufacturerService;
using FastCell_DAL.Models.Entities.Auth;
using FC_BAL;
using FC_DAL;
using FC_DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime = true,
        ValidIssuer = configuration["AuthSettings:Issuer"],
        ValidAudience = configuration["AuthSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorAccess", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireEmployeeAccess", policy => policy.RequireRole("Admin", "Manager"));
    options.AddPolicy("BasicAccess", policy => policy.RequireRole("Admin", "Manager", "User"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess();
builder.Services.AddBusinessAccess();

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

using(var scope = app.Services.CreateScope())
{
    //Seed roles if no role has been added.
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
    var roleSeeder = new RoleSeeder(roleManager);

    await roleSeeder.SeedRolesAsync();

    //Seed most popular phone manufacturers on first startup.
    var manufacturerService = scope.ServiceProvider.GetRequiredService<IManufacturerService>();

    var manufacturerSeeder = new BaseManufacturerSeeder(manufacturerService);

    await manufacturerSeeder.SeedBaseManufacturers();

    //Instantiate default superuser on start, user chooses name and password.
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    var adminSeeder = new BaseAdminSeeder(userManager);

    await adminSeeder.SeedBaseAdminAsync();
}

app.Run();
