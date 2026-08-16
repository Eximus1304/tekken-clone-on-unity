using UnityEngine;

public class OpponentAttack : MonoBehaviour
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

        // N = Special
        if (Input.GetKeyDown(KeyCode.N) &&
            myHealth.currentHealth <= 30)
        {
            SpecialMove();
        }
    }

    void Punch()
    {
        PlayAnimation("Punch");

        float distance = GetDistance();

        Debug.Log("P2 Punch | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(punchDamage);

            Debug.Log("P2 Punch HIT → -" +
                      punchDamage + " HP");
        }
        else
        {
            Debug.Log("P2 Punch MISSED — too far away.");
        }
    }

    void Kick()
    {
        PlayAnimation("Kick");

        float distance = GetDistance();

        Debug.Log("P2 Kick | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(kickDamage);

            Debug.Log("P2 Kick HIT → -" +
                      kickDamage + " HP");
        }
        else
        {
            Debug.Log("P2 Kick MISSED — too far away.");
        }
    }

    void Combo()
    {
        PlayAnimation("Combo");

        float distance = GetDistance();

        Debug.Log("P2 Combo | Distance = " + distance +
                  " | Attack Range = " + attackRange);

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(comboDamage);

            Debug.Log("P2 Combo HIT → -" +
                      comboDamage + " HP");
        }
        else
        {
            Debug.Log("P2 Combo MISSED — too far away.");
        }
    }

    void SpecialMove()
    {
        float distance = GetDistance();

        if (distance <= attackRange)
        {
            enemyHealth.TakeDamage(specialDamage);

            Debug.Log("P2 SPECIAL HIT → -" +
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