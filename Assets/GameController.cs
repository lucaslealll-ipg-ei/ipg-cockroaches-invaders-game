using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<GameObject> hazards; // Lista de hazards
    public Vector3 spawnValues;
    public float spwValueX, lastSpwValueX;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TextMeshProUGUI  scoreText;
    public TextMeshProUGUI  gameOverText;
    public TextMeshProUGUI  restartText;

    public bool gameOver;
    private int score;
    private bool restart;


    void Start()
    {
        gameOver = false;
        restart = false;

        score = 0;
        WriteScore();
        gameOverText.text = "";
        restartText.text = "";

        StartCoroutine(SpawnWaves());
    }

    public void AddScore(int x)
    {
        //Se o game não acabou alterar o score
        if(!gameOver)
        {
            score += x;
            WriteScore();

            if (score < 0)
            {
                score=0;
                WriteScore();
                GameOver();
            }
        }

    }

    void WriteScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        
        // Inicializa com um valor grande para garantir a primeira execução
        float lastSpawnX = Random.Range(-spawnValues.x, spawnValues.x);

        // Loop para garantir constância em gerar hazards
        while (true)
        {
            // Loop de controle de geração de onda de hazards
            for (int i = 0; i < hazardCount; i++)
            {               
                // Gera uma posição X aleatória para o próximo hazard
                float spwValueX = Random.Range(-spawnValues.x, spawnValues.x);

                /* 
                    Garante que o novo hazard não apareça muito próximo do anterior
                    - Mathf.Abs(spwValueX - lastSpawnX): calculo do módulo do valor absoluto da diferença entre spwValueX e lastSpawnX
                    - < 2.0f: checa se a diferença é menor que 2.0 para gerar o novo hazard em uma posição diferente
                */
                while (Mathf.Abs(spwValueX - lastSpawnX) < 2.0f)
                    spwValueX = Random.Range(-spawnValues.x, spawnValues.x);

                // Atualiza a posição do último spawn para a nova posição gerada
                lastSpawnX = spwValueX;

                // Escolhe aleatoriamente um hazard da lista
                GameObject hazardToSpawn = hazards[Random.Range(0, hazards.Count)];
                
                // Determina a posição e rotação do hazard a ser instanciado
                Vector3 spawnPosition = new Vector3(spwValueX, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                // Instancia o hazard na posição e rotação determinadas
                Instantiate(hazardToSpawn, spawnPosition, spawnRotation);

                // Aguarda um tempo antes de instanciar o próximo hazard
                yield return new WaitForSeconds(spawnWait);
            }

            // Aguarda um tempo antes de iniciar a próxima onda de hazards
            yield return new WaitForSeconds(waveWait);

            // Verifica se o jogo acabou
            if(gameOver)
            {
                // Se o jogo acabou, sinaliza para reiniciar e exibe mensagem na tela
                restart = true;
                restartText.text = "Press <R> to Restart";
                break;
            }
        }
    }



    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";        
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
}
