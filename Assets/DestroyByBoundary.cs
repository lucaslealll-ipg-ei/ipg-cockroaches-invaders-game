using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private GameController gameController;

    void OnTriggerExit(Collider other)
    {        
        // gameController.SubtractScore();
        Destroy(other.gameObject);
        //Debug.Log(other.name);
    }

}
