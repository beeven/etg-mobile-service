// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: service.proto

package etg.service;

public final class EtgProto {
  private EtgProto() {}
  public static void registerAllExtensions(
      com.google.protobuf.ExtensionRegistryLite registry) {
  }

  public static void registerAllExtensions(
      com.google.protobuf.ExtensionRegistry registry) {
    registerAllExtensions(
        (com.google.protobuf.ExtensionRegistryLite) registry);
  }

  public static com.google.protobuf.Descriptors.FileDescriptor
      getDescriptor() {
    return descriptor;
  }
  private static  com.google.protobuf.Descriptors.FileDescriptor
      descriptor;
  static {
    java.lang.String[] descriptorData = {
      "\n\rservice.proto\022\013etg.service\032\rprofile.pr" +
      "oto\032\nauth.proto2?\n\004Auth\0227\n\005Login\022\026.etg.a" +
      "uth.LoginRequest\032\024.etg.auth.LoginReply\"\000" +
      "B-\n\013etg.serviceB\010EtgProtoP\001\242\002\003ETG\252\002\013Etg." +
      "ServiceP\000P\001b\006proto3"
    };
    com.google.protobuf.Descriptors.FileDescriptor.InternalDescriptorAssigner assigner =
        new com.google.protobuf.Descriptors.FileDescriptor.    InternalDescriptorAssigner() {
          public com.google.protobuf.ExtensionRegistry assignDescriptors(
              com.google.protobuf.Descriptors.FileDescriptor root) {
            descriptor = root;
            return null;
          }
        };
    com.google.protobuf.Descriptors.FileDescriptor
      .internalBuildGeneratedFileFrom(descriptorData,
        new com.google.protobuf.Descriptors.FileDescriptor[] {
          etg.profile.Profile.getDescriptor(),
          etg.auth.EtgProto.getDescriptor(),
        }, assigner);
    etg.profile.Profile.getDescriptor();
    etg.auth.EtgProto.getDescriptor();
  }

  // @@protoc_insertion_point(outer_class_scope)
}
