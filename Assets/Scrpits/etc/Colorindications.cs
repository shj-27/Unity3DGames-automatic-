using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorindications : MonoBehaviour
{
    public enum ShapeType
    {
        Sphere,
        Cube,
        WireSphere,
        WireCube
    }

    [Header("표시 설정")]
    [SerializeField] private Color gizmoColor = Color.green;

    [SerializeField] private ShapeType shapeType = ShapeType.Sphere;

    [SerializeField] private float size = 1f;

    [SerializeField] private Vector3 boxSize = Vector3.one;

    private void OnDrawGizmosSelected()
    {
        // [1] 색 설정
        Gizmos.color = gizmoColor;

        // [2] 위치
        Vector3 pos = transform.position;

        // [3] 모양 선택
        switch (shapeType)
        {
            case ShapeType.Sphere:
                Gizmos.DrawSphere(pos, size);
                break;

            case ShapeType.WireSphere:
                Gizmos.DrawWireSphere(pos, size);
                break;

            case ShapeType.Cube:
                Gizmos.DrawCube(pos, boxSize * size);
                break;

            case ShapeType.WireCube:
                Gizmos.DrawWireCube(pos, boxSize * size);
                break;
        }
    }
}
