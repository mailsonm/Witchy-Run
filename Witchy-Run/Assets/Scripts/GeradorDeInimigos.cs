using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    [SerializeField] private PesoInimigo[] inimigos;

    private int totalPesos;

    // Start is called before the first frame update
    void Start()
    {
        foreach (PesoInimigo i in inimigos)
        {
            totalPesos += i.peso;
        }

        StartCoroutine(GerarInimigos());
    }

    private IEnumerator GerarInimigos()
    {
        while (true)
        {
            int quantidadeInimigos = Random.Range(1, 4);

            for (int i = 0; i < quantidadeInimigos; i++)
            {
                Instantiate(GetInimigo(), new Vector3(Random.Range(12.5f, 7.5f), Random.Range(-3.5f, 4.5f), 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(4f);
        }
    }

    private GameObject GetInimigo()
    {
        int numeroSorteado = Random.Range(0, totalPesos) + 1;
        int pesoProcessado = 0;

        for (int i = 0; i < inimigos.Length; i++)
        {
            pesoProcessado += inimigos[i].peso;
            if (numeroSorteado <= pesoProcessado)
            {
                return inimigos[i].inimigo;
            }
        }

        return null;
    }
}
