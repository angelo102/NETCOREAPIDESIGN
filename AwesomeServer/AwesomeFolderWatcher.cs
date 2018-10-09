using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeServer
{
    internal class AwesomeFolderWatcher<TContext>
    {
        private IHttpApplication<TContext> application;
        private IFeatureCollection features;
        private readonly FileSystemWatcher watcher;

        public AwesomeFolderWatcher(IHttpApplication<TContext> application, IFeatureCollection features)
        {
            var path = features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault();
            this.watcher = new FileSystemWatcher(path);
            this.watcher.EnableRaisingEvents = true;
            this.application = application;
            this.features = features;
        }

        public void Watch()
        {
            watcher.Created += async (sender, e) =>
            {
                var context = (HostingApplication.Context)(object)application.CreateContext(features);
                context.HttpContext = new AwesomeHttpContext(features, e.FullPath);
                await application.ProcessRequestAsync((TContext)(object)context);
                context.HttpContext.Response.OnCompleted(null, null);

            };
            Task.Run(() => watcher.WaitForChanged(WatcherChangeTypes.All));
      
        }

        public void Dispose()
        {
            this.watcher.Dispose();
        }
    }
}