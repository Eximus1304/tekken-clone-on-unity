using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        // W = Left
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.left;
        }

        // S = Right
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.right;
        }

        // D = Forward
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.forward;
        }

        // A = Backward
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.back;
        }

        // Prevent faster diagonal movement
        movement = movement.normalized;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}