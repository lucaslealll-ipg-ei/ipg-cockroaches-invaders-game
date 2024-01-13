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
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if(gameController == null )
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary"){
            return;
        }
        else if(other.tag == "Shot"){
            //instanciar explosão formiga/shot
            Instantiate(explosion,transform.position,transform.rotation);
            //Adicionar pontos
            gameController.AddScore(addScore);     
        }
        else if(other.tag == "Player")
        {
            //instanciar explosão do player
            Instantiate(explosion,other.transform.position,other.transform.rotation);

            gameController.GameOver();
        }     
          
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    
}
