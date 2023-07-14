using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoVerticalInimigo : MonoBehaviour
{
    [SerializeField] [Range(0, 4)] private float velocidade;

    private enum Direcao { SUBIR, DESCER }

    private Direcao direcaoAtual;

    // Start is called before the first frame update
    void Start()
    {
        int direcaoInicial = Random.Range(0, 2);

        if (direcaoInicial == 0)
        {
            direcaoAtual = Direcao.SUBIR;
        }
        else
        {
            direcaoAtual = Direcao.DESCER;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (direcaoAtual)
        {
            case Direcao.SUBIR:
                transform.position += new Vector3(0, velocidade * Time.deltaTime, 0);

                if (transform.position.y >= 6)
                {
                    direcaoAtual = Direcao.DESCER;
                }
                break;

            case Direcao.DESCER:
                transform.position -= new Vector3(0, velocidade * Time.deltaTime, 0);

                if (transform.position.y <= -6)
                {
                    direcaoAtual = Direcao.SUBIR;
                }
                break;
        }
    }
}