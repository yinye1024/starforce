//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: protos/prop.proto
// Note: requires additional types generated from: comm.proto
namespace yy.proto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_prop_player_c2s")]
  public partial class role_prop_player_c2s : global::ProtoBuf.IExtensible
  {
    public role_prop_player_c2s() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_prop_player_s2c")]
  public partial class role_prop_player_s2c : global::ProtoBuf.IExtensible
  {
    public role_prop_player_s2c() {}
    
    private readonly global::System.Collections.Generic.List<yy.proto.p_kv_int> _kv_list = new global::System.Collections.Generic.List<yy.proto.p_kv_int>();
    [global::ProtoBuf.ProtoMember(1, Name=@"kv_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<yy.proto.p_kv_int> kv_list
    {
      get { return _kv_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_prop_player_changed_s2c")]
  public partial class role_prop_player_changed_s2c : global::ProtoBuf.IExtensible
  {
    public role_prop_player_changed_s2c() {}
    
    private readonly global::System.Collections.Generic.List<yy.proto.p_kv_int> _kv_list = new global::System.Collections.Generic.List<yy.proto.p_kv_int>();
    [global::ProtoBuf.ProtoMember(1, Name=@"kv_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<yy.proto.p_kv_int> kv_list
    {
      get { return _kv_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}