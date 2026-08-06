using UnityEngine;

public class FaceOpponent : MonoBehaviour
{
    public Transform opponent;

    void Update()
    {
        if (opponent == null) return;

        // Calculate direction vector ignoring height differences
        Vector3 targetDirection = opponent.position - transform.position;
        targetDirection.y = 0f;

        // Rotate towards opponent if they aren't directly on top of each other
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}