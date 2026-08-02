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

        // J = Forward
        if (Input.GetKey(KeyCode.J))
            movement += Vector3.back;

        // L = Backward
        if (Input.GetKey(KeyCode.L))
            movement += Vector3.forward;

        // I = Left
        if (Input.GetKey(KeyCode.I))
            movement += Vector3.left;

        // K = Right
        if (Input.GetKey(KeyCode.K))
            movement += Vector3.right;

        movement = movement.normalized;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}