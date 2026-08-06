using UnityEngine;

public class FightingCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    [Header("Camera Positioning")]
    public float baseDistance = 5f;
    public float heightOffset = 2.25f;
    public float pitchAngle = 10f;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        // Find center between fighters
        Vector3 midpoint = (player1.position + player2.position) * 0.5f;

        // Calculate horizontal vector between players
        Vector3 playerDir = player2.position - player1.position;
        playerDir.y = 0f;

        if (playerDir.sqrMagnitude < 0.0001f) return;

        // Calculate exact Y rotation perpendicular to the line between players
        float targetYAngle = Mathf.Atan2(playerDir.x, playerDir.z) * Mathf.Rad2Deg + 90f;

        // Form rotation target with fixed downward pitch (X) and dynamic facing (Y)
        Quaternion targetRotation = Quaternion.Euler(pitchAngle, targetYAngle, 0f);

        // Calculate offset position behind the midpoint relative to camera rotation
        Vector3 offset = targetRotation * new Vector3(0, 0, -baseDistance);
        Vector3 targetPosition = midpoint + offset;
        targetPosition.y = midpoint.y + heightOffset;

        // Instantly snap in Editor frame, lerp during Play
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}