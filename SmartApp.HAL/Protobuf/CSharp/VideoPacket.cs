// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: VideoPacket.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SmartApp.HAL.Model {

  /// <summary>Holder for reflection information generated from VideoPacket.proto</summary>
  public static partial class VideoPacketReflection {

    #region Descriptor
    /// <summary>File descriptor for VideoPacket.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static VideoPacketReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFWaWRlb1BhY2tldC5wcm90byKOAQoSVmlkZW9Db250cm9sUGFja2V0EkMK",
            "EGZyYW1lcmF0ZVJlcXVlc3QYASABKAsyJy5WaWRlb0NvbnRyb2xQYWNrZXQu",
            "U2V0RnJhbWVyYXRlUmVxdWVzdEgAGigKE1NldEZyYW1lcmF0ZVJlcXVlc3QS",
            "EQoJZnJhbWVyYXRlGAEgASgFQgkKB1JlcXVlc3QiowIKD1ZpZGVvRGF0YVBh",
            "Y2tldBIRCgl0aW1lc3RhbXAYASABKAMSEgoKZnJhbWVXaWR0aBgCIAEoBRIT",
            "CgtmcmFtZUhlaWdodBgDIAEoBRIkCgVmYWNlcxgEIAMoCzIVLlZpZGVvRGF0",
            "YVBhY2tldC5GYWNlGkUKCVJlY3RhbmdsZRILCgN0b3AYASABKAUSDAoEbGVm",
            "dBgCIAEoBRINCgV3aWR0aBgDIAEoBRIOCgZoZWlnaHQYBCABKAUaZwoERmFj",
            "ZRIKCgJpZBgBIAEoAxIJCgFaGAIgASgCEhAKCHNwZWFraW5nGAMgASgFEgwK",
            "BGRhdGEYBCABKAwSKAoEcmVjdBgFIAEoCzIaLlZpZGVvRGF0YVBhY2tldC5S",
            "ZWN0YW5nbGVCFaoCElNtYXJ0QXBwLkhBTC5Nb2RlbGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SmartApp.HAL.Model.VideoControlPacket), global::SmartApp.HAL.Model.VideoControlPacket.Parser, new[]{ "FramerateRequest" }, new[]{ "Request" }, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest), global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest.Parser, new[]{ "Framerate" }, null, null, null)}),
            new pbr::GeneratedClrTypeInfo(typeof(global::SmartApp.HAL.Model.VideoDataPacket), global::SmartApp.HAL.Model.VideoDataPacket.Parser, new[]{ "Timestamp", "FrameWidth", "FrameHeight", "Faces" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle), global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle.Parser, new[]{ "Top", "Left", "Width", "Height" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SmartApp.HAL.Model.VideoDataPacket.Types.Face), global::SmartApp.HAL.Model.VideoDataPacket.Types.Face.Parser, new[]{ "Id", "Z", "Speaking", "Data", "Rect" }, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class VideoControlPacket : pb::IMessage<VideoControlPacket> {
    private static readonly pb::MessageParser<VideoControlPacket> _parser = new pb::MessageParser<VideoControlPacket>(() => new VideoControlPacket());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<VideoControlPacket> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SmartApp.HAL.Model.VideoPacketReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoControlPacket() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoControlPacket(VideoControlPacket other) : this() {
      switch (other.RequestCase) {
        case RequestOneofCase.FramerateRequest:
          FramerateRequest = other.FramerateRequest.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoControlPacket Clone() {
      return new VideoControlPacket(this);
    }

    /// <summary>Field number for the "framerateRequest" field.</summary>
    public const int FramerateRequestFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest FramerateRequest {
      get { return requestCase_ == RequestOneofCase.FramerateRequest ? (global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest) request_ : null; }
      set {
        request_ = value;
        requestCase_ = value == null ? RequestOneofCase.None : RequestOneofCase.FramerateRequest;
      }
    }

    private object request_;
    /// <summary>Enum of possible cases for the "Request" oneof.</summary>
    public enum RequestOneofCase {
      None = 0,
      FramerateRequest = 1,
    }
    private RequestOneofCase requestCase_ = RequestOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RequestOneofCase RequestCase {
      get { return requestCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearRequest() {
      requestCase_ = RequestOneofCase.None;
      request_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as VideoControlPacket);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(VideoControlPacket other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(FramerateRequest, other.FramerateRequest)) return false;
      if (RequestCase != other.RequestCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (requestCase_ == RequestOneofCase.FramerateRequest) hash ^= FramerateRequest.GetHashCode();
      hash ^= (int) requestCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (requestCase_ == RequestOneofCase.FramerateRequest) {
        output.WriteRawTag(10);
        output.WriteMessage(FramerateRequest);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (requestCase_ == RequestOneofCase.FramerateRequest) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(FramerateRequest);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(VideoControlPacket other) {
      if (other == null) {
        return;
      }
      switch (other.RequestCase) {
        case RequestOneofCase.FramerateRequest:
          if (FramerateRequest == null) {
            FramerateRequest = new global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest();
          }
          FramerateRequest.MergeFrom(other.FramerateRequest);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest subBuilder = new global::SmartApp.HAL.Model.VideoControlPacket.Types.SetFramerateRequest();
            if (requestCase_ == RequestOneofCase.FramerateRequest) {
              subBuilder.MergeFrom(FramerateRequest);
            }
            input.ReadMessage(subBuilder);
            FramerateRequest = subBuilder;
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the VideoControlPacket message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class SetFramerateRequest : pb::IMessage<SetFramerateRequest> {
        private static readonly pb::MessageParser<SetFramerateRequest> _parser = new pb::MessageParser<SetFramerateRequest>(() => new SetFramerateRequest());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<SetFramerateRequest> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::SmartApp.HAL.Model.VideoControlPacket.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SetFramerateRequest() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SetFramerateRequest(SetFramerateRequest other) : this() {
          framerate_ = other.framerate_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public SetFramerateRequest Clone() {
          return new SetFramerateRequest(this);
        }

        /// <summary>Field number for the "framerate" field.</summary>
        public const int FramerateFieldNumber = 1;
        private int framerate_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Framerate {
          get { return framerate_; }
          set {
            framerate_ = value;
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as SetFramerateRequest);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(SetFramerateRequest other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (Framerate != other.Framerate) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Framerate != 0) hash ^= Framerate.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Framerate != 0) {
            output.WriteRawTag(8);
            output.WriteInt32(Framerate);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Framerate != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Framerate);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(SetFramerateRequest other) {
          if (other == null) {
            return;
          }
          if (other.Framerate != 0) {
            Framerate = other.Framerate;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 8: {
                Framerate = input.ReadInt32();
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  public sealed partial class VideoDataPacket : pb::IMessage<VideoDataPacket> {
    private static readonly pb::MessageParser<VideoDataPacket> _parser = new pb::MessageParser<VideoDataPacket>(() => new VideoDataPacket());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<VideoDataPacket> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SmartApp.HAL.Model.VideoPacketReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoDataPacket() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoDataPacket(VideoDataPacket other) : this() {
      timestamp_ = other.timestamp_;
      frameWidth_ = other.frameWidth_;
      frameHeight_ = other.frameHeight_;
      faces_ = other.faces_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VideoDataPacket Clone() {
      return new VideoDataPacket(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private long timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "frameWidth" field.</summary>
    public const int FrameWidthFieldNumber = 2;
    private int frameWidth_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int FrameWidth {
      get { return frameWidth_; }
      set {
        frameWidth_ = value;
      }
    }

    /// <summary>Field number for the "frameHeight" field.</summary>
    public const int FrameHeightFieldNumber = 3;
    private int frameHeight_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int FrameHeight {
      get { return frameHeight_; }
      set {
        frameHeight_ = value;
      }
    }

    /// <summary>Field number for the "faces" field.</summary>
    public const int FacesFieldNumber = 4;
    private static readonly pb::FieldCodec<global::SmartApp.HAL.Model.VideoDataPacket.Types.Face> _repeated_faces_codec
        = pb::FieldCodec.ForMessage(34, global::SmartApp.HAL.Model.VideoDataPacket.Types.Face.Parser);
    private readonly pbc::RepeatedField<global::SmartApp.HAL.Model.VideoDataPacket.Types.Face> faces_ = new pbc::RepeatedField<global::SmartApp.HAL.Model.VideoDataPacket.Types.Face>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SmartApp.HAL.Model.VideoDataPacket.Types.Face> Faces {
      get { return faces_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as VideoDataPacket);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(VideoDataPacket other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Timestamp != other.Timestamp) return false;
      if (FrameWidth != other.FrameWidth) return false;
      if (FrameHeight != other.FrameHeight) return false;
      if(!faces_.Equals(other.faces_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Timestamp != 0L) hash ^= Timestamp.GetHashCode();
      if (FrameWidth != 0) hash ^= FrameWidth.GetHashCode();
      if (FrameHeight != 0) hash ^= FrameHeight.GetHashCode();
      hash ^= faces_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Timestamp != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Timestamp);
      }
      if (FrameWidth != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(FrameWidth);
      }
      if (FrameHeight != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(FrameHeight);
      }
      faces_.WriteTo(output, _repeated_faces_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Timestamp != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Timestamp);
      }
      if (FrameWidth != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(FrameWidth);
      }
      if (FrameHeight != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(FrameHeight);
      }
      size += faces_.CalculateSize(_repeated_faces_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(VideoDataPacket other) {
      if (other == null) {
        return;
      }
      if (other.Timestamp != 0L) {
        Timestamp = other.Timestamp;
      }
      if (other.FrameWidth != 0) {
        FrameWidth = other.FrameWidth;
      }
      if (other.FrameHeight != 0) {
        FrameHeight = other.FrameHeight;
      }
      faces_.Add(other.faces_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Timestamp = input.ReadInt64();
            break;
          }
          case 16: {
            FrameWidth = input.ReadInt32();
            break;
          }
          case 24: {
            FrameHeight = input.ReadInt32();
            break;
          }
          case 34: {
            faces_.AddEntriesFrom(input, _repeated_faces_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the VideoDataPacket message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class Rectangle : pb::IMessage<Rectangle> {
        private static readonly pb::MessageParser<Rectangle> _parser = new pb::MessageParser<Rectangle>(() => new Rectangle());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Rectangle> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::SmartApp.HAL.Model.VideoDataPacket.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Rectangle() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Rectangle(Rectangle other) : this() {
          top_ = other.top_;
          left_ = other.left_;
          width_ = other.width_;
          height_ = other.height_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Rectangle Clone() {
          return new Rectangle(this);
        }

        /// <summary>Field number for the "top" field.</summary>
        public const int TopFieldNumber = 1;
        private int top_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Top {
          get { return top_; }
          set {
            top_ = value;
          }
        }

        /// <summary>Field number for the "left" field.</summary>
        public const int LeftFieldNumber = 2;
        private int left_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Left {
          get { return left_; }
          set {
            left_ = value;
          }
        }

        /// <summary>Field number for the "width" field.</summary>
        public const int WidthFieldNumber = 3;
        private int width_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Width {
          get { return width_; }
          set {
            width_ = value;
          }
        }

        /// <summary>Field number for the "height" field.</summary>
        public const int HeightFieldNumber = 4;
        private int height_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Height {
          get { return height_; }
          set {
            height_ = value;
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as Rectangle);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Rectangle other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (Top != other.Top) return false;
          if (Left != other.Left) return false;
          if (Width != other.Width) return false;
          if (Height != other.Height) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Top != 0) hash ^= Top.GetHashCode();
          if (Left != 0) hash ^= Left.GetHashCode();
          if (Width != 0) hash ^= Width.GetHashCode();
          if (Height != 0) hash ^= Height.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Top != 0) {
            output.WriteRawTag(8);
            output.WriteInt32(Top);
          }
          if (Left != 0) {
            output.WriteRawTag(16);
            output.WriteInt32(Left);
          }
          if (Width != 0) {
            output.WriteRawTag(24);
            output.WriteInt32(Width);
          }
          if (Height != 0) {
            output.WriteRawTag(32);
            output.WriteInt32(Height);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Top != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Top);
          }
          if (Left != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Left);
          }
          if (Width != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Width);
          }
          if (Height != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Height);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Rectangle other) {
          if (other == null) {
            return;
          }
          if (other.Top != 0) {
            Top = other.Top;
          }
          if (other.Left != 0) {
            Left = other.Left;
          }
          if (other.Width != 0) {
            Width = other.Width;
          }
          if (other.Height != 0) {
            Height = other.Height;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 8: {
                Top = input.ReadInt32();
                break;
              }
              case 16: {
                Left = input.ReadInt32();
                break;
              }
              case 24: {
                Width = input.ReadInt32();
                break;
              }
              case 32: {
                Height = input.ReadInt32();
                break;
              }
            }
          }
        }

      }

      public sealed partial class Face : pb::IMessage<Face> {
        private static readonly pb::MessageParser<Face> _parser = new pb::MessageParser<Face>(() => new Face());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Face> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::SmartApp.HAL.Model.VideoDataPacket.Descriptor.NestedTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Face() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Face(Face other) : this() {
          id_ = other.id_;
          z_ = other.z_;
          speaking_ = other.speaking_;
          data_ = other.data_;
          rect_ = other.rect_ != null ? other.rect_.Clone() : null;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Face Clone() {
          return new Face(this);
        }

        /// <summary>Field number for the "id" field.</summary>
        public const int IdFieldNumber = 1;
        private long id_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public long Id {
          get { return id_; }
          set {
            id_ = value;
          }
        }

        /// <summary>Field number for the "Z" field.</summary>
        public const int ZFieldNumber = 2;
        private float z_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public float Z {
          get { return z_; }
          set {
            z_ = value;
          }
        }

        /// <summary>Field number for the "speaking" field.</summary>
        public const int SpeakingFieldNumber = 3;
        private int speaking_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Speaking {
          get { return speaking_; }
          set {
            speaking_ = value;
          }
        }

        /// <summary>Field number for the "data" field.</summary>
        public const int DataFieldNumber = 4;
        private pb::ByteString data_ = pb::ByteString.Empty;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pb::ByteString Data {
          get { return data_; }
          set {
            data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        /// <summary>Field number for the "rect" field.</summary>
        public const int RectFieldNumber = 5;
        private global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle rect_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle Rect {
          get { return rect_; }
          set {
            rect_ = value;
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as Face);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Face other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (Id != other.Id) return false;
          if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Z, other.Z)) return false;
          if (Speaking != other.Speaking) return false;
          if (Data != other.Data) return false;
          if (!object.Equals(Rect, other.Rect)) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Id != 0L) hash ^= Id.GetHashCode();
          if (Z != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Z);
          if (Speaking != 0) hash ^= Speaking.GetHashCode();
          if (Data.Length != 0) hash ^= Data.GetHashCode();
          if (rect_ != null) hash ^= Rect.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Id != 0L) {
            output.WriteRawTag(8);
            output.WriteInt64(Id);
          }
          if (Z != 0F) {
            output.WriteRawTag(21);
            output.WriteFloat(Z);
          }
          if (Speaking != 0) {
            output.WriteRawTag(24);
            output.WriteInt32(Speaking);
          }
          if (Data.Length != 0) {
            output.WriteRawTag(34);
            output.WriteBytes(Data);
          }
          if (rect_ != null) {
            output.WriteRawTag(42);
            output.WriteMessage(Rect);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Id != 0L) {
            size += 1 + pb::CodedOutputStream.ComputeInt64Size(Id);
          }
          if (Z != 0F) {
            size += 1 + 4;
          }
          if (Speaking != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Speaking);
          }
          if (Data.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
          }
          if (rect_ != null) {
            size += 1 + pb::CodedOutputStream.ComputeMessageSize(Rect);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Face other) {
          if (other == null) {
            return;
          }
          if (other.Id != 0L) {
            Id = other.Id;
          }
          if (other.Z != 0F) {
            Z = other.Z;
          }
          if (other.Speaking != 0) {
            Speaking = other.Speaking;
          }
          if (other.Data.Length != 0) {
            Data = other.Data;
          }
          if (other.rect_ != null) {
            if (rect_ == null) {
              rect_ = new global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle();
            }
            Rect.MergeFrom(other.Rect);
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 8: {
                Id = input.ReadInt64();
                break;
              }
              case 21: {
                Z = input.ReadFloat();
                break;
              }
              case 24: {
                Speaking = input.ReadInt32();
                break;
              }
              case 34: {
                Data = input.ReadBytes();
                break;
              }
              case 42: {
                if (rect_ == null) {
                  rect_ = new global::SmartApp.HAL.Model.VideoDataPacket.Types.Rectangle();
                }
                input.ReadMessage(rect_);
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
