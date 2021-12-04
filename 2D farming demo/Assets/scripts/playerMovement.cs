using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidbody2D;
    Animator animator;
    Vector3 playerInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerInput = new Vector3(inputX, inputY).normalized;

        if(playerInput != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            if (inputX != 0)
            {
                transform.localScale = new Vector3(inputX, 1, 1);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + playerInput*speed*Time.fixedDeltaTime);
    }
}
