using System;

/// <summary>
/// 아이템이 적용하는 능력치 효과
/// </summary>
[Serializable]
public class StatEffectData
{
    /// <summary>
    /// 적용할 캐릭터 기본 능력치
    /// </summary>
    public StatList.BasicStatList targetStat;

    /// <summary>
    /// 기본 능력치에 적용할 수치
    /// </summary>
    public int effectValue;


    /// <summary>
    /// 적용할 장비 고유 능력치
    /// </summary>
    public EquipmentStatList.EquipmentStat equipmentStat;

    /// <summary>
    /// 장비 고유 능력치에 적용할 수치
    /// </summary>
    public int equipmentEffectValue;
}