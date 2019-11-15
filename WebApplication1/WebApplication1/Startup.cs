using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using RG3.PF.Caching.Redis.Extensions;
using WebApplication1.Models;
using WebApplication1.Extensions;
using WebApplication1.Middlewares;
using WebApplication1.Filters;
using Newtonsoft.Json.Serialization;

namespace WebApplication1
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
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseInMemoryDatabase("InMemoryDb"));

            //services.AddTransient<FactoryActivatedMiddleware>();

            //var sectionExists = _config.GetSection("Logging:LogLevel").Exists();

            var logLevelModel = new LogLevelModel();
            Configuration.GetSection("Logging:LogLevel").Bind(logLevelModel);


            //services.AddScoped<ClientIpCheckFilter>();

            ////添加自定义缓存
            //services.AddMemoryCustomizeCache(Configuration);

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add
            //        (new ClientIpCheckPageFilter
            //            (_loggerFactory, Configuration));
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //启用跨域
            services.AddCors();


            services.AddControllers().AddJsonOptions(options =>
            {
                //中文乱码
                options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                //忽略空值
                options.JsonSerializerOptions.IgnoreNullValues = true;
                //忽略自读属性
                //options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                //忽略大小写
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //大小写处理
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                ;
            });

            services.AddMvc().AddNewtonsoftJson(options =>
           options.SerializerSettings.ContractResolver =
              new CamelCasePropertyNamesContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseExceptionHandler("/error");

            //全局异常
            //app.UseGlobalException();
            //白名单控制
            // app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);


            //app.UseRequestCulture();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(
            //        $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            //});
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //   app.UseFactoryActivatedMiddleware();

            //     app.UseConventionalMiddleware();



            //app.UseHttpsRedirection();

            //允许跨域
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
