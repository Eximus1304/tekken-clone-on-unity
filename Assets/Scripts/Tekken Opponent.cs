using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // Forward / Backward
        if (Input.GetKey(KeyCode.J))
            move += transform.forward;

        if (Input.GetKey(KeyCode.L))
            move -= transform.forward;

        // Side Step
        if (Input.GetKey(KeyCode.I))
            move += transform.right;      // Away from camera

        if (Input.GetKey(KeyCode.K))
            move -= transform.right;      // Towards camera

        move.Normalize();

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.U))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}