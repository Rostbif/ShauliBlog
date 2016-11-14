using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShauliBlogMvc.Startup))]
namespace ShauliBlogMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
