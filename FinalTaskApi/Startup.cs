using learn.core.domain;
using learn.core.Repoisitory;
using learn.core.Service;
using learn.infra.domain;
using learn.infra.Repoisitory;
using learn.infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace FinalTaskApi
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
            services.AddScoped<IDBContext, DbContext>();
        
            services.AddScoped<Iuser, user_taskrepo>();
      
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<Imassage, massage_taskrepo> ();
         
            services.AddScoped<IpostlikeService, postlikeService>();
            services.AddScoped<Ilikepost, postlike_taskrepo> ();

            services.AddScoped<IpostService, postService>();
            services.AddScoped<Ipost, post_taskrepo>();

            services.AddScoped<IcountryService, countryService>();
            services.AddScoped<Icountry, country_taskrepo>();

            services.AddScoped<IcardService, cardService>();
            services.AddScoped<Icard, cardrepo>();
         
            services.AddScoped<Igroupblock_Service, blockuser_Service> ();
         
            services.AddScoped<Igroupblock, groupblock> ();

            services.AddScoped<IMassageService, massageService> ();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IAuthenticationservice, Authenticationservice>();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };


            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
