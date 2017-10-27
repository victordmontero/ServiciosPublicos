using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiciosPublicosConsulta.Startup))]
namespace ServiciosPublicosConsulta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
