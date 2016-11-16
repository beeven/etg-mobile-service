using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Etg.Data.Entry;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Etg.Service
{
    public class EtgService : ServiceBase
    {
        private Grpc.Core.Server server;
        private IEnumerable<int> securePorts;
        private IEnumerable<int> insecurePorts;
        private SslServerCredentials serverCredentials;
        private readonly ILogger<EtgService> logger;
        private readonly EntryDataServiceImpl entryDataServiceImpl;

        public EtgService(EntryDataServiceImpl entryDataServiceImpl, ILoggerFactory loggerFactory, IOptions<EtgServiceOptions> optionsAccessor)
        {

            this.securePorts = optionsAccessor.Value.SecureChannelPorts;
            this.insecurePorts = optionsAccessor.Value.InsecureChannelPorts;
            serverCredentials = new SslServerCredentials(
                optionsAccessor.Value.ServerKeyCertPairs.Select(x => new KeyCertificatePair(x.Cert, x.Key)),
                optionsAccessor.Value.CACert,
                true);
            
            this.entryDataServiceImpl = entryDataServiceImpl;
            this.logger = loggerFactory.CreateLogger<EtgService>();
        }

        public void StartServer()
        {
            logger.LogDebug("EtgService server is starting.");
            this.server = new Server()
            {
                Services = { EntryDataService.BindService(entryDataServiceImpl) },
            };
            foreach (int port in this.securePorts)
            {
                this.server.Ports.Add(new ServerPort("0.0.0.0", port, serverCredentials));
            }
            foreach (int port in this.insecurePorts)
            {
                this.server.Ports.Add(new ServerPort("0.0.0.0", port, ServerCredentials.Insecure));
            }
            server.Start();
            logger.LogDebug("EtgService server listening on secure port {0}, insecure port {1}", String.Join(",", securePorts), String.Join(",", insecurePorts));
        }

        public void StopServer()
        {
            logger.LogDebug("Shutting down EtgService.");
            this.server.ShutdownAsync().Wait();
        }

        protected override void OnStart(string[] args)
        {
            this.StartServer();
            base.OnStart(args);
            logger.LogInformation("Service started.");
        }

        protected override void OnStop()
        {
            this.StopServer();
            base.OnStop();
            logger.LogInformation("Service stopped.");
        }

    }

    public class EtgServiceOptions
    {
        public List<int> SecureChannelPorts { get; set; }
        public List<int> InsecureChannelPorts { get; set; }
        public string CACert { get; set; }
        public List<KeyCertPair> ServerKeyCertPairs { get; set;}
        public class KeyCertPair
        {
            public string Key { get; set; }
            public string Cert { get; set; }
        }
    }
}
