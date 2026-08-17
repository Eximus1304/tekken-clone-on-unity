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

        Debug.Log("OPPONENT MOVEMENT STARTED: " + gameObject.name);

        if (controller == null)
            Debug.LogError("OpponentMovement: CharacterController NOT FOUND");

        if (animator == null)
            Debug.LogError("OpponentMovement: Animator NOT FOUND");
        else
            Debug.Log("OpponentMovement: Animator FOUND");
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.I))
        {
            movement = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            movement = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            movement = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            movement = Vector3.back;
        }

        if (controller != null)
        {
            controller.Move(
                movement * moveSpeed * Time.deltaTime
            );
        }

        if (animator != null)
        {
            float moveValue =
                movement.sqrMagnitude > 0.001f ? 1f : 0f;

            animator.SetFloat("Move", moveValue);
        }
    }
}