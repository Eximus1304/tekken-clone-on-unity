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
            Debug.LogError("OpponentMovement: CharacterController not found on " + gameObject.name);

        if (animator == null)
            Debug.LogError("OpponentMovement: Animator not found on " + gameObject.name);
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

        // Movement
        if (controller != null)
        {
            controller.Move(movement * moveSpeed * Time.deltaTime);
        }

        // Animation
        if (animator != null)
        {
            float moveValue = movement.magnitude > 0f ? 1f : 0f;
            //Debug.Log("");
            if (HasFloatParameter("Move"))
            {
                animator.SetFloat("Move", moveValue);
            }
        }
    }

    bool HasFloatParameter(string parameterName)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName &&
                parameter.type == AnimatorControllerParameterType.Float)
            {
                return true;
            }
        }

        return false;
    }
}