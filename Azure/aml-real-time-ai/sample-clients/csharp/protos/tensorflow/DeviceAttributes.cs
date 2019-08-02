// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: tensorflow/core/framework/device_attributes.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Tensorflow {

  /// <summary>Holder for reflection information generated from tensorflow/core/framework/device_attributes.proto</summary>
  public static partial class DeviceAttributesReflection {

    #region Descriptor
    /// <summary>File descriptor for tensorflow/core/framework/device_attributes.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DeviceAttributesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjF0ZW5zb3JmbG93L2NvcmUvZnJhbWV3b3JrL2RldmljZV9hdHRyaWJ1dGVz",
            "LnByb3RvEgp0ZW5zb3JmbG93IiAKDkRldmljZUxvY2FsaXR5Eg4KBmJ1c19p",
            "ZBgBIAEoBSKsAQoQRGV2aWNlQXR0cmlidXRlcxIMCgRuYW1lGAEgASgJEhMK",
            "C2RldmljZV90eXBlGAIgASgJEhQKDG1lbW9yeV9saW1pdBgEIAEoAxIsCghs",
            "b2NhbGl0eRgFIAEoCzIaLnRlbnNvcmZsb3cuRGV2aWNlTG9jYWxpdHkSEwoL",
            "aW5jYXJuYXRpb24YBiABKAYSHAoUcGh5c2ljYWxfZGV2aWNlX2Rlc2MYByAB",
            "KAlCNwoYb3JnLnRlbnNvcmZsb3cuZnJhbWV3b3JrQhZEZXZpY2VBdHRyaWJ1",
            "dGVzUHJvdG9zUAH4AQFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Tensorflow.DeviceLocality), global::Tensorflow.DeviceLocality.Parser, new[]{ "BusId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Tensorflow.DeviceAttributes), global::Tensorflow.DeviceAttributes.Parser, new[]{ "Name", "DeviceType", "MemoryLimit", "Locality", "Incarnation", "PhysicalDeviceDesc" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class DeviceLocality : pb::IMessage<DeviceLocality> {
    private static readonly pb::MessageParser<DeviceLocality> _parser = new pb::MessageParser<DeviceLocality>(() => new DeviceLocality());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DeviceLocality> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tensorflow.DeviceAttributesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceLocality() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceLocality(DeviceLocality other) : this() {
      busId_ = other.busId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceLocality Clone() {
      return new DeviceLocality(this);
    }

    /// <summary>Field number for the "bus_id" field.</summary>
    public const int BusIdFieldNumber = 1;
    private int busId_;
    /// <summary>
    /// Optional bus locality of device.  Default value of 0 means
    /// no specific locality.  Specific localities are indexed from 1.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int BusId {
      get { return busId_; }
      set {
        busId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DeviceLocality);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DeviceLocality other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BusId != other.BusId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (BusId != 0) hash ^= BusId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (BusId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BusId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (BusId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BusId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DeviceLocality other) {
      if (other == null) {
        return;
      }
      if (other.BusId != 0) {
        BusId = other.BusId;
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
          case 8: {
            BusId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class DeviceAttributes : pb::IMessage<DeviceAttributes> {
    private static readonly pb::MessageParser<DeviceAttributes> _parser = new pb::MessageParser<DeviceAttributes>(() => new DeviceAttributes());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DeviceAttributes> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Tensorflow.DeviceAttributesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceAttributes() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceAttributes(DeviceAttributes other) : this() {
      name_ = other.name_;
      deviceType_ = other.deviceType_;
      memoryLimit_ = other.memoryLimit_;
      Locality = other.locality_ != null ? other.Locality.Clone() : null;
      incarnation_ = other.incarnation_;
      physicalDeviceDesc_ = other.physicalDeviceDesc_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DeviceAttributes Clone() {
      return new DeviceAttributes(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    /// <summary>
    /// Fully specified name of the device within a cluster.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "device_type" field.</summary>
    public const int DeviceTypeFieldNumber = 2;
    private string deviceType_ = "";
    /// <summary>
    /// String representation of device_type.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DeviceType {
      get { return deviceType_; }
      set {
        deviceType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "memory_limit" field.</summary>
    public const int MemoryLimitFieldNumber = 4;
    private long memoryLimit_;
    /// <summary>
    /// Memory capacity of device in bytes.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MemoryLimit {
      get { return memoryLimit_; }
      set {
        memoryLimit_ = value;
      }
    }

    /// <summary>Field number for the "locality" field.</summary>
    public const int LocalityFieldNumber = 5;
    private global::Tensorflow.DeviceLocality locality_;
    /// <summary>
    /// Platform-specific data about device that may be useful
    /// for supporting efficient data transfers.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Tensorflow.DeviceLocality Locality {
      get { return locality_; }
      set {
        locality_ = value;
      }
    }

    /// <summary>Field number for the "incarnation" field.</summary>
    public const int IncarnationFieldNumber = 6;
    private ulong incarnation_;
    /// <summary>
    /// A device is assigned a global unique number each time it is
    /// initialized. "incarnation" should never be 0.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Incarnation {
      get { return incarnation_; }
      set {
        incarnation_ = value;
      }
    }

    /// <summary>Field number for the "physical_device_desc" field.</summary>
    public const int PhysicalDeviceDescFieldNumber = 7;
    private string physicalDeviceDesc_ = "";
    /// <summary>
    /// String representation of the physical device that this device maps to.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PhysicalDeviceDesc {
      get { return physicalDeviceDesc_; }
      set {
        physicalDeviceDesc_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DeviceAttributes);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DeviceAttributes other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (DeviceType != other.DeviceType) return false;
      if (MemoryLimit != other.MemoryLimit) return false;
      if (!object.Equals(Locality, other.Locality)) return false;
      if (Incarnation != other.Incarnation) return false;
      if (PhysicalDeviceDesc != other.PhysicalDeviceDesc) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (DeviceType.Length != 0) hash ^= DeviceType.GetHashCode();
      if (MemoryLimit != 0L) hash ^= MemoryLimit.GetHashCode();
      if (locality_ != null) hash ^= Locality.GetHashCode();
      if (Incarnation != 0UL) hash ^= Incarnation.GetHashCode();
      if (PhysicalDeviceDesc.Length != 0) hash ^= PhysicalDeviceDesc.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (DeviceType.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(DeviceType);
      }
      if (MemoryLimit != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(MemoryLimit);
      }
      if (locality_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Locality);
      }
      if (Incarnation != 0UL) {
        output.WriteRawTag(49);
        output.WriteFixed64(Incarnation);
      }
      if (PhysicalDeviceDesc.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(PhysicalDeviceDesc);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (DeviceType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DeviceType);
      }
      if (MemoryLimit != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MemoryLimit);
      }
      if (locality_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Locality);
      }
      if (Incarnation != 0UL) {
        size += 1 + 8;
      }
      if (PhysicalDeviceDesc.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhysicalDeviceDesc);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DeviceAttributes other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.DeviceType.Length != 0) {
        DeviceType = other.DeviceType;
      }
      if (other.MemoryLimit != 0L) {
        MemoryLimit = other.MemoryLimit;
      }
      if (other.locality_ != null) {
        if (locality_ == null) {
          locality_ = new global::Tensorflow.DeviceLocality();
        }
        Locality.MergeFrom(other.Locality);
      }
      if (other.Incarnation != 0UL) {
        Incarnation = other.Incarnation;
      }
      if (other.PhysicalDeviceDesc.Length != 0) {
        PhysicalDeviceDesc = other.PhysicalDeviceDesc;
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
            Name = input.ReadString();
            break;
          }
          case 18: {
            DeviceType = input.ReadString();
            break;
          }
          case 32: {
            MemoryLimit = input.ReadInt64();
            break;
          }
          case 42: {
            if (locality_ == null) {
              locality_ = new global::Tensorflow.DeviceLocality();
            }
            input.ReadMessage(locality_);
            break;
          }
          case 49: {
            Incarnation = input.ReadFixed64();
            break;
          }
          case 58: {
            PhysicalDeviceDesc = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
