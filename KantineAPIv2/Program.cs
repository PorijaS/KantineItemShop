using IdentityServer4.AccessTokenValidation;
using KantineAPIv2.Context;
using KantineAPIv2.Identity;
using KantineAPIv2.Entities.DataManager;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "KantineAPI", Version = "v1" });
});

var connectionString = builder.Configuration["ConnectionStrings:KantineDB"];

builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IUserRepository, UserManager>();
builder.Services.AddScoped<IGroupRepository, GroupManager>();
builder.Services.AddScoped<IFoodCategoryRepository, FoodCategoryManager>();
builder.Services.AddScoped<IOrderRepository, OrderManager>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineManager>();
builder.Services.AddScoped<IFoodRepository, FoodManager>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<ILoginRepository, LoginManager>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.LiterateConsole()
    .CreateLogger();

IdentityServerConfig identityConfig = new(builder.Configuration);

builder.Services.AddIdentityServer(options =>
{
    options.IssuerUri = "https://sdeKantine.com";
}).AddOperationalStore(options =>
{
    options.ConfigureDbContext = builder =>
    {
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b =>
        {
            b.MigrationsAssembly("KantineAPIv2");
        });
    };

    options.EnableTokenCleanup = true;
    options.TokenCleanupInterval = 3600;
}).AddInMemoryClients(identityConfig.GetClient())
.AddInMemoryIdentityResources(identityConfig.GetIdentityResources())
.AddInMemoryApiScopes(identityConfig.GetApiScopes())
.AddInMemoryApiResources(identityConfig.GetApiResources())
.AddDeveloperSigningCredential()
.AddProfileService<ProfileService>()
.AddResourceOwnerValidator<AuthenticationValidator>();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = builder.Configuration["IdentityServer:Authority"];
        options.RequireHttpsMetadata = false;

    });

builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.AllowAnyHeader(); builder.AllowAnyOrigin(); builder.AllowAnyMethod(); }); });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kantine API");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();