using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovitento : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;

    [SerializeField] private int velocidade = 5;

    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask chaoLayer;

    private bool estaNoChao;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int movendoHash = Animator.StringToHash("movendo");
    private int saltandoHash = Animator.StringToHash("saltando");


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Verifica se o jogador pressionou a tecla de espaço e se ele está no chão
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            // Aplica uma força vertical para o jogador pular
            rb.AddForce(Vector2.up * 600);
        }

        // Verifica se o jogador está no chão usando um círculo de colisão
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, 0.2f, chaoLayer);

        // Atualiza os parâmetros do Animator para controlar as animações
        animator.SetBool(movendoHash, horizontalInput != 0);
        animator.SetBool(saltandoHash, !estaNoChao);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        // Aplica a velocidade horizontal ao Rigidbody
        rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
    }
}
