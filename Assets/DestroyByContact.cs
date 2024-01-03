using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary"){
            return;
        }
        else if(other.tag == "Shot"){
            //instanciar explosão shot/asteroid
            Instantiate(explosion,transform.position,transform.rotation);
            //aumentar score
            
        }
        else if(other.tag == "Player"){ //other == player
            //instanciar explosão do player
            Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
            //gameover
        }
        else {
            //instanciar explosão do player
            Instantiate(explosion,other.transform.position,other.transform.rotation);
            //gameover
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
