//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: protos/mail.proto
namespace yy.proto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"mail_list_c2s")]
  public partial class mail_list_c2s : global::ProtoBuf.IExtensible
  {
    public mail_list_c2s() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"mail_list_s2c")]
  public partial class mail_list_s2c : global::ProtoBuf.IExtensible
  {
    public mail_list_s2c() {}
    
    private readonly global::System.Collections.Generic.List<yy.proto.p_mailInfo> _mail_list = new global::System.Collections.Generic.List<yy.proto.p_mailInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"mail_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<yy.proto.p_mailInfo> mail_list
    {
      get { return _mail_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"p_mailInfo")]
  public partial class p_mailInfo : global::ProtoBuf.IExtensible
  {
    public p_mailInfo() {}
    
    private long _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int type
    {
      get { return _type; }
      set { _type = value; }
    }
    private long _from_id = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"from_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long from_id
    {
      get { return _from_id; }
      set { _from_id = value; }
    }
    private long _send_time = default(long);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"send_time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long send_time
    {
      get { return _send_time; }
      set { _send_time = value; }
    }
    private string _title = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"title", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string title
    {
      get { return _title; }
      set { _title = value; }
    }
    private string _content = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string content
    {
      get { return _content; }
      set { _content = value; }
    }
    private bool _is_read = default(bool);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"is_read", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool is_read
    {
      get { return _is_read; }
      set { _is_read = value; }
    }
    private bool _is_extract = default(bool);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"is_extract", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool is_extract
    {
      get { return _is_extract; }
      set { _is_extract = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"mail_open_c2s")]
  public partial class mail_open_c2s : global::ProtoBuf.IExtensible
  {
    public mail_open_c2s() {}
    
    private long _mail_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"mail_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long mail_id
    {
      get { return _mail_id; }
      set { _mail_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"mail_open_s2c")]
  public partial class mail_open_s2c : global::ProtoBuf.IExtensible
  {
    public mail_open_s2c() {}
    
    private bool _success;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"success", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool success
    {
      get { return _success; }
      set { _success = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"clean_mails_c2s")]
  public partial class clean_mails_c2s : global::ProtoBuf.IExtensible
  {
    public clean_mails_c2s() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}