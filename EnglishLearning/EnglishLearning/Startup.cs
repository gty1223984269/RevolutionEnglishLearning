using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearningDomain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EnglishLearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            AddDatabase(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        protected virtual void AddDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("eldatabase");

            services.AddDbContext<EnglishLearningDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString, builder =>
                    {
                        builder.EnableRetryOnFailure(5);
                    });

                    // Replace default materializer source to custom, to convert DateTimes
                    options.ReplaceService<IEntityMaterializerSource, DateTimeKindEntityMaterializerSource>();
                });
        }

       
    }
}
