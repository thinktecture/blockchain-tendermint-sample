// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: protos/types.proto

#pragma warning disable 1591

#region Designer generated code

using System;
using System.Threading;
using grpc = global::Grpc.Core;

namespace Types
{
    public static partial class ABCIApplication
    {
        static readonly string __ServiceName = "types.ABCIApplication";

        static readonly grpc::Marshaller<global::Types.RequestEcho> __Marshaller_RequestEcho =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestEcho.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseEcho> __Marshaller_ResponseEcho =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseEcho.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestFlush> __Marshaller_RequestFlush =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestFlush.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseFlush> __Marshaller_ResponseFlush =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseFlush.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestInfo> __Marshaller_RequestInfo =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestInfo.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseInfo> __Marshaller_ResponseInfo =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseInfo.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestSetOption> __Marshaller_RequestSetOption =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestSetOption.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseSetOption> __Marshaller_ResponseSetOption =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseSetOption.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestDeliverTx> __Marshaller_RequestDeliverTx =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestDeliverTx.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseDeliverTx> __Marshaller_ResponseDeliverTx =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseDeliverTx.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestCheckTx> __Marshaller_RequestCheckTx =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestCheckTx.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseCheckTx> __Marshaller_ResponseCheckTx =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseCheckTx.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestQuery> __Marshaller_RequestQuery =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestQuery.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseQuery> __Marshaller_ResponseQuery =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseQuery.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestCommit> __Marshaller_RequestCommit =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestCommit.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseCommit> __Marshaller_ResponseCommit =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseCommit.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestInitChain> __Marshaller_RequestInitChain =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestInitChain.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseInitChain> __Marshaller_ResponseInitChain =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseInitChain.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestBeginBlock> __Marshaller_RequestBeginBlock =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestBeginBlock.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseBeginBlock> __Marshaller_ResponseBeginBlock =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseBeginBlock.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.RequestEndBlock> __Marshaller_RequestEndBlock =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.RequestEndBlock.Parser.ParseFrom);

        static readonly grpc::Marshaller<global::Types.ResponseEndBlock> __Marshaller_ResponseEndBlock =
            grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Types.ResponseEndBlock.Parser.ParseFrom);

        static readonly grpc::Method<global::Types.RequestEcho, global::Types.ResponseEcho> __Method_Echo = new grpc::Method<global::Types.RequestEcho, global::Types.ResponseEcho>(
            grpc::MethodType.Unary,
            __ServiceName,
            "Echo",
            __Marshaller_RequestEcho,
            __Marshaller_ResponseEcho);

        static readonly grpc::Method<global::Types.RequestFlush, global::Types.ResponseFlush> __Method_Flush =
            new grpc::Method<global::Types.RequestFlush, global::Types.ResponseFlush>(
                grpc::MethodType.Unary,
                __ServiceName,
                "Flush",
                __Marshaller_RequestFlush,
                __Marshaller_ResponseFlush);

        static readonly grpc::Method<global::Types.RequestInfo, global::Types.ResponseInfo> __Method_Info = new grpc::Method<global::Types.RequestInfo, global::Types.ResponseInfo>(
            grpc::MethodType.Unary,
            __ServiceName,
            "Info",
            __Marshaller_RequestInfo,
            __Marshaller_ResponseInfo);

        static readonly grpc::Method<global::Types.RequestSetOption, global::Types.ResponseSetOption> __Method_SetOption =
            new grpc::Method<global::Types.RequestSetOption, global::Types.ResponseSetOption>(
                grpc::MethodType.Unary,
                __ServiceName,
                "SetOption",
                __Marshaller_RequestSetOption,
                __Marshaller_ResponseSetOption);

        static readonly grpc::Method<global::Types.RequestDeliverTx, global::Types.ResponseDeliverTx> __Method_DeliverTx =
            new grpc::Method<global::Types.RequestDeliverTx, global::Types.ResponseDeliverTx>(
                grpc::MethodType.Unary,
                __ServiceName,
                "DeliverTx",
                __Marshaller_RequestDeliverTx,
                __Marshaller_ResponseDeliverTx);

        static readonly grpc::Method<global::Types.RequestCheckTx, global::Types.ResponseCheckTx> __Method_CheckTx =
            new grpc::Method<global::Types.RequestCheckTx, global::Types.ResponseCheckTx>(
                grpc::MethodType.Unary,
                __ServiceName,
                "CheckTx",
                __Marshaller_RequestCheckTx,
                __Marshaller_ResponseCheckTx);

        static readonly grpc::Method<global::Types.RequestQuery, global::Types.ResponseQuery> __Method_Query =
            new grpc::Method<global::Types.RequestQuery, global::Types.ResponseQuery>(
                grpc::MethodType.Unary,
                __ServiceName,
                "Query",
                __Marshaller_RequestQuery,
                __Marshaller_ResponseQuery);

        static readonly grpc::Method<global::Types.RequestCommit, global::Types.ResponseCommit> __Method_Commit =
            new grpc::Method<global::Types.RequestCommit, global::Types.ResponseCommit>(
                grpc::MethodType.Unary,
                __ServiceName,
                "Commit",
                __Marshaller_RequestCommit,
                __Marshaller_ResponseCommit);

        static readonly grpc::Method<global::Types.RequestInitChain, global::Types.ResponseInitChain> __Method_InitChain =
            new grpc::Method<global::Types.RequestInitChain, global::Types.ResponseInitChain>(
                grpc::MethodType.Unary,
                __ServiceName,
                "InitChain",
                __Marshaller_RequestInitChain,
                __Marshaller_ResponseInitChain);

        static readonly grpc::Method<global::Types.RequestBeginBlock, global::Types.ResponseBeginBlock> __Method_BeginBlock =
            new grpc::Method<global::Types.RequestBeginBlock, global::Types.ResponseBeginBlock>(
                grpc::MethodType.Unary,
                __ServiceName,
                "BeginBlock",
                __Marshaller_RequestBeginBlock,
                __Marshaller_ResponseBeginBlock);

        static readonly grpc::Method<global::Types.RequestEndBlock, global::Types.ResponseEndBlock> __Method_EndBlock =
            new grpc::Method<global::Types.RequestEndBlock, global::Types.ResponseEndBlock>(
                grpc::MethodType.Unary,
                __ServiceName,
                "EndBlock",
                __Marshaller_RequestEndBlock,
                __Marshaller_ResponseEndBlock);

        /// <summary>Service descriptor</summary>
        public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
        {
            get { return global::Types.TypesReflection.Descriptor.Services[0]; }
        }

        /// <summary>Base class for server-side implementations of ABCIApplication</summary>
        public abstract partial class ABCIApplicationBase
        {
            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseEcho> Echo(global::Types.RequestEcho request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseFlush> Flush(global::Types.RequestFlush request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseInfo> Info(global::Types.RequestInfo request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseSetOption> SetOption(global::Types.RequestSetOption request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseDeliverTx> DeliverTx(global::Types.RequestDeliverTx request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseCheckTx> CheckTx(global::Types.RequestCheckTx request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseQuery> Query(global::Types.RequestQuery request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseCommit> Commit(global::Types.RequestCommit request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseInitChain> InitChain(global::Types.RequestInitChain request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseBeginBlock> BeginBlock(global::Types.RequestBeginBlock request,
                grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Types.ResponseEndBlock> EndBlock(global::Types.RequestEndBlock request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }
        }

        /// <summary>Client for ABCIApplication</summary>
        public partial class ABCIApplicationClient : grpc::ClientBase<ABCIApplicationClient>
        {
            /// <summary>Creates a new client for ABCIApplication</summary>
            /// <param name="channel">The channel to use to make remote calls.</param>
            public ABCIApplicationClient(grpc::Channel channel) : base(channel)
            {
            }

            /// <summary>Creates a new client for ABCIApplication that uses a custom <c>CallInvoker</c>.</summary>
            /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
            public ABCIApplicationClient(grpc::CallInvoker callInvoker) : base(callInvoker)
            {
            }

            /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
            protected ABCIApplicationClient() : base()
            {
            }

            /// <summary>Protected constructor to allow creation of configured clients.</summary>
            /// <param name="configuration">The client configuration.</param>
            protected ABCIApplicationClient(ClientBaseConfiguration configuration) : base(configuration)
            {
            }

            public virtual global::Types.ResponseEcho Echo(global::Types.RequestEcho request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return Echo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseEcho Echo(global::Types.RequestEcho request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Echo, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseEcho> EchoAsync(global::Types.RequestEcho request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return EchoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseEcho> EchoAsync(global::Types.RequestEcho request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Echo, null, options, request);
            }

            public virtual global::Types.ResponseFlush Flush(global::Types.RequestFlush request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return Flush(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseFlush Flush(global::Types.RequestFlush request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Flush, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseFlush> FlushAsync(global::Types.RequestFlush request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return FlushAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseFlush> FlushAsync(global::Types.RequestFlush request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Flush, null, options, request);
            }

            public virtual global::Types.ResponseInfo Info(global::Types.RequestInfo request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return Info(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseInfo Info(global::Types.RequestInfo request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Info, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseInfo> InfoAsync(global::Types.RequestInfo request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return InfoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseInfo> InfoAsync(global::Types.RequestInfo request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Info, null, options, request);
            }

            public virtual global::Types.ResponseSetOption SetOption(global::Types.RequestSetOption request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return SetOption(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseSetOption SetOption(global::Types.RequestSetOption request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_SetOption, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseSetOption> SetOptionAsync(global::Types.RequestSetOption request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return SetOptionAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseSetOption> SetOptionAsync(global::Types.RequestSetOption request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_SetOption, null, options, request);
            }

            public virtual global::Types.ResponseDeliverTx DeliverTx(global::Types.RequestDeliverTx request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return DeliverTx(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseDeliverTx DeliverTx(global::Types.RequestDeliverTx request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_DeliverTx, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseDeliverTx> DeliverTxAsync(global::Types.RequestDeliverTx request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return DeliverTxAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseDeliverTx> DeliverTxAsync(global::Types.RequestDeliverTx request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_DeliverTx, null, options, request);
            }

            public virtual global::Types.ResponseCheckTx CheckTx(global::Types.RequestCheckTx request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return CheckTx(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseCheckTx CheckTx(global::Types.RequestCheckTx request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_CheckTx, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseCheckTx> CheckTxAsync(global::Types.RequestCheckTx request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return CheckTxAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseCheckTx> CheckTxAsync(global::Types.RequestCheckTx request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_CheckTx, null, options, request);
            }

            public virtual global::Types.ResponseQuery Query(global::Types.RequestQuery request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return Query(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseQuery Query(global::Types.RequestQuery request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Query, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseQuery> QueryAsync(global::Types.RequestQuery request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return QueryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseQuery> QueryAsync(global::Types.RequestQuery request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Query, null, options, request);
            }

            public virtual global::Types.ResponseCommit Commit(global::Types.RequestCommit request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return Commit(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseCommit Commit(global::Types.RequestCommit request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Commit, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseCommit> CommitAsync(global::Types.RequestCommit request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return CommitAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseCommit> CommitAsync(global::Types.RequestCommit request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Commit, null, options, request);
            }

            public virtual global::Types.ResponseInitChain InitChain(global::Types.RequestInitChain request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return InitChain(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseInitChain InitChain(global::Types.RequestInitChain request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_InitChain, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseInitChain> InitChainAsync(global::Types.RequestInitChain request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return InitChainAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseInitChain> InitChainAsync(global::Types.RequestInitChain request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_InitChain, null, options, request);
            }

            public virtual global::Types.ResponseBeginBlock BeginBlock(global::Types.RequestBeginBlock request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return BeginBlock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseBeginBlock BeginBlock(global::Types.RequestBeginBlock request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_BeginBlock, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseBeginBlock> BeginBlockAsync(global::Types.RequestBeginBlock request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return BeginBlockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseBeginBlock> BeginBlockAsync(global::Types.RequestBeginBlock request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_BeginBlock, null, options, request);
            }

            public virtual global::Types.ResponseEndBlock EndBlock(global::Types.RequestEndBlock request, grpc::Metadata headers = null, DateTime? deadline = null,
                CancellationToken cancellationToken = default(CancellationToken))
            {
                return EndBlock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual global::Types.ResponseEndBlock EndBlock(global::Types.RequestEndBlock request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_EndBlock, null, options, request);
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseEndBlock> EndBlockAsync(global::Types.RequestEndBlock request, grpc::Metadata headers = null,
                DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return EndBlockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }

            public virtual grpc::AsyncUnaryCall<global::Types.ResponseEndBlock> EndBlockAsync(global::Types.RequestEndBlock request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_EndBlock, null, options, request);
            }

            /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
            protected override ABCIApplicationClient NewInstance(ClientBaseConfiguration configuration)
            {
                return new ABCIApplicationClient(configuration);
            }
        }

        /// <summary>Creates service definition that can be registered with a server</summary>
        /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
        public static grpc::ServerServiceDefinition BindService(ABCIApplicationBase serviceImpl)
        {
            return grpc::ServerServiceDefinition.CreateBuilder()
                .AddMethod(__Method_Echo, serviceImpl.Echo)
                .AddMethod(__Method_Flush, serviceImpl.Flush)
                .AddMethod(__Method_Info, serviceImpl.Info)
                .AddMethod(__Method_SetOption, serviceImpl.SetOption)
                .AddMethod(__Method_DeliverTx, serviceImpl.DeliverTx)
                .AddMethod(__Method_CheckTx, serviceImpl.CheckTx)
                .AddMethod(__Method_Query, serviceImpl.Query)
                .AddMethod(__Method_Commit, serviceImpl.Commit)
                .AddMethod(__Method_InitChain, serviceImpl.InitChain)
                .AddMethod(__Method_BeginBlock, serviceImpl.BeginBlock)
                .AddMethod(__Method_EndBlock, serviceImpl.EndBlock).Build();
        }
    }
}

#endregion
