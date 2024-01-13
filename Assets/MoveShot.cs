using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

}
