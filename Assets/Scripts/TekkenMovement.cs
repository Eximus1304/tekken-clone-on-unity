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

        // Using else-if ensures only ONE input direction executes per frame
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

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}