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
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Instantiate(bloco, new Vector3(i * espacoLinhas, j * espacoLinhas), Quaternion.identity);//cria 100 blocos (só falta mudar a posição para poder ficar baita)
            }
        }
        Vector3 centroMatriz = new Vector3((linhas - 1) * espacoLinhas / 2, (colunas - 1) * espacoLinhas / 2, -distanciaCamera);
        Camera.main.transform.position = centroMatriz;
        Camera.main.orthographicSize = Mathf.Max(linhas, colunas) * espacoLinhas / 2;

        Vector3 posicaoJogador1 = new Vector3(0, 0, 0);//mudar posição do spawn
        Vector3 posicaoJogador2 = new Vector3((linhas - 1) * espacoLinhas, 0, (colunas - 1) * espacoLinhas);  //mudar spawn

        Instantiate(jogador1, posicaoJogador1, Quaternion.identity);
        Instantiate(jogador2, posicaoJogador2, Quaternion.identity);
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
            vencedor = "Jogador 1 é o vencedor! ";// + " dominou " + blocosVerdes + " territorios";
        }
        else if (blocosVerdes < blocosVermelhos)
        {
            vencedor = "Jogador 2 é o vencedor! ";
        }
        else
        {
            vencedor = "O jogo terminou em impate";
        }

        Debug.Log(vencedor);
    }
    


}
