using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Rhetos.Host.AspNet.RestApi.Metadata;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rhetos.Host.AspNet.RestApi.Swagger
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly ControllerRestInfoRepository controllerRestInfoRepository;

        public ConfigureSwaggerGenOptions(ControllerRestInfoRepository controllerRestInfoRepository)
        {
            this.controllerRestInfoRepository = controllerRestInfoRepository;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var groupNames = controllerRestInfoRepository.ControllerConceptInfo.Values
                .Select(a => a.ApiExplorerGroupName)
                .Distinct();

            foreach (var groupName in groupNames)
                options.SwaggerDoc(groupName, new OpenApiInfo { Title = "Rhetos.RestApi", Version = "v1" });
        }
    }
}
