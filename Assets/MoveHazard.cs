using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHazard : MonoBehaviour
{
    public Rigidbody rbHazard;
    public float hazardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbHazard.velocity = transform.forward * hazardSpeed;
    }

}
