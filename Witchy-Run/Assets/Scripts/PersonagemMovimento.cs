using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimento : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private int jumpCount;
    
    [SerializeField] private int maxJumpCount = 0; // Define o número máximo de pulos permitidos
    [SerializeField] private float forcaPulo = 550f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0; // Reinicia o contador de pulos se estiver no chão
            animator.SetBool("IsJumping", false);

            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && jumpCount < maxJumpCount)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * forcaPulo);
        animator.SetBool("IsJumping", true);
        jumpCount++;
    }
}