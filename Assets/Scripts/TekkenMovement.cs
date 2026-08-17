using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Debug.Log("PLAYER MOVEMENT STARTED: " + gameObject.name);

        if (controller == null)
            Debug.LogError("PlayerMovement: CharacterController NOT FOUND");

        if (animator == null)
            Debug.LogError("PlayerMovement: Animator NOT FOUND");
        else
            Debug.Log("PlayerMovement: Animator FOUND");
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.A))
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