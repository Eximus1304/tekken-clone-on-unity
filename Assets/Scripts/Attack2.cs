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

        // N = Special (only below 30 HP)
        if (Input.GetKeyDown(KeyCode.N) && myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        //animator.SetTrigger("Punch");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(punchDamage);
        }
    }

    void Kick()
    {
        //animator.SetTrigger("Kick");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(kickDamage);
        }
    }

    void Combo()
    {
        //animator.SetTrigger("Combo");

        if (Vector3.Distance(transform.position, enemyHealth.transform.position) <= attackRange)
        {
            enemyHealth.TakeDamage(comboDamage);
        }
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