using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private GameController gameController;

    public int subtractScore = -10;

    void Start()
    {
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

    void OnTriggerExit(Collider other)
    {
        //Qualquer coisa que saia da boundary, exceto Shot, retirar 10 pontos
        if (other.tag != "Shot")
            gameController.AddScore(subtractScore);

        // Destroy the shot object.
        Destroy(other.gameObject);
    }
}
