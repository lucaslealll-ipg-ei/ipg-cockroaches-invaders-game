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
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TextMeshProUGUI  scoreText;
    public TextMeshProUGUI  gameOverText;
    public TextMeshProUGUI  restartText;

    private bool gameOver;
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

    public void AddScore()
    {
        score += 10;
        WriteScore();
    }

    public void SubtractScore()
    {
        score -= 20;
        WriteScore();

        if (score < 0)
        {
            GameOver();
        }
    }

    void WriteScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // Escolhe aleatoriamente um hazard da lista
                GameObject hazardToSpawn = hazards[Random.Range(0, hazards.Count)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazardToSpawn, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
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
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
