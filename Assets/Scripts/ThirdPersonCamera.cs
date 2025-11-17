using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("따라다닐 대상")]
    [SerializeField] private Transform player; //목표대상

    [Header("카메라 설정")]
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -10);   // 뒤에서 위에서 보는 위치
    [SerializeField] private float smoothSpeed = 0.125f;                 // 따라가는 부드러움
    private void LateUpdate()
    {
        if (player == null) return;

        //목표 위치
        Vector3 desiredPosition = player.position + offset;

        //부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //플레이어 따라가
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}