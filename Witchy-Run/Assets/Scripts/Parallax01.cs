using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax01 : MonoBehaviour
{
    
    private Material material;
    private Vector2 offset;

    //SerializeField faz com que o "provate float velocidade seja ajustavel no Editor da Unity.
    [SerializeField][Range(0,1)] private float velocidade;

    //Awake e chamado no inicio para obter a referencia do material do componente MeshRenderer antes do Start().
    private void Awake() {
        // Obtem a referencia do Material do componente MeshRenderer do objeto
        material = GetComponent<MeshRenderer>().material; 
    }

    void Update()
    {
        // Calcula o deslocamento do offset com base no tempo e velocidade
        offset.Set(offset.x + Time.deltaTime * velocidade, 0);
        
        // Verifica se o offset atingiu ou ultrapassou o valor 1
        if (offset.x >= 1)
        {
            offset.x = 0;
        }
        
        // Aplica o offset ao material para criar o efeito de parallax
        material.mainTextureOffset = offset;
    }
}