using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public Rigidbody rb;
    public float tumble = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
