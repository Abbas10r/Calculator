// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CalculatorGrpcService {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Greeter
  {
    static readonly string __ServiceName = "greet.Greeter";

    static readonly grpc::Marshaller<global::CalculatorGrpcService.HelloRequest> __Marshaller_greet_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculatorGrpcService.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculatorGrpcService.HelloReply> __Marshaller_greet_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculatorGrpcService.HelloReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculatorGrpcService.NumbersParams> __Marshaller_greet_NumbersParams = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculatorGrpcService.NumbersParams.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculatorGrpcService.SolutionResult> __Marshaller_greet_SolutionResult = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculatorGrpcService.SolutionResult.Parser.ParseFrom);

    static readonly grpc::Method<global::CalculatorGrpcService.HelloRequest, global::CalculatorGrpcService.HelloReply> __Method_SayHello = new grpc::Method<global::CalculatorGrpcService.HelloRequest, global::CalculatorGrpcService.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_greet_HelloRequest,
        __Marshaller_greet_HelloReply);

    static readonly grpc::Method<global::CalculatorGrpcService.NumbersParams, global::CalculatorGrpcService.SolutionResult> __Method_Addition = new grpc::Method<global::CalculatorGrpcService.NumbersParams, global::CalculatorGrpcService.SolutionResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Addition",
        __Marshaller_greet_NumbersParams,
        __Marshaller_greet_SolutionResult);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CalculatorGrpcService.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Greeter</summary>
    [grpc::BindServiceMethod(typeof(Greeter), "BindService")]
    public abstract partial class GreeterBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::CalculatorGrpcService.HelloReply> SayHello(global::CalculatorGrpcService.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::CalculatorGrpcService.SolutionResult> Addition(global::CalculatorGrpcService.NumbersParams request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreeterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello)
          .AddMethod(__Method_Addition, serviceImpl.Addition).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreeterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CalculatorGrpcService.HelloRequest, global::CalculatorGrpcService.HelloReply>(serviceImpl.SayHello));
      serviceBinder.AddMethod(__Method_Addition, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CalculatorGrpcService.NumbersParams, global::CalculatorGrpcService.SolutionResult>(serviceImpl.Addition));
    }

  }
}
#endregion
