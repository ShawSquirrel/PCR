
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace GameConfig
{
public sealed partial class SAnim2Name : Luban.BeanBase
{
    public SAnim2Name(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        State = (EAnimState)_buf.ReadInt();
        Name = _buf.ReadString();
    }

    public static SAnim2Name DeserializeSAnim2Name(ByteBuf _buf)
    {
        return new SAnim2Name(_buf);
    }

    /// <summary>
    /// 这是id
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 状态类型
    /// </summary>
    public readonly EAnimState State;
    /// <summary>
    /// 状态名字
    /// </summary>
    public readonly string Name;
   
    public const int __ID__ = -347786407;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "state:" + State + ","
        + "name:" + Name + ","
        + "}";
    }
}

}
