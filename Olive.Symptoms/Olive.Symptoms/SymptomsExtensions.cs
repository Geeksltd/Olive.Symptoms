namespace Olive
{
    using Microsoft.AspNetCore.Builder;
    using Olive.Symptoms;

    public static class SymptomsExtensions
    {
        public static IApplicationBuilder UseSymptoms<T>(this IApplicationBuilder @this)
            where T : Source, new()
        {
            @this.Map("/api/global-search",
                app => app.Run(context => SymptomsMiddleware.Discover<T>(context)));

            return @this;
        }
    }
}
