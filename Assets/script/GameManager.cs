using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    #endregion

    public GameObject jogador1;
    public GameObject jogador2;
    public GameObject bloco;

    public float distanciaCamera = 10.0f;

    int blocosVerdes = 0;
    int blocosVermelhos = 0;

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
        Vector2 posicaoJogadorVerde = new Vector2(3.9f, 5.03f);//mudar posi��o do spawn
        Vector2 posicaoJogadorVermelho = new Vector2(6.07f, 5.03f);  //mudar spawn

        Instantiate(jogador1, posicaoJogadorVerde, Quaternion.identity);
        Instantiate(jogador2, posicaoJogadorVermelho, Quaternion.identity);
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Instantiate(bloco, new Vector3(i * espacoLinhas, j * espacoLinhas), Quaternion.identity);//cria 100 blocos (s� falta mudar a posi��o para poder ficar baita)
            }
        }
        Vector3 centroMatriz = new Vector3((linhas - 1) * espacoLinhas / 2, (colunas - 1) * espacoLinhas / 2, -distanciaCamera);
        Camera.main.transform.position = centroMatriz;
        Camera.main.orthographicSize = Mathf.Max(linhas, colunas) * espacoLinhas / 2;

       

        
    }
    int pertenceAoJd1;
    int pertenceAoJd2;

    public void ConquistarTerritorio()
    {

        territoriosConquistados++;
        if (territoriosConquistados == matriz.Length)
        {  
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (matriz[i, j] == pertenceAoJd1)
                    {
                        blocosVerdes++;
                    }
                    else if (matriz[i,j] == pertenceAoJd2)
                    {
                        blocosVermelhos++;
                    }
                }
            }
            FimDeJogo(blocosVerdes,blocosVermelhos);
        }
    }
    public void FimDeJogo(int blocosVerdes, int blocosVermelhos)
    {
        string vencedor;
        if (blocosVerdes > blocosVermelhos)
        {
            vencedor = "Jogador 1 � o vencedor! ";// + " dominou " + blocosVerdes + " territorios";
        }
        else if (blocosVerdes < blocosVermelhos)
        {
            vencedor = "Jogador 2 � o vencedor! ";
        }
        else
        {
            vencedor = "O jogo terminou em impate";
        }

        Debug.Log(vencedor);
    }
    


}
