// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: data_entry.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Etg.Data.Entry {

  /// <summary>Holder for reflection information generated from data_entry.proto</summary>
  public static partial class DataEntryReflection {

    #region Descriptor
    /// <summary>File descriptor for data_entry.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataEntryReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBkYXRhX2VudHJ5LnByb3RvEg5ldGcuZGF0YS5lbnRyeRofZ29vZ2xlL3By",
            "b3RvYnVmL3RpbWVzdGFtcC5wcm90byIpChVHZXRFbnRyeVN0YXR1c1JlcXVl",
            "c3QSEAoIZW50cnlfaWQYASABKAkicQoWR2V0RW50cnlTdGF0dXNSZXNwb25z",
            "ZRIQCghlbnRyeV9pZBgBIAEoCRITCgtzdGF0dXNfdGV4dBgCIAEoCRIwCgxk",
            "ZWNsYXJlX2RhdGUYAyABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1w",
            "MnkKEEVudHJ5RGF0YVNlcnZpY2USZQoOR2V0RW50cnlTdGF0dXMSJS5ldGcu",
            "ZGF0YS5lbnRyeS5HZXRFbnRyeVN0YXR1c1JlcXVlc3QaJi5ldGcuZGF0YS5l",
            "bnRyeS5HZXRFbnRyeVN0YXR1c1Jlc3BvbnNlIgAoATABQjMKDmV0Zy5kYXRh",
            "LmVudHJ5QghFdGdQcm90b1ABogIDRVRHqgIORXRnLkRhdGEuRW50cnliBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Etg.Data.Entry.GetEntryStatusRequest), global::Etg.Data.Entry.GetEntryStatusRequest.Parser, new[]{ "EntryId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Etg.Data.Entry.GetEntryStatusResponse), global::Etg.Data.Entry.GetEntryStatusResponse.Parser, new[]{ "EntryId", "StatusText", "DeclareDate" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetEntryStatusRequest : pb::IMessage<GetEntryStatusRequest> {
    private static readonly pb::MessageParser<GetEntryStatusRequest> _parser = new pb::MessageParser<GetEntryStatusRequest>(() => new GetEntryStatusRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryStatusRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Etg.Data.Entry.DataEntryReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusRequest(GetEntryStatusRequest other) : this() {
      entryId_ = other.entryId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusRequest Clone() {
      return new GetEntryStatusRequest(this);
    }

    /// <summary>Field number for the "entry_id" field.</summary>
    public const int EntryIdFieldNumber = 1;
    private string entryId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EntryId {
      get { return entryId_; }
      set {
        entryId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryStatusRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryStatusRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EntryId != other.EntryId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EntryId.Length != 0) hash ^= EntryId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EntryId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EntryId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EntryId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EntryId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryStatusRequest other) {
      if (other == null) {
        return;
      }
      if (other.EntryId.Length != 0) {
        EntryId = other.EntryId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            EntryId = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetEntryStatusResponse : pb::IMessage<GetEntryStatusResponse> {
    private static readonly pb::MessageParser<GetEntryStatusResponse> _parser = new pb::MessageParser<GetEntryStatusResponse>(() => new GetEntryStatusResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryStatusResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Etg.Data.Entry.DataEntryReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusResponse(GetEntryStatusResponse other) : this() {
      entryId_ = other.entryId_;
      statusText_ = other.statusText_;
      DeclareDate = other.declareDate_ != null ? other.DeclareDate.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryStatusResponse Clone() {
      return new GetEntryStatusResponse(this);
    }

    /// <summary>Field number for the "entry_id" field.</summary>
    public const int EntryIdFieldNumber = 1;
    private string entryId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EntryId {
      get { return entryId_; }
      set {
        entryId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "status_text" field.</summary>
    public const int StatusTextFieldNumber = 2;
    private string statusText_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string StatusText {
      get { return statusText_; }
      set {
        statusText_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "declare_date" field.</summary>
    public const int DeclareDateFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Timestamp declareDate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp DeclareDate {
      get { return declareDate_; }
      set {
        declareDate_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryStatusResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryStatusResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EntryId != other.EntryId) return false;
      if (StatusText != other.StatusText) return false;
      if (!object.Equals(DeclareDate, other.DeclareDate)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EntryId.Length != 0) hash ^= EntryId.GetHashCode();
      if (StatusText.Length != 0) hash ^= StatusText.GetHashCode();
      if (declareDate_ != null) hash ^= DeclareDate.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EntryId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EntryId);
      }
      if (StatusText.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(StatusText);
      }
      if (declareDate_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(DeclareDate);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EntryId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EntryId);
      }
      if (StatusText.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StatusText);
      }
      if (declareDate_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DeclareDate);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryStatusResponse other) {
      if (other == null) {
        return;
      }
      if (other.EntryId.Length != 0) {
        EntryId = other.EntryId;
      }
      if (other.StatusText.Length != 0) {
        StatusText = other.StatusText;
      }
      if (other.declareDate_ != null) {
        if (declareDate_ == null) {
          declareDate_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        DeclareDate.MergeFrom(other.DeclareDate);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            EntryId = input.ReadString();
            break;
          }
          case 18: {
            StatusText = input.ReadString();
            break;
          }
          case 26: {
            if (declareDate_ == null) {
              declareDate_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(declareDate_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code