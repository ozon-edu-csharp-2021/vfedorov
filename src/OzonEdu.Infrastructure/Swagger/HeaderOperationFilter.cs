namespace OzonEdu.Infrastructure.Swagger
{
    using System.Collections.Generic;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class HeaderOperationFilter : IOperationFilter
    {
        private const string SomeHeaderParmName = "some-header-parm";

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                In = ParameterLocation.Header,
                Name = SomeHeaderParmName,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
            });
        }
    }
}
