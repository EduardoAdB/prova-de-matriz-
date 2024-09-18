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
            if (jogador1 = Input.GetKeyDown(KeyCode.A))
            {
                direcao = new Vector2(-1, 0);
            }
 
        
        
            else if (jogador1 = Input.GetKeyDown(KeyCode.D))
            {
                direcao = new Vector2(1, 0);
            }
        
        
            else if (jogador1 = Input.GetKeyDown(KeyCode.W))
            {
                direcao = new Vector2(0, 1);
            }
       
            else if (jogador1 = Input.GetKeyDown(KeyCode.S))
            {
                direcao = new Vector2(0, -1);
            }
        }
 
        if (jogador2)
        { 
            if (jogador2 = Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direcao = new Vector2(-1, 0);
            }
        
        
            else if (jogador2 = Input.GetKeyDown(KeyCode.RightArrow))
            {
                direcao = new Vector2(1, 0);
            }
        
            else if (jogador2 = Input.GetKeyDown(KeyCode.UpArrow))
            {
                direcao = new Vector2(0, 1);
            }  
        
            else if (jogador2 = Input.GetKeyDown(KeyCode.DownArrow))
            {
                direcao = new Vector2(0, -1);
            }
        }
        transform.Translate(direcao * velocidade * Time.deltaTime);
 
    }
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
           spriteRendererDobloco = collision.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRendererDobloco != null)
            {
                spriteRendererDobloco.color = cordoJogador;
            }
        }
    }
 
}