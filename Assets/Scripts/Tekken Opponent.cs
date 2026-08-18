using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        if (controller == null)
            Debug.LogError("P2: CharacterController not found!");

        if (animator == null)
            Debug.LogError("P2: Animator not found!");
    }

    void Update()
    {
        if (controller == null)
            return;

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.I))
            movement += Vector3.forward;

        if (Input.GetKey(KeyCode.K))
            movement += Vector3.back;

        if (Input.GetKey(KeyCode.J))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.L))
            movement += Vector3.right;

        if (movement.magnitude > 1f)
            movement.Normalize();

        controller.Move(
            movement * moveSpeed * Time.deltaTime
        );

        UpdateAnimation(movement);
    }

    void UpdateAnimation(Vector3 movement)
    {
        if (animator == null)
            return;

        // NEVER overwrite an attack
        if (IsAttackAnimation())
            return;

        if (movement.magnitude > 0.01f)
        {
            animator.Play("fast run");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    bool IsAttackAnimation()
    {
        AnimatorStateInfo state =
            animator.GetCurrentAnimatorStateInfo(0);

        return state.IsName("Punch") ||
               state.IsName("kicking") ||
               state.IsName("combo") ||
               state.IsName("special");
    }
}