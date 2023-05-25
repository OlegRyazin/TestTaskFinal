using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Animator animator;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Player.isGameRun)
        {

            rb.velocity = new Vector3(speed, rb.velocity.y);

            

            if (Mathf.Abs(rb.velocity.x) > 0.1f)
            {
                animator.SetBool("IsRun", true);
            }
            else
            {
                animator.SetBool("IsRun", false);
            }
        }
    }

    public void Jump()
    {
        if (Player.isGameRun && Player.isPlayerGrounded)
        {
            Player.isPlayerGrounded = false;
            rb.AddForce(new Vector3(0f, jumpForce), ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
    }
}
