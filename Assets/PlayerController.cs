using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float xmin, xmax, zmin, zmax;
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    private GameController gameController;

    private float nextFire;

    public float fireRate;

    public float rotation;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        //Limitar o movimento da nave
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xmin, xmax), 0, Mathf.Clamp(rb.position.z, 0, zmax));

        // rodar a nave de acordo com a velocidade
        rb.rotation = Quaternion.Euler(-(rb.velocity.x * tilt), rotation, 0);
    }

    void Update()
    {   
        //Se der gameOver, não pode deixar mais atirar
        if(!gameController.gameOver){
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
