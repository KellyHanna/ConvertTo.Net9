using Microsoft.AspNetCore.Mvc;
using WcfSampleService;

namespace WebApiSampleApp
{
    public static class ApiRoutes
    {
        public static void MapAppRoutes(this WebApplication app)
        {
            app.MapGet("/api/GetData", (int value, [FromServices] ISampleService s) =>
            {
                var result = s.GetData(value);
                return result;

            }).WithName("GetData")
              .WithOpenApi(operation => new(operation) { Summary = "GetData - returns some data " });

            app.MapPost("/api/GetDataUsingDataContract", (CompositeType request, [FromServices] ISampleService s) =>
            {
                var result = s.GetDataUsingDataContract(request);
                return result;

            }).WithName("GetDataUsingDataContract")
              .WithOpenApi(operation => new(operation) { Summary = "GetDataUsingDataContract - returns some data " });


        }
    }
}
