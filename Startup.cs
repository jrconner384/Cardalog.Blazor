using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlazorStrap;

namespace Cardalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddBootstrapCSS();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
