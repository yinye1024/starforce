//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: protos/login.proto
namespace yy.proto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"connect_active_s2c")]
  public partial class connect_active_s2c : global::ProtoBuf.IExtensible
  {
    public connect_active_s2c() {}
    
    private int _result_code;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result_code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int result_code
    {
      get { return _result_code; }
      set { _result_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_login_c2s")]
  public partial class role_login_c2s : global::ProtoBuf.IExtensible
  {
    public role_login_c2s() {}
    
    private int _uid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private string _uname;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"uname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string uname
    {
      get { return _uname; }
      set { _uname = value; }
    }
    private string _plat;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"plat", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string plat
    {
      get { return _plat; }
      set { _plat = value; }
    }
    private string _game_id;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"game_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string game_id
    {
      get { return _game_id; }
      set { _game_id = value; }
    }
    private int _svrId;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"svrId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int svrId
    {
      get { return _svrId; }
      set { _svrId = value; }
    }
    private yy.proto.p_machineInfo _machine_info = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"machine_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public yy.proto.p_machineInfo machine_info
    {
      get { return _machine_info; }
      set { _machine_info = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"p_machineInfo")]
  public partial class p_machineInfo : global::ProtoBuf.IExtensible
  {
    public p_machineInfo() {}
    
    private string _device = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"device", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device
    {
      get { return _device; }
      set { _device = value; }
    }
    private string _device_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private string _device_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"device_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_name
    {
      get { return _device_name; }
      set { _device_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_reconnect_c2s")]
  public partial class role_reconnect_c2s : global::ProtoBuf.IExtensible
  {
    public role_reconnect_c2s() {}
    
    private int _uid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private int _svr_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"svr_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int svr_id
    {
      get { return _svr_id; }
      set { _svr_id = value; }
    }
    private int _client_mid;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"client_mid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int client_mid
    {
      get { return _client_mid; }
      set { _client_mid = value; }
    }
    private int _svr_mid;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"svr_mid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int svr_mid
    {
      get { return _svr_mid; }
      set { _svr_mid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_reconnect_s2c")]
  public partial class role_reconnect_s2c : global::ProtoBuf.IExtensible
  {
    public role_reconnect_s2c() {}
    
    private bool _need_login;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"need_login", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool need_login
    {
      get { return _need_login; }
      set { _need_login = value; }
    }
    private bool _has_pack;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"has_pack", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool has_pack
    {
      get { return _has_pack; }
      set { _has_pack = value; }
    }
    private int _last_client_mid = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"last_client_mid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int last_client_mid
    {
      get { return _last_client_mid; }
      set { _last_client_mid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"reset_gw_mid_c2s")]
  public partial class reset_gw_mid_c2s : global::ProtoBuf.IExtensible
  {
    public reset_gw_mid_c2s() {}
    
    private int _mid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"mid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int mid
    {
      get { return _mid; }
      set { _mid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"create_role_c2s")]
  public partial class create_role_c2s : global::ProtoBuf.IExtensible
  {
    public create_role_c2s() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _gender;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"gender", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int gender
    {
      get { return _gender; }
      set { _gender = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"create_role_s2c")]
  public partial class create_role_s2c : global::ProtoBuf.IExtensible
  {
    public create_role_s2c() {}
    
    private int _result_code;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result_code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int result_code
    {
      get { return _result_code; }
      set { _result_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_login_s2c")]
  public partial class role_login_s2c : global::ProtoBuf.IExtensible
  {
    public role_login_s2c() {}
    
    private int _result_code;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result_code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int result_code
    {
      get { return _result_code; }
      set { _result_code = value; }
    }
    private int _main_svr_id = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"main_svr_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int main_svr_id
    {
      get { return _main_svr_id; }
      set { _main_svr_id = value; }
    }
    private bool _exist_role = default(bool);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"exist_role", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool exist_role
    {
      get { return _exist_role; }
      set { _exist_role = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_info_s2c")]
  public partial class role_info_s2c : global::ProtoBuf.IExtensible
  {
    public role_info_s2c() {}
    
    private yy.proto.p_roleInfo _role_info = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"role_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public yy.proto.p_roleInfo role_info
    {
      get { return _role_info; }
      set { _role_info = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"p_roleInfo")]
  public partial class p_roleInfo : global::ProtoBuf.IExtensible
  {
    public p_roleInfo() {}
    
    private long _role_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"role_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long role_id
    {
      get { return _role_id; }
      set { _role_id = value; }
    }
    private string _name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _gender = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gender", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int gender
    {
      get { return _gender; }
      set { _gender = value; }
    }
    private int _exp = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private int _level = default(int);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int level
    {
      get { return _level; }
      set { _level = value; }
    }
    private int _vip = default(int);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"vip", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int vip
    {
      get { return _vip; }
      set { _vip = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_logout_c2s")]
  public partial class role_logout_c2s : global::ProtoBuf.IExtensible
  {
    public role_logout_c2s() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"role_logout_s2c")]
  public partial class role_logout_s2c : global::ProtoBuf.IExtensible
  {
    public role_logout_s2c() {}
    
    private int _code;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int code
    {
      get { return _code; }
      set { _code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}