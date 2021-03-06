// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: entry_data.proto
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Etg.Data.Entry {
  public static class EntryDataService
  {
    static readonly string __ServiceName = "etg.data.entry.EntryDataService";

    static readonly Marshaller<global::Etg.Data.Entry.GetEntryStatusRequest> __Marshaller_GetEntryStatusRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Etg.Data.Entry.GetEntryStatusRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Etg.Data.Entry.GetEntryStatusResponse> __Marshaller_GetEntryStatusResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Etg.Data.Entry.GetEntryStatusResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Etg.Data.Entry.GetYDTEntryDataRequest> __Marshaller_GetYDTEntryDataRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Etg.Data.Entry.GetYDTEntryDataRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Etg.Data.Entry.GetYDTEntryDataResponse> __Marshaller_GetYDTEntryDataResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Etg.Data.Entry.GetYDTEntryDataResponse.Parser.ParseFrom);

    static readonly Method<global::Etg.Data.Entry.GetEntryStatusRequest, global::Etg.Data.Entry.GetEntryStatusResponse> __Method_GetEntryStatus = new Method<global::Etg.Data.Entry.GetEntryStatusRequest, global::Etg.Data.Entry.GetEntryStatusResponse>(
        MethodType.DuplexStreaming,
        __ServiceName,
        "GetEntryStatus",
        __Marshaller_GetEntryStatusRequest,
        __Marshaller_GetEntryStatusResponse);

    static readonly Method<global::Etg.Data.Entry.GetYDTEntryDataRequest, global::Etg.Data.Entry.GetYDTEntryDataResponse> __Method_GetYDTEntryDataFrom = new Method<global::Etg.Data.Entry.GetYDTEntryDataRequest, global::Etg.Data.Entry.GetYDTEntryDataResponse>(
        MethodType.ServerStreaming,
        __ServiceName,
        "GetYDTEntryDataFrom",
        __Marshaller_GetYDTEntryDataRequest,
        __Marshaller_GetYDTEntryDataResponse);

    static readonly Method<global::Etg.Data.Entry.GetYDTEntryDataRequest, global::Etg.Data.Entry.GetYDTEntryDataResponse> __Method_GetYDTEntryDataAt = new Method<global::Etg.Data.Entry.GetYDTEntryDataRequest, global::Etg.Data.Entry.GetYDTEntryDataResponse>(
        MethodType.Unary,
        __ServiceName,
        "GetYDTEntryDataAt",
        __Marshaller_GetYDTEntryDataRequest,
        __Marshaller_GetYDTEntryDataResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Etg.Data.Entry.EntryDataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of EntryDataService</summary>
    public abstract class EntryDataServiceBase
    {
      public virtual global::System.Threading.Tasks.Task GetEntryStatus(IAsyncStreamReader<global::Etg.Data.Entry.GetEntryStatusRequest> requestStream, IServerStreamWriter<global::Etg.Data.Entry.GetEntryStatusResponse> responseStream, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task GetYDTEntryDataFrom(global::Etg.Data.Entry.GetYDTEntryDataRequest request, IServerStreamWriter<global::Etg.Data.Entry.GetYDTEntryDataResponse> responseStream, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Etg.Data.Entry.GetYDTEntryDataResponse> GetYDTEntryDataAt(global::Etg.Data.Entry.GetYDTEntryDataRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for EntryDataService</summary>
    public class EntryDataServiceClient : ClientBase<EntryDataServiceClient>
    {
      /// <summary>Creates a new client for EntryDataService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public EntryDataServiceClient(Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for EntryDataService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public EntryDataServiceClient(CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected EntryDataServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected EntryDataServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual AsyncDuplexStreamingCall<global::Etg.Data.Entry.GetEntryStatusRequest, global::Etg.Data.Entry.GetEntryStatusResponse> GetEntryStatus(Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetEntryStatus(new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncDuplexStreamingCall<global::Etg.Data.Entry.GetEntryStatusRequest, global::Etg.Data.Entry.GetEntryStatusResponse> GetEntryStatus(CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_GetEntryStatus, null, options);
      }
      public virtual AsyncServerStreamingCall<global::Etg.Data.Entry.GetYDTEntryDataResponse> GetYDTEntryDataFrom(global::Etg.Data.Entry.GetYDTEntryDataRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetYDTEntryDataFrom(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncServerStreamingCall<global::Etg.Data.Entry.GetYDTEntryDataResponse> GetYDTEntryDataFrom(global::Etg.Data.Entry.GetYDTEntryDataRequest request, CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetYDTEntryDataFrom, null, options, request);
      }
      public virtual global::Etg.Data.Entry.GetYDTEntryDataResponse GetYDTEntryDataAt(global::Etg.Data.Entry.GetYDTEntryDataRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetYDTEntryDataAt(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Etg.Data.Entry.GetYDTEntryDataResponse GetYDTEntryDataAt(global::Etg.Data.Entry.GetYDTEntryDataRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetYDTEntryDataAt, null, options, request);
      }
      public virtual AsyncUnaryCall<global::Etg.Data.Entry.GetYDTEntryDataResponse> GetYDTEntryDataAtAsync(global::Etg.Data.Entry.GetYDTEntryDataRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetYDTEntryDataAtAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncUnaryCall<global::Etg.Data.Entry.GetYDTEntryDataResponse> GetYDTEntryDataAtAsync(global::Etg.Data.Entry.GetYDTEntryDataRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetYDTEntryDataAt, null, options, request);
      }
      protected override EntryDataServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new EntryDataServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    public static ServerServiceDefinition BindService(EntryDataServiceBase serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetEntryStatus, serviceImpl.GetEntryStatus)
          .AddMethod(__Method_GetYDTEntryDataFrom, serviceImpl.GetYDTEntryDataFrom)
          .AddMethod(__Method_GetYDTEntryDataAt, serviceImpl.GetYDTEntryDataAt).Build();
    }

  }
}
#endregion
