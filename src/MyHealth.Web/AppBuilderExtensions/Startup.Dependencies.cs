using Microsoft.Extensions.DependencyInjection;
using SmartClinic.API.Validators;
using SmartClinic.Data.Infraestructure;
using SmartClinic.Data.Repositories;

namespace SmartClinic.Web.AppBuilderExtensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationUsersRepository>();
            services.AddScoped<ApplicationUserValidators>();
            services.AddScoped<PatientsRepository>();
            services.AddScoped<ClinicAppointmentsRepository>();
            services.AddScoped<ReportsRepository>();
            services.AddScoped<HomeAppointmentRepository>();
            services.AddScoped<MedicinesRepository>();
            services.AddScoped<TipsRepository>();
            services.AddScoped<DoctorsRepository>();
            services.AddScoped<TenantsRepository>();
            services.AddScoped<SmartClinicDataInitializer>();

            return services;
        }
    }
}