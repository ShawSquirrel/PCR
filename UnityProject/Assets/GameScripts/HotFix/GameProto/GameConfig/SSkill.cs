
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
public sealed partial class SSkill : Luban.BeanBase
{
    public SSkill(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Type = (TSkillType)_buf.ReadInt();
        Atk = _buf.ReadFloat();
        Cd = _buf.ReadFloat();
        Area = _buf.ReadFloat();
        Title = _buf.ReadString();
        Describe = _buf.ReadString();
    }

    public static SSkill DeserializeSSkill(ByteBuf _buf)
    {
        return new SSkill(_buf);
    }

    /// <summary>
    /// 这是id
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 技能类型
    /// </summary>
    public readonly TSkillType Type;
    /// <summary>
    /// 攻击
    /// </summary>
    public readonly float Atk;
    /// <summary>
    /// 冷却
    /// </summary>
    public readonly float Cd;
    /// <summary>
    /// 范围
    /// </summary>
    public readonly float Area;
    /// <summary>
    /// 标题
    /// </summary>
    public readonly string Title;
    /// <summary>
    /// 描述
    /// </summary>
    public readonly string Describe;
   
    public const int __ID__ = -1838803522;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "type:" + Type + ","
        + "atk:" + Atk + ","
        + "cd:" + Cd + ","
        + "area:" + Area + ","
        + "title:" + Title + ","
        + "describe:" + Describe + ","
        + "}";
    }
}

}