using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Head Data")]
public class HeadData : ScriptableObject
{
    public GameObject headPrefab;

    public Sprite[] portraits;
}
