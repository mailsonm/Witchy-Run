using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoHorizontalInimigo : MonoBehaviour
{
    [SerializeField][Range(0,5)] private float velocidade;

    void Update()
    {
        if(transform.position.x >= -10)
        {
            transform.position -= new Vector3(Time.deltaTime * velocidade, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
