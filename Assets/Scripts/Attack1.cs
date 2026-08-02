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
        if (Input.GetKeyDown(KeyCode.X) && myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        //animator.SetTrigger("Punch");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
            enemyHealth.TakeDamage(punchDamage);
    }

    void Kick()
    {
        //animator.SetTrigger("Kick");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
            enemyHealth.TakeDamage(kickDamage);
    }

    void Combo()
    {
        //animator.SetTrigger("Combo");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
            enemyHealth.TakeDamage(comboDamage);
    }

    void SpecialMove()
    {
        //animator.SetTrigger("Special");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(specialDamage);
            Debug.Log("SPECIAL MOVE!");
        }
    }
}