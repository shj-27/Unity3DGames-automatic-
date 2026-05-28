using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


[System.Serializable]
public class CharacterInventoryData
{
    [Header("인벤토리 제한 값")]

    [Header("가방 상태")]
    [SerializeField] private UpgradeTierSlot bagTier = UpgradeTierSlot.Tier1;

    [Header("자동 생성 상태")]
    [SerializeField] private UpgradeTierSlot autoCreateTier = UpgradeTierSlot.Tier1;

    // 최대 가방 크기 (보유 가능한 캐릭터 슬롯 수)
    public int MaxBagSize => GetMaxSlot(bagTier);

    // 최대 자동 생성 가능 캐릭터 수 (자동 수급/제작 제한)
    public int MaxAutoCreateCount => GetAutoCreateCount(autoCreateTier);

    public static int GetMaxSlot(UpgradeTierSlot tier)
    {
        return tier switch
        {
            UpgradeTierSlot.Tier1 => 5,
            UpgradeTierSlot.Tier2 => 10,
            UpgradeTierSlot.Tier3 => 20,
            UpgradeTierSlot.Tier4 => 35,
            UpgradeTierSlot.Tier5 => 50,
            _ => 5
        };
    }

    public static int GetAutoCreateCount(UpgradeTierSlot tier)
    {
        return tier switch
        {
            UpgradeTierSlot.Tier1 => 3,
            UpgradeTierSlot.Tier2 => 6,
            UpgradeTierSlot.Tier3 => 9,
            UpgradeTierSlot.Tier4 => 12,
            UpgradeTierSlot.Tier5 => 15,
            _ => 3
        };
    }
}
