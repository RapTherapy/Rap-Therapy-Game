using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RapGame;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Threading.Tasks;

namespace ElectronRazorPage
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
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.Configure<AdminData>(Configuration.GetSection("AdminData"));
            services.Configure<PathToGameFile>(Configuration.GetSection("PathToGameFile"));
            services.Configure<PathToMediaFileForFrame>(Configuration.GetSection("PathToMediaFileForFrame"));

            services.AddTransient<IStudentDataReader, StudentDataReader>();
            services.AddSession();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Frame1", "");
            });

            services.AddTransient<MediaHelper>();
            services.AddTransient<CheckLicense>();
            services.AddTransient<GameDataReader>();
            services.AddTransient<MediaForFramseDataReader>();
            services.AddTransient(provider =>
            
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                return JsonSerializer.Create(settings);
            });

            AppSettings appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            AppSettings settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Show = true,
                Fullscreen = true,
                AutoHideMenuBar = true,
                TitleBarStyle = TitleBarStyle.hidden,


                WebPreferences = new WebPreferences
                {
                    AllowRunningInsecureContent = true,
                    WebSecurity = false,
                    NodeIntegration = true,
                    DevTools = true,
                },
            })); ;
        }
    }
}
