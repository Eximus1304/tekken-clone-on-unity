using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.left;
            animator.SetFloat("Move", 1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = Vector3.right;
            animator.SetFloat("Move", -1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Vector3.forward;
            animator.SetFloat("Move", 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = Vector3.back;
            animator.SetFloat("Move", 0f);
        }
        else
        {
            animator.SetFloat("Move", 0f);
        }

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}