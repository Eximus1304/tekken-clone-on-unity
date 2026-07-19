using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TekkenMovement : MonoBehaviour
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
        float move = 0f;

        if (Input.GetKey(KeyCode.D))
            move = 1f;

        if (Input.GetKey(KeyCode.A))
            move = -1f;

        controller.Move(transform.forward * move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}