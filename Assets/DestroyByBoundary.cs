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

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Qualquer coisa que saia da boundary, exceto Shot, retirar 10 pontos
        if (other.tag != "Shot"){
            gameController.AddScore(subtractScore);
        }
        // Destroy the shot object.
        Destroy(other.gameObject);
    }
}
