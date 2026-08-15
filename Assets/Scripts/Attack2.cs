using UnityEngine;

public class OpponentAttack : MonoBehaviour
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
        // Make sure both health references exist
        if (myHealth == null || enemyHealth == null)
            return;

        // U + O = Combo
        if (Input.GetKey(KeyCode.U) && Input.GetKeyDown(KeyCode.O))
        {
            Combo();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Punch();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Kick();
        }

        // N = Special (only when own HP <= 30)
        if (Input.GetKeyDown(KeyCode.N) &&
            myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        if (animator != null)
            animator.SetTrigger("Punch");

        if (InRange())
        {
            enemyHealth.TakeDamage(punchDamage);
            Debug.Log("P2 Punch → " + punchDamage + " damage");
        }
    }

    void Kick()
    {
        if (animator != null)
            animator.SetTrigger("Kick");

        if (InRange())
        {
            enemyHealth.TakeDamage(kickDamage);
            Debug.Log("P2 Kick → " + kickDamage + " damage");
        }
    }

    void Combo()
    {
        if (animator != null)
            animator.SetTrigger("Combo");

        if (InRange())
        {
            enemyHealth.TakeDamage(comboDamage);
            Debug.Log("P2 Combo → " + comboDamage + " damage");
        }
    }

    void SpecialMove()
    {
        // Special animation will be added later
        // animator.SetTrigger("Special");

        if (InRange())
        {
            enemyHealth.TakeDamage(specialDamage);
            Debug.Log("P2 SPECIAL → " + specialDamage + " damage");
        }
    }

    bool InRange()
    {
        if (enemyHealth == null)
            return false;

        float distance = Vector3.Distance(
            transform.position,
            enemyHealth.transform.position
        );

        return distance <= attackRange;
    }
}