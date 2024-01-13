using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public int addScore = 10;

    void Start()
    {
        // Define o objeto do jogo com a tag "GameController"
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        // Verifica se o objeto do GameController foi encontrado
        // Obtém o componente GameController do objeto do GameController encontrado
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();

        // Verifica se o componente GameController foi encontrado
        // Exibe uma mensagem de log indicando que o script 'GameController' não pode ser encontrado
        if (gameController == null)
            Debug.Log("Cannot find 'GameController' script");
    }


    void OnTriggerEnter(Collider other)
    {
        // Verifica se a tag do colisor é "Boundary" ou "Hazard"
        // Caso seja, sai da função
        if (other.tag == "Boundary" || other.tag == "Hazard")
        {
            return;
        } 
        // Verifica se a tag do colisor é "Shot"
        else if (other.tag == "Shot")
        {
            // Instancia uma explosão para o "Shot" na posição e rotação do objeto atual
            Instantiate(explosion, transform.position, transform.rotation);
            
            // Adiciona pontos usando o método AddScore do GameController com o valor de pontuação especificado (addScore)
            gameController.AddScore(addScore);     
        }
        // Verifica se a tag do colisor é "Player"
        else if (other.tag == "Player")
        {
            // Instancia uma explosão para o "Player" na posição e rotação do jogador
            Instantiate(explosion, other.transform.position, other.transform.rotation);

            // Chama o método GameOver do GameController
            gameController.GameOver();
        }     
        // Destroi o outro objeto (o colisor)
        Destroy(other.gameObject);
        // Destroi o objeto atual (esse script provavelmente está anexado a um objeto do jogo)
        Destroy(gameObject);
    }
}
