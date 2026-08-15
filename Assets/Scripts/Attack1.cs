using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Health myHealth;
    public Health enemyHealth;

    public Animator animator;

    public float attackRange = 2f;

    public int punchDamage = 15;
    public int kickDamage = 10;
    public int comboDamage = 35;
    public int specialDamage = 60;

    void Update()
    {
        // Q + E = Combo
        if (Input.GetKey(KeyCode.Q) && Input.GetKeyDown(KeyCode.E))
        {
            Combo();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Punch();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Kick();
        }

        // X = Special (only below 30 HP)
        if (Input.GetKeyDown(KeyCode.X) &&
            myHealth != null &&
            myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        if (animator != null)
            animator.SetTrigger("Punch");

        if (enemyHealth != null &&
            Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(punchDamage);
        }
    }

    void Kick()
    {
        if (animator != null)
            animator.SetTrigger("Kick");

        if (enemyHealth != null &&
            Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(kickDamage);
        }
    }

    void Combo()
    {
        if (animator != null)
            animator.SetTrigger("Combo");

        if (enemyHealth != null &&
            Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(comboDamage);
        }
    }

    void SpecialMove()
    {
        // Special animation will be added later
        // animator.SetTrigger("Special");

        if (enemyHealth != null &&
            Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(specialDamage);
            Debug.Log("SPECIAL MOVE!");
        }
    }
}