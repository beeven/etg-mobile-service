using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net.Http;

using Grpc.Core;
using Newtonsoft.Json.Linq;
using Google.Protobuf.WellKnownTypes;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Etg.Data.Entry
{
    public class EntryDataServiceImpl : EntryDataService.EntryDataServiceBase
    {
        private HttpClient httpClient;
        private string servicePath;
        private string zipPath;
        private readonly ILogger<EntryDataServiceImpl> logger;

        public EntryDataServiceImpl(IOptions<EntryDataServiceOptions> optionsAccessor, ILoggerFactory loggerFactory)
        {
            var serviceUrl = new Uri(optionsAccessor.Value.PopServiceUrl);
            httpClient = new HttpClient() { BaseAddress = new Uri(serviceUrl.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped)) };
            servicePath = serviceUrl.LocalPath;
            zipPath = optionsAccessor.Value.DataFilePath;
            this.logger = loggerFactory.CreateLogger<EntryDataServiceImpl>();
        }

        public class QueryReply
        {
            public string StatusText;
            public Timestamp DeclareDate;
        }

        public override async Task GetYDTEntryDataFrom(GetYDTEntryDataRequest request, IServerStreamWriter<GetYDTEntryDataResponse> responseStream, ServerCallContext context)
        {
            //获取请求
            logger.LogDebug($"Peer:{context.Peer},DataFrom:{request.DateFrom}");
            var time = request.DateFrom.ToDateTime().ToLocalTime();

            string beginFile = time.ToString("yyyyMMddHH") + ".zip";
            foreach (string file in Directory.GetFiles(zipPath))
            {
                if (file.CompareTo(zipPath + beginFile) >= 0)
                {
                    //读取文件
                    var fileBytes = File.ReadAllBytes(file);
                    //返回结果
                    GetYDTEntryDataResponse ret = new GetYDTEntryDataResponse() { FileName = new FileInfo(file).Name };
                    logger.LogDebug($"GeneralFile:{ret.FileName}");
                    if (fileBytes != null)
                    {
                        ret.Data = Google.Protobuf.ByteString.CopyFrom(fileBytes);
                    }
                    await responseStream.WriteAsync(ret);

                }
            }
            logger.LogDebug($"responseStream:{responseStream}");
        }

        public override async Task<GetYDTEntryDataResponse> GetYDTEntryDataAt(GetYDTEntryDataRequest request, ServerCallContext context)
        {
            logger.LogDebug($"Peer:{context.Peer},DataFrom:{request.DateFrom}");
            var time = request.DateFrom.ToDateTime().ToLocalTime();

            string filePath = Directory.GetFiles(zipPath)
                .Where(file => string.Compare(new FileInfo(file).Name, time.ToString("yyyyMMddHH")) < 0)
                .OrderBy(file => new FileInfo(file).Name).Last();

            Task<byte[]> t = new Task<byte[]>(() => { return File.ReadAllBytes(filePath); });
            t.Start();
            byte[] fileBytes = await t;

            GetYDTEntryDataResponse response = new GetYDTEntryDataResponse();
            if (fileBytes != null)
            {
                response.FileName = new FileInfo(filePath).Name;
                response.Data = Google.Protobuf.ByteString.CopyFrom(fileBytes);
            }
            logger.LogDebug($"GeneralFile:{response.FileName}");
            return response;
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
                var res = await httpClient.GetStringAsync($"{servicePath}/{entryId}");
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