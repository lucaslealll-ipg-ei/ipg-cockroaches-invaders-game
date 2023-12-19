using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody spaceship;
    public AudioSource shootSound;
    public float speed;
    public float xmin,xmax, zmin,zmax;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start(){
        spaceship = GetComponent<Rigidbody>();
        shootSound = GetComponent<AudioSource>();
    }

    void Update (){
        if (Input.GetButton("Fire1") && Time.time> nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //GetComponent<AudioSource>().Play;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        spaceship.velocity = movement * speed;
        spaceship.position = new Vector3(Mathf.Clamp(spaceship.position.x, xmin, xmax), 0, Mathf.Clamp(spaceship.position.z, zmin, zmax));
        spaceship.rotation = Quaternion.Euler(0.0f, 0.0f, (spaceship.velocity.x * -tilt));
    }
}
