using UnityEngine;

public class Damage : MonoBehaviour
{
    [Header("Health")]
    public Health myHealth;
    public Health enemyHealth;

    [Header("Damage Values")]
    public int punchDamage = 15;
    public int kickDamage = 10;
    public int comboDamage = 35;
    public int specialDamage = 60;

    [Header("Attack Range")]
    public float attackRange = 2f;

    [Header("Player")]
    public bool isPlayer1 = true;

    void Start()
    {
        if (myHealth == null)
        {
            myHealth = GetComponent<Health>();

            if (myHealth == null)
                myHealth = GetComponentInChildren<Health>();
        }
    }

    void Update()
    {
        if (enemyHealth == null)
            return;

        // =========================
        // PLAYER 1
        // Q = Punch
        // E = Kick
        // Q + E = Combo
        // X = Special
        // =========================

        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.Q) &&
                Input.GetKeyDown(KeyCode.E))
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

            if (Input.GetKeyDown(KeyCode.X) &&
                myHealth != null &&
                myHealth.currentHealth <= 30)
            {
                Special();
            }
        }

        // =========================
        // PLAYER 2
        // U = Punch
        // O = Kick
        // U + O = Combo
        // N = Special
        // =========================

        else
        {
            if (Input.GetKey(KeyCode.U) &&
                Input.GetKeyDown(KeyCode.O))
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

            if (Input.GetKeyDown(KeyCode.N) &&
                myHealth != null &&
                myHealth.currentHealth <= 30)
            {
                Special();
            }
        }
    }

    void Punch()
    {
        if (InRange())
        {
            enemyHealth.TakeDamage(punchDamage);

            Debug.Log(
                gameObject.name +
                " used PUNCH → -" +
                punchDamage +
                " HP"
            );
        }
    }

    void Kick()
    {
        if (InRange())
        {
            enemyHealth.TakeDamage(kickDamage);

            Debug.Log(
                gameObject.name +
                " used KICK → -" +
                kickDamage +
                " HP"
            );
        }
    }

    void Combo()
    {
        if (InRange())
        {
            enemyHealth.TakeDamage(comboDamage);

            Debug.Log(
                gameObject.name +
                " used COMBO → -" +
                comboDamage +
                " HP"
            );
        }
    }

    void Special()
    {
        if (InRange())
        {
            enemyHealth.TakeDamage(specialDamage);

            Debug.Log(
                gameObject.name +
                " used SPECIAL → -" +
                specialDamage +
                " HP"
            );
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