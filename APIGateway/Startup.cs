using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Steiner.Gateway
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath)
                .AddOcelot()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

            // Tag used in the configuration.json file to identify api calls requiring security.
            string authenticationProviderKey = "olympus";

            // We will pull from appsettings.json the location of the Identity Server so we 
            // know where to validate our incoming tokens.
            string is4Locaiton = Configuration.GetSection("SecuritySetting")["IS4Location"];

            // Setup our Identity server setup.  The authentication key above will be used to 
            // map it to the given identity server.  
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(authenticationProviderKey, o =>
                {
                    o.Authority = is4Locaiton; 
                    o.ApiName = "api1";
                    o.RequireHttpsMetadata = false;  
                    o.SupportedTokens = SupportedTokens.Both;
                    o.ApiSecret = "secret";
                })

                .AddOpenIdConnect("oidc", "OpenId Connect", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                    options.Authority = is4Locaiton; 
                    options.ClientId = "implicit";
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            IdentityModelEventSource.ShowPII = true;

            // Pull the Cors (inbound request sites - aka: application web sites) sites to 
            // white list them.
            var corsData = Configuration.GetSection("CoresConfig").AsEnumerable();
            List<string> corsNodes = new List<string>();
            foreach (var entity in corsData)
            {
                if (null != entity.Value)
                    corsNodes.Add(entity.Value);
            }

            // Now define the Cors
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(corsNodes.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");
            app.UseAuthentication();

            app.UseOcelot().Wait();
        }
    }
}
