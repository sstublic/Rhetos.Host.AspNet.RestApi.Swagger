using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rhetos.Host.AspNet.RestApi.Metadata;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Rhetos.Host.AspNet.RestApi.Swagger
{
    public static class SwaggerUIOptionsExtensions
    {
        public static void SwaggerRhetosEndpoints(this SwaggerUIOptions swaggerUiOptions, IApplicationBuilder app)
        {
            var controllerRestInfoRepository = app.ApplicationServices.GetRequiredService<ControllerRestInfoRepository>();
            var groupNames = controllerRestInfoRepository.ControllerConceptInfo.Values
                .Select(a => a.ApiExplorerGroupName)
                .Distinct();

            foreach (var groupName in groupNames)
                swaggerUiOptions.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", $"Module {groupName}");
        }
    }
}
