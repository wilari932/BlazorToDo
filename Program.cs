using BlazorAppz.Data;
using BlazorAppz.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorAppz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddSingleton<ListHandler>();

            builder.Services.AddSingleton<HttpClientWrapperService>();

            builder.Services.AddSingleton<IListHandler, ListHandler>();
            builder.Services.AddSingleton<UserHandler>();
            builder.Services.AddScoped<UserHandler>();

            builder.Services.AddScoped<IUserHandler, UserHandler>();


            builder.Services.AddHttpClient<HttpClientWrapperService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7178");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}