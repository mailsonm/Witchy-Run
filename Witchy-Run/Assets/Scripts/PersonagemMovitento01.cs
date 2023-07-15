using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovitento01 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool estaNoChao;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int jumpCount;

    [SerializeField]private int maxJumpCount = 1; // Define o numero maximo de pulos permitidos
    [SerializeField] private float forcaPulo = 600f;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask chaoLayer;

    private int saltandoHash = Animator.StringToHash("IsJumping");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (estaNoChao)
        {
            jumpCount = 0; // Reseta o contador de pulos quando o jogador toca no chao
        }

        // Verifica se o jogador pressionou o clique do mouse e se ele ainda tem pulos disponiveis
        if (Input.GetMouseButtonDown(0) && jumpCount < maxJumpCount)
        {
            Jump();
            jumpCount++;
        }

        // Verifica se o jogador esta no chao usando um circulo de colisao
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, 0.2f, chaoLayer);

        // Atualiza os parametros do Animator para controlar as animacoes
        animator.SetBool(saltandoHash, !estaNoChao);
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * forcaPulo);
        GetComponent<AudioSource>().Play();
        animator.SetBool("IsJumping", true);
    }
}