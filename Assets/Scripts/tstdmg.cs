using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 5;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Health enemy = hit.gameObject.GetComponent<Health>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Hit " + enemy.name);
        }
    }
}