using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etg.Data.Entry;
using Grpc.Core;

namespace Etg.Service
{
    class Program
    {
        static readonly string[] EntriesToQuery = { "518920160896053556", "516620160666505983",
                "518920160896053557", "51520160536088309" };
        public class EtgServiceClient
        {
            readonly EntryDataService.EntryDataServiceClient client;
            public EtgServiceClient(EntryDataService.EntryDataServiceClient client)
            {
                this.client = client;
            }

            public async Task GetEntryStatus()
            {
                try
                {
                    using (var call = client.GetEntryStatus())
                    {

                        var responseReaderTask = Task.Run(async () =>
                        {
                            while (await call.ResponseStream.MoveNext())
                            {
                                var entryStatus = call.ResponseStream.Current;
                                Console.WriteLine("EntryId: {0}\tStatus: {1}\tDeclareDate: {2}", entryStatus.EntryId, entryStatus.StatusText, entryStatus.DeclareDate.ToDateTime());
                            }
                        });

                        foreach (var entryId in EntriesToQuery)
                        {
                            await call.RequestStream.WriteAsync(new GetEntryStatusRequest() { EntryId = entryId });
                        }
                        await call.RequestStream.CompleteAsync();
                        await responseReaderTask;
                    }
                }
                catch(RpcException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                
            }
        }
        static void Main(string[] args)
        {
            Channel channel = new Channel("localhost:50052", ChannelCredentials.Insecure);
            var client = new EtgServiceClient(new EntryDataService.EntryDataServiceClient(channel));
            client.GetEntryStatus().Wait();
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
