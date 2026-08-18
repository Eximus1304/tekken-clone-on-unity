using System.Collections;
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
    private bool isAttacking;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogError("P2: Animator not found!");
    }

    void Update()
    {
        if (myHealth == null || enemyHealth == null)
            return;

        if (isAttacking)
            return;

        // U + O = COMBO
        if (Input.GetKey(KeyCode.U) && Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(DoAttack("combo", comboDamage));
            return;
        }

        // U = PUNCH
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(DoAttack("Punch", punchDamage));
            return;
        }

        // O = KICK
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(DoAttack("kicking", kickDamage));
            return;
        }

        // N = SPECIAL
        if (Input.GetKeyDown(KeyCode.N) &&
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

        Debug.Log("P2 PLAYING: " + animationName);

        // DIRECTLY PLAY THE EXACT ANIMATOR STATE
        animator.Play(animationName, 0, 0f);

        yield return null;

        // Damage
        if (InRange())
        {
            enemyHealth.TakeDamage(damage);

            Debug.Log(
                "P2 HIT: " +
                animationName +
                " -> -" +
                damage
            );
        }
        else
        {
            Debug.Log("P2 ATTACK MISSED");
        }

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
            "P2 Distance = " +
            distance +
            " | Range = " +
            attackRange
        );

        return distance <= attackRange;
    }
}