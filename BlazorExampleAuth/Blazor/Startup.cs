using System;
using System.Threading.Tasks;
using Blazor.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using RpcApi;
using Blazor.Auth;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Blazor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<IConferenceService, ConferenceApiService>();
            services.AddScoped<IProposalService, ProposalApiService>();
            services.AddScoped<TokenProvider>();

            services.AddGrpcClient<Conferences.ConferencesClient>(
                o => o.Address = new Uri("https://localhost:50051"));

            services.AddGrpcClient<Proposals.ProposalsClient>(
                o => o.Address = new Uri("https://localhost:50051"));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, b =>
            {
                b.SignInScheme = "Cookies";
                b.Authority = "https://localhost:5001";
                b.GetClaimsFromUserInfoEndpoint = true;
                b.ClientId = "confarchweb";
                b.ClientSecret = "secret";

                b.ResponseType = "code";
                b.UsePkce = true;
                b.Scope.Add("confArchApi.basicAccess");
                b.SaveTokens = true;
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
