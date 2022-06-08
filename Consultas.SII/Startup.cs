using Consultas.SII.Contracts;
using Consultas.SII.Helpers;
using Consultas.SII.Repositories;
using Consultas.SII.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Consultas.SII
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var (secrets, settings) = GetGlobalConfiguration(services);

            services.AddGesisaAppsCommonUtilities();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });


            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter());
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddAutoMapper(typeof(ApplicationModelsMappingProfile).Assembly);

            services.AddScoped<IDbConnection, SqlConnection>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ISiiRepository, SiiRepository>();
            services.AddScoped<IAgencyCommunicationUrlRepository, AgencyCommunicationUrlRepository>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped<BatchConstants>();
            services.AddScoped<GenericConstants>();
            services.AddScoped<IFileService, FileService>();
            //services.AddScoped<IMailSender1, MailSender1>();
            services.AddScoped<IAgencySoapEndPointResolver, AgencySoapEndPointResolver>();
            services.AddScoped<IAgenciaTributariaService, AgenciaTributariaService>();

            var serviceProvider = services.BuildServiceProvider();
            GlobalConfiguration.BatchConstants = serviceProvider.GetService<BatchConstants>();
            GlobalConfiguration.GenericConstants = serviceProvider.GetService<GenericConstants>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //var builder = new ContainerBuilder();

            ////builder.Register(context => MapperBootstrapper.RegisterMapping()).As<IMapper>();
            //builder.Register(context => Configuration).As<IConfiguration>();
            //builder.RegisterType<SqlConnection>().As<IDbConnection>();
            //builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();

            //builder.RegisterType<XmlHelper>().As<IXmlHelper>();
            //builder.RegisterType<MailSender>().As<IMailSender>();
            //builder.RegisterType<LoggerManager>().As<ILoggerManager>();
            //builder.RegisterType<AuthenticationRepository>().As<IAuthenticationRepository>();
            //builder.RegisterType<PuenteSiiAuthenticationRepository>().As<IPuenteSiiAuthenticationRepository>();
            //builder.RegisterType<GesisaApplicationRepository>().As<IGesisaApplicationRepository>();
            //builder.RegisterType<AgencyCommunicationUrlRepository>().As<IAgencyCommunicationUrlRepository>();
            //builder.RegisterType<SiiRepository>().As<ISiiRepository>();
            //builder.RegisterType<BatchOperationsManager>().As<IBatchOperationsManager>();
            //builder.RegisterType<OperationsManager>().As<IOperationsManager>();
            //builder.RegisterType<XmlProcessManager>().As<IXmlProcessManager>();
            //builder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>();
            //builder.RegisterType<BridgeXmlManager>().As<IBridgeXmlManager>();
            //builder.RegisterType<BridgeExecuterManager>().As<IBridgeExecuterManager>();
            //builder.RegisterType<ConsultationsManager>().As<IConsultationsManager>();
            //builder.RegisterType<RegistroInformacionManager>().As<IRegistroInformacionManager>();
            //builder.RegisterType<XmlBatchProcessor>().As<IXmlBatchProcessor>();
            //builder.RegisterType<BatchConstants>();
            //builder.RegisterType<GenericConstants>();

            //builder.RegisterType<FileService>().As<IFileService>();
            //builder.RegisterType<TimeLimitManager>().As<ITimeLimitManager>();
            //builder.RegisterType<PuenteConnectorManager>().As<IPuenteConnectorManager>();
            //builder.RegisterType<AgencySoapEndPointResolver>().As<IAgencySoapEndPointResolver>();

            //builder.RegisterType<AccountHandler>().As<IAccountHandler>();
            //builder.RegisterType<FileQueueHandler>().As<IFileQueueHandler>();
            //builder.RegisterType<FileQueueManager>().As<IFileQueueManager>();
            //builder.RegisterType<OperationsHandler>().As<IOperationsHandler>();
            //builder.RegisterType<ConsultationsHandler>().As<IConsultationsHandler>();
            //builder.RegisterType<RegistroInformacionHandler>().As<IRegistroInformacionHandler>();
            //builder.RegisterType<AgenciaTributariaService>().As<IAgenciaTributariaService>();

            //builder.Populate(services);

            //var container = builder.Build();

            //GlobalConfiguration.BatchConstants = container.Resolve<BatchConstants>();
            //GlobalConfiguration.GenericConstants = container.Resolve<GenericConstants>();

            //return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var defaultDateCulture = "es-ES";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.CurrencyDecimalSeparator = ",";

            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,
                }
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// get and register the Secrets and global configurations instants
        /// </summary>
        /// <param name="services">the services collection</param>
        /// <returns>the <see cref="ApplicationSecrets"/> and <see cref="ApplicationSettings"/> instants</returns>
        private (ApplicationSecrets secrets, ApplicationSettings settings) GetGlobalConfiguration(IServiceCollection services)
        {
            // set the globalConfig
            services.Configure<ApplicationSecrets>(Configuration.GetSection("ApplicationSecrets"));
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // register accessors
            services.AddSingleton<IApplicationSettingsAccessor, ApplicationSettingsAccessor>();
            services.AddSingleton<IApplicationSecretsAccessor, ApplicationSecretsAccessor>();

            var secrets = new ApplicationSecrets();
            var globalConfig = new ApplicationSettings();

            Configuration.Bind("ApplicationSettings", globalConfig);
            Configuration.Bind("ApplicationSecrets", secrets);

            return (secrets, globalConfig);
        }
    }
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var date = value.ToString("dd/MM/yyyy HH:mm:ss");
            writer.WriteStringValue(date);
        }
    }

    public class TimeSpanToStringConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
