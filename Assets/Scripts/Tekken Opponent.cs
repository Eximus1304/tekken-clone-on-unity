using UnityEngine;

public class OpponentMovement : MonoBehaviour
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

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}