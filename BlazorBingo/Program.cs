using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBingo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddFluxor(opt =>
            {
#if !DEBUG
         opt.ScanAssemblies(typeof(Program).Assembly);
#else
                opt.ScanAssemblies(typeof(Program).Assembly)
                    .UseReduxDevTools();
#endif
            });

            await builder.Build().RunAsync();
        }
    }
}