using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjectCRUD.AutoMapper;
using ProjectCRUD.Models;
using ProjectCRUD.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD
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

            services.AddCors((options) =>
            {
                options.AddPolicy("angularApplication", (builder) =>
                 {
                     builder.WithOrigins("http://localhost:4200")
                     .AllowAnyHeader()
                     .WithMethods("GET", "POST", "PUT", "DELETE")
                     .WithExposedHeaders("+");
                 });
            });
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddControllers();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            //  services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IStudentInterface, StudentRepository>();
            services.AddTransient<IImageInterface, ImageRepository>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

           


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectCRUD", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectCRUD v1"));
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "ImagesAndFiles")),
                RequestPath = "/ImagesAndFiles"
            });
            app.UseRouting();
            app.UseCors("angularApplication");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
