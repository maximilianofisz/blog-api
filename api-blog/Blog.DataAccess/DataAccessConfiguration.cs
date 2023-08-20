using api_blog;
using Blog.DataAccess.Repositories;
using Blog.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["DataAccess:ConnectionString"];

            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<BlogRepository>();

            services.AddScoped<CommentsRepository>();

            services.AddScoped<UsersRepository>();

            return services;
        }
    }
}
