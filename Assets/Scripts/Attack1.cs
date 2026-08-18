using System.Collections;
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
    private bool isAttacking;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogError("P1: Animator not found!");
    }

    void Update()
    {
        if (myHealth == null || enemyHealth == null)
            return;

        if (isAttacking)
            return;

        // Q + E = COMBO
        if (Input.GetKey(KeyCode.Q) && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DoAttack("combo", comboDamage));
            return;
        }

        // Q = PUNCH
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DoAttack("Punch", punchDamage));
            return;
        }

        // E = KICK
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DoAttack("kicking", kickDamage));
            return;
        }

        // X = SPECIAL
        if (Input.GetKeyDown(KeyCode.X) &&
            myHealth.currentHealth <= 30)
        {
            StartCoroutine(DoAttack("special", specialDamage));
        }
    }

    IEnumerator DoAttack(string animationName, int damage)
    {
        if (animator == null)
            yield break;

        isAttacking = true;

        Debug.Log("P1 PLAYING: " + animationName);

        // DIRECTLY PLAY THE EXACT ANIMATOR STATE
        animator.Play(animationName, 0, 0f);

        // Wait one frame so Animator enters the state
        yield return null;

        // Damage
        if (InRange())
        {
            enemyHealth.TakeDamage(damage);

            Debug.Log(
                "P1 HIT: " +
                animationName +
                " -> -" +
                damage
            );
        }
        else
        {
            Debug.Log("P1 ATTACK MISSED");
        }

        // Wait for current animation
        AnimatorStateInfo state =
            animator.GetCurrentAnimatorStateInfo(0);

        float duration = state.length;

        if (duration < 0.1f)
            duration = 0.5f;

        yield return new WaitForSeconds(duration);

        // Return to Idle
        animator.Play("Idle", 0, 0f);

        isAttacking = false;
    }

    bool InRange()
    {
        if (enemyHealth == null)
            return false;

        float distance = Vector3.Distance(
            transform.position,
            enemyHealth.transform.position
        );

        Debug.Log(
            "P1 Distance = " +
            distance +
            " | Range = " +
            attackRange
        );

        return distance <= attackRange;
    }
}