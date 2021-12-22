using AspNetCoreHero.ToastNotification;
using FluentValidation.AspNetCore;
using GaziLibrary.Business.Abstract;
using GaziLibrary.Business.Concrete;
using GaziLibrary.DataAccess.Abstract;
using GaziLibrary.DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookManager>();
            services.AddSingleton<IBookDal, EfBookDal>();
            services.AddSingleton<IBorrowedBookService, BorrowedBookManager>();
            services.AddSingleton<IBorrowedBookDal, EfBorrowedBookDal>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IMessageService, MessageManager>();
            services.AddSingleton<IMessageDal, EfMessageDal>();
            services.AddSingleton<IAuthorService, AuthorManager>();
            services.AddSingleton<IAuthorDal, EfAuthorDal>();
            services.AddSingleton<ITypeService, TypeManager>();
            services.AddSingleton<ITypeDal, EfTypeDal>();
            services.AddSingleton<IPositionService, PositionManager>();
            services.AddSingleton<IPositionDal, EfPositionDal>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddNotyf(config =>
            {
                config.DurationInSeconds = 4;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Auth/Login/";
            });

            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{Controller=User}/{Action=Books}/{id?}");
            });
        }
    }
}
