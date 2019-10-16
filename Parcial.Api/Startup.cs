using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Parcial.Domain.helper;
using Parcial.Repository;
using Parcial.Repository.Implementation;
using Parcial.Service;
using Parcial.Service.Implementation;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Parcial.Api
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
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //JWT Config
            var tokenManagement = Configuration.GetSection("tokenManagement");
            services.Configure<TokenAdministrador>(tokenManagement);

            var tokenAdministrador = tokenManagement.Get<TokenAdministrador>();
            var SecretKey = Encoding.ASCII.GetBytes(tokenAdministrador.SecretKey);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            services.AddTransient<IJugadorRepository,JugadorRepository>();
            services.AddTransient<IJugadorService,JugadorService>();
            services.AddTransient<ITorneoRepository,TorneoRepository>();
            services.AddTransient<ITorneoService,TorneoService>();
            services.AddTransient<IInscripcionRepository,InscripcionRepository>();
            services.AddTransient<IInscripcionService,InscripcionService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

               // https://localhost:5001/swagger/index.html
            services.AddSwaggerGen (swagger => {
                var contact = new Contact () { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
                swagger.SwaggerDoc (SwaggerConfiguration.DocNameV1,
                    new Info {
                        Title = SwaggerConfiguration.DocInfoTitle,
                            Version = SwaggerConfiguration.DocInfoVersion,
                            Description = SwaggerConfiguration.DocInfoDescription,
                            Contact = contact
                    }
                );
                var security = new Dictionary<string, IEnumerable<string>>{
                    {"Bearer", new string[] {}},
                };
                swagger.AddSecurityDefinition("Bearer", new ApiKeyScheme{
                    Description = SwaggerConfiguration.SecDefDescription,
                    Name = SwaggerConfiguration.SecDefName,
                    In = SwaggerConfiguration.SecDefIn,
                    Type = SwaggerConfiguration.SecDefType
                });
                swagger.AddSecurityRequirement(security);
            });
            

            services.AddCors (options => {
                options.AddPolicy ("Todos",
                    builder => builder.WithOrigins ("*").WithHeaders ("*").WithMethods ("*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint (SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }else{
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors ("Todos");
            app.UseHttpsRedirection();
            //habilitacion de la autentificación
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
