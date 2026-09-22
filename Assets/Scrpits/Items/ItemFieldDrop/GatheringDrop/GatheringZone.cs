using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 필드의 채집 구역에서 드랍되는 아이템을 정의
/// </summary>
public class GatheringZone : MonoBehaviour
{
    /// <summary>
    /// 이 구역에서 드랍되는 아이템 목록
    /// </summary>
    [SerializeField]
    private List<Item> dropItems;
}