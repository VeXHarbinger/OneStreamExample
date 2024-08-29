using ExampleSampleBlazorApp._3rdParty;
using ExampleSampleBlazorApp.Services;
using ExampleSampleBlazorApp.Services._3rdParty;
using ExampleSampleBlazorApp.Services.Core;
using Microsoft.OpenApi.Models;
using Refit;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExampleSampleBlazorApp
{
    /// <summary>
    /// Typically I wouldn't put so much in this one class
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            //  Create and Configure our HTTP client we'll use to call our API from the Razor page
            builder.Services.AddScoped<IHttpClientServiceImplementation, HttpClientServiceFactory>();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            // This should be done via the appsettings.json file
            var myBaseAddress = new Uri("https://localhost:7262/api/");

            // Register and config the HttpClientFactory
            builder.Services.AddHttpClient("MyHttpClient", sp => sp.BaseAddress = myBaseAddress);
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("MyHttpClient"));
            
            // Register the services for DI
            builder.Services.AddSingleton<IUserDashboardHttpClient, UserDashboardHttpClient>();

            // Service: Useless Facts
            builder.Services.AddRefitClient<IUselessFactsService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://uselessfacts.jsph.pl"));
            // Service: Cat Facts
            builder.Services.AddRefitClient<IMeowFactsService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://meowfacts.herokuapp.com"));

            // Globally configure how controllers handle JSON
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Configure Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Example API Documentation",
                    Description = "The ASP.NET Core Web API example"
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Add routing so our APIs are accessible and pathed
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                // Only apply and allow Swagger in a Dev environment
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }
    }
}