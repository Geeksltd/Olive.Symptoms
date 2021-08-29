namespace Olive
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Olive.Symptoms;

    public static class SymptomsExtensions
    {
        public static IApplicationBuilder UseSymptoms<T>(this IApplicationBuilder @this)
            where T : Source, new()
        {
            @this.Map("/api/discover-symptoms",
                app => app.Run(async context =>
                {
                    if (context.Request.Param("token") != Config.GetOrThrow("Olive.Symptoms:Token"))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                    else
                        await SymptomsMiddleware.Discover<T>(context);
                }));

            return @this;
        }
    }
}
