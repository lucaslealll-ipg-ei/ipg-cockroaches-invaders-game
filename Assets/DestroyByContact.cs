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
        else{ //other == player
            Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
            //instanciar explosão do player
            //gameover
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
