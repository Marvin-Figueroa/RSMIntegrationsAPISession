using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using RSMEnterpriseIntegrationsAPI.Application.Services;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Infrastructure;
using RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories;
using RSMEnterpriseIntegrationsAPI.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key")!))
        };
    });

builder.Services.AddValidatorsFromAssemblyContaining<CreateDepartmentDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateDepartmentDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductCategoryDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductCategoryDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateSalesOrderHeaderDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateSalesOrderHeaderDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();

builder.Services.AddAutoMapper(typeof(DepartmentMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductCategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(SalesOrderHeaderMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));
});

builder.Services.AddDbContext<AdvWorksAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksAuthDbContext).Assembly.FullName));
});


builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<ISalesOrderHeaderRepository, SalesOrderHeaderRepository>();
builder.Services.AddTransient<ISalesOrderHeaderService, SalesOrderHeaderService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
