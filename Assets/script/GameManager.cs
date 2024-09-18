using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    #endregion

    public GameObject jogador1;
    public GameObject jogador2;
    public GameObject bloco;

    public float distanciaCamera = 10.0f;

    int linhas = 10;
    int colunas = 10;
    float espacoLinhas = 1.1f;

    private int[,] matriz;
    private int territoriosConquistados;

    private void Awake()
    {
        instance = this;
        matriz = new int[linhas, colunas];
        CriarGrade();
    }
    void CriarGrade()
    {
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Instantiate(bloco, new Vector3(i * espacoLinhas, j * espacoLinhas), Quaternion.identity);//cria 100 blocos (só falta mudar a posição para poder ficar baita)
            }
        }
        Vector3 centroMatriz = new Vector3((linhas - 1) * espacoLinhas / 2, (colunas - 1) * espacoLinhas / 2, -distanciaCamera);
        Camera.main.transform.position = centroMatriz;

        Vector3 posicaoInicialJogador1 = new Vector3(0, 0, -1 * espacoLinhas); 
        Vector3 posicaoInicialJogador2 = new Vector3((linhas - 1) * espacoLinhas, 0, (colunas - 1) * espacoLinhas);

        Instantiate(jogador1, posicaoInicialJogador1, Quaternion.identity);
        Instantiate(jogador2, posicaoInicialJogador2, Quaternion.identity);
        

    }
    


}
