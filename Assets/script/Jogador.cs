using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;
 
public class Jogador : MonoBehaviour
{
 
    const int velocidade = 3;
 
    [SerializeField] bool jogador1;
    [SerializeField] bool jogador2;
    [SerializeField] Color cordoJogador;
    SpriteRenderer spriteRendererDobloco;
    private Vector2 direcao;
 
    private void Update()
    {
        if (jogador1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direcao.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direcao.x = 1;
            }
            else
            {
                direcao.x = 0;
            }


            if (Input.GetKey(KeyCode.W))
            {
                direcao.y = 1;
            }

            else if (Input.GetKey(KeyCode.S))
            {
                direcao.y = -1;
            }
            else
            {
                direcao.y = 0;
            }
        }
 
        if (jogador2)
        { 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direcao.x = -1;
            }


            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direcao.x = 1;
            }
            else
            {
                direcao.x = 0;

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                direcao.y = 1;
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direcao.y = -1;
            }
            else
            {
                direcao.y = 0;

            }
        }
        transform.Translate(direcao * velocidade * Time.deltaTime);
 
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
           Bloco spriteRendererDobloco = collision.gameObject.GetComponent<Bloco>();
            if (!spriteRendererDobloco.PegarConquistado())
            {
                spriteRendererDobloco.AlterarConquista(jogador1, cordoJogador);
            }
        }
    }
 
}