using UnityEditor;
using UnityEngine;

// ============================================================
// ★ Item과 ItemEditor가 연결되는 부분
//
// [CustomEditor(typeof(Item))]
//
// 의미:
// "Unity Inspector에서 Item을 선택하면
//  기본 Inspector 대신 이 ItemEditor를 사용해라."
// ============================================================
[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // ====================================================
        // ★ 현재 Inspector에서 선택한 Item을 가져옴
        //
        // target = 현재 선택된 Item ScriptableObject
        // ====================================================
        Item item = (Item)target;


        // ----------------------------------------------------
        // 여기에서 item.itemType을 확인해서
        // 어떤 데이터를 Inspector에 보여줄지 결정한다.
        // ----------------------------------------------------

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("typeData")
        );

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("id")
        );

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("itemType")
        );


        // ItemType에 따라 표시할 데이터 결정
        switch (item.itemType)
        {
            case ItemType.Consumable:

                // ConsumableItemData만 표시
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("consumableData"),
                    true
                );

                break;


            case ItemType.Equipment:

                // EquipmentItemData만 표시
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("equipmentData"),
                    true
                );

                break;


            case ItemType.Material:

                // MaterialItemData만 표시
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("materialData"),
                    true
                );

                break;


            case ItemType.Etc:

                // EtcItemData만 표시
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("etcData"),
                    true
                );

                break;


            case ItemType.Event:

                // EventItemData만 표시
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("eventData"),
                    true
                );

                break;
        }


        serializedObject.ApplyModifiedProperties();
    }
}