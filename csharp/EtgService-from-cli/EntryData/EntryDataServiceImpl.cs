using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net.Http;

using Grpc.Core;
using Newtonsoft.Json.Linq;
using Google.Protobuf.WellKnownTypes;


namespace Etg.Data.Entry
{
    public class EntryDataServiceImpl : EntryDataService.EntryDataServiceBase
    {
        private HttpClient httpClient;

        public EntryDataServiceImpl()
        {
            httpClient = new HttpClient() { BaseAddress = new System.Uri("http://10.53.34.180:3001/") };
        }

        public class QueryReply
        {
            public string StatusText;
            public Timestamp DeclareDate;
        }
        public override async Task GetEntryStatus(IAsyncStreamReader<GetEntryStatusRequest> requestStream, IServerStreamWriter<GetEntryStatusResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var request = requestStream.Current;
                var status = await QueryEntryStatus(request.EntryId);

                GetEntryStatusResponse ret = new GetEntryStatusResponse(){EntryId = request.EntryId};
                if(status != null) {
                    ret.StatusText = status.StatusText;
                    ret.DeclareDate = status.DeclareDate;
                } 
                await responseStream.WriteAsync(ret);
            }
        }


        private async Task<QueryReply> QueryEntryStatus(string entryId)
        {
            try
            {
                var res = await httpClient.GetStringAsync($"entry_pop/api/entry/{entryId}");
                var resObj = JObject.Parse(res);
                if (resObj.Value<int>("code") == 200)
                {
                    if (resObj["data"][entryId] != null)
                    {
                        return new QueryReply()
                        {
                            StatusText = resObj["data"][entryId].Value<string>("status"),
                            DeclareDate = Timestamp.FromDateTime(resObj["data"][entryId].Value<DateTime>("declare_date"))
                        };
                    }
                }
            }
            catch (AggregateException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}