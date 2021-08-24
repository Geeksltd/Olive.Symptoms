namespace Olive.Symptoms
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    internal static class SymptomsMiddleware
    {
        internal static async Task Discover<T>(HttpContext context) where T : Source, new()
        {
            var searchInstance = new T { };
            await searchInstance.Discover();
            var response = JsonConvert.SerializeObject(searchInstance.Results);
            await context.Response.WriteAsync(response);
        }
    }
}
