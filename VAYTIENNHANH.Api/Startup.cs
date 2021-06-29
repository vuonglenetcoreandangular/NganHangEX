using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Principal;
using System.Text;
using VAYTIENNHANH.Data.EF;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Service.Services.BaiViets;
using VAYTIENNHANH.Service.Services.DanhMucBaiViets;
using VAYTIENNHANH.Service.Services.HinhAnhs;
using VAYTIENNHANH.Service.Services.Users;

namespace VAYTIENNHANH.Api
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
            services.AddDbContext<VayTienNhanhDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("VayTienNhanhDb")));

            //Declare DI
            Func<IServiceProvider, IPrincipal> getPrincipal =
    (sp) => sp.GetService<IHttpContextAccessor>().HttpContext.User;
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(Func<IPrincipal>),getPrincipal);
            services.AddTransient<IDanhMucBaiVietService, DanhMucBaiVietService>();
            services.AddTransient<IBaiVietService, BaiVietService>();
            services.AddTransient<ICauHinhHienThiBaiVietService, CauHinhHienThiBaiVietService>();
            services.AddTransient<IHinhAnhService, HinhAnhService>();
            services.AddTransient<IUserService, UserService>();
       
            services.AddControllersWithViews();
            services.AddCors(c => c.AddPolicy("TCAPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:5100",
                        ValidAudience = "https://localhost:5100",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("TCAPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                  name: "Portal",
                  areaName: "Portal",
                  pattern: "Portal/{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
