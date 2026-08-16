using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Health myHealth;
    public Health enemyHealth;

    public float attackRange = 2f;

    public int punchDamage = 15;
    public int kickDamage = 10;
    public int comboDamage = 35;
    public int specialDamage = 60;

    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (myHealth == null || enemyHealth == null)
            return;

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

        // X = Special
        if (Input.GetKeyDown(KeyCode.X) &&
            myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        PlayAnimation("Punch");

        float distance = GetDistance();

        Debug.Log("P1 Punch | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(punchDamage);

            Debug.Log("P1 Punch HIT → -" +
                      punchDamage + " HP");
        }
        else
        {
            Debug.Log("P1 Punch MISSED — too far away.");
        }
    }

    void Kick()
    {
        PlayAnimation("Kick");

        float distance = GetDistance();

        Debug.Log("P1 Kick | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(kickDamage);

            Debug.Log("P1 Kick HIT → -" +
                      kickDamage + " HP");
        }
        else
        {
            Debug.Log("P1 Kick MISSED — too far away.");
        }
    }

    void Combo()
    {
        PlayAnimation("Combo");

        float distance = GetDistance();

        Debug.Log("P1 Combo | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(comboDamage);

            Debug.Log("P1 Combo HIT → -" +
                      comboDamage + " HP");
        }
        else
        {
            Debug.Log("P1 Combo MISSED — too far away.");
        }
    }

    void SpecialMove()
    {
        float distance = GetDistance();

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(specialDamage);

            Debug.Log("P1 SPECIAL HIT → -" +
                      specialDamage + " HP");
        }
    }

    float GetDistance()
    {
        if (enemyHealth == null)
            return 999f;

        return Vector3.Distance(
            transform.root.position,
            enemyHealth.transform.root.position
        );
    }

    void PlayAnimation(string animationName)
    {
        if (animator == null)
            return;

        foreach (AnimatorControllerParameter parameter
                 in animator.parameters)
        {
            if (parameter.name == animationName &&
                parameter.type == AnimatorControllerParameterType.Trigger)
            {
                animator.SetTrigger(animationName);
                return;
            }
        }
    }
}