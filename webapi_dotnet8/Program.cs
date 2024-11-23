
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using CommonLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using System.Reflection;
using webapi_dotnet8.Controllers.v1;
using webapi_dotnet8.Data;

namespace webapi_dotnet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // ���U IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();


            // Add DbContext with PostgreSQL provider
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // �t�m API ��������
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
                options.GroupNameFormat = "'v'VVV";
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "API v1", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo() { Title = "API v2", Version = "v2" });
            });



            builder.Services.AddSingleton<Libary>();

            // �]�m GraphQL �A��
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();



            var app = builder.Build();

            // �]�m GraphQL ������
            app.MapGraphQL();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // �t�m Swagger �����h
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToLowerInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
