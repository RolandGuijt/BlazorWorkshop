﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RpcApi.Repositories;
using RpcApi.Services;
using IdentityModel;

namespace RpcApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            services.AddSingleton<IConferenceRepo, ConferenceMemoryRepo>();
            services.AddSingleton<IProposalRepo, ProposalMemoryRepo>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                                // base-address of your identityserver
                                options.Authority = "https://localhost:5001";

                                // if you are using API resources, you can specify the name here
                                options.Audience = "confArchApi";
                });
            services.AddAuthorization(o => o.AddPolicy("Basic", p => p.RequireClaim(JwtClaimTypes.Scope, "confArchApi.basicAccess")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Communication with gRPC endpoints must be made through a gRPC client.
                // To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909
                endpoints.MapGrpcService<ConferenceService>();
                endpoints.MapGrpcService<ProposalService>();
            });
        }
    }
}
