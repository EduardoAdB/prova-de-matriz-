using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    bool conquistado;
    SpriteRenderer spriteRenderer;
    int jogadorDono2;
    static public Bloco instance;
    private void Awake()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }
    public void AlterarConquista(bool jogador1, Color corDoJogador)
    {

        conquistado = true;

        GetComponent<Renderer>().material.color = corDoJogador;

        if (jogador1)
        {
            jogadorDono2 = 1;
        }
        else
        {
            jogadorDono2 = 2;
        }
        GameManager.instance.ConquistarTerritorio();
    }
    public bool PegarConquistado()
    {
        return conquistado;
    }
    public int PegarJogadorDono()
    {

        return jogadorDono2;
    }
    public void AtualizarCor(Color novacor)
    {
        spriteRenderer.color = novacor;
    }
}