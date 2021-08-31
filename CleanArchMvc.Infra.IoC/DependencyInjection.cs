using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mapppings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CleanArchMvc.Domain.Account;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicatinDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicatinDbContext).Assembly.FullName)));

            service.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicatinDbContext>()
                .AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(opt => opt.AccessDeniedPath = "/Account/Login");

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProdutoRepository, ProductRepository>();

            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IProductService, ProductService>();

            service.AddScoped<IAuthenticate, AuthenticateService>();
            service.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            service.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            service.AddMediatR(myHandlers);

            return service;
        }
    }
}