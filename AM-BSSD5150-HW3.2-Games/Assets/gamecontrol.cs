using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Source of Images, all images are free.


//Clown, https://www.pngfuel.com/free-png/npuim 
//Frankstien, https://dlpng.com/png/458917 
//Dracola, https://www.pngfuel.com/free-png/afima 
//saw, https://svgsilh.com/image/2022676.html 
//Mr.Bean, https://www.seekpng.com/ipng/u2q8i1y3y3a9e6a9_mr-bean-cake-bean-cakes-cute-characters-novelty/
//Man with mask, https://dlpng.com/png/6820244 
//Tresure, https://www.pngfuel.com/free-png/wmpnz

public class gamecontrol : MonoBehaviour
{
    
    [SerializeField]
    private GameObject spawnPoint ;
    private int NoOfEnemeis = 0;
    private float maxSpeed = 10f;
    private float move;
    private float move2;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        move = Input.GetAxis("Horizontal");
        move2 = Input.GetAxis("Vertical");
        rb.mass = 15;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move * maxSpeed, move2 * maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        string collideTag = collision.gameObject.tag;
        if (collideTag == "enemy") // if Mr Bean hits enemies, they will be destroyed and number of killed enemies increased by 1.
        {
            NoOfEnemeis = NoOfEnemeis + 1;
            Destroy(collision.gameObject);  
        }

            if (collideTag == "hazard")// if Mr Bean hits any saw, he will return to start point which has the same cordinate of
                                       //starting position of Mr.Bean
            {
              this.gameObject.transform.SetPositionAndRotation( spawnPoint.transform.position, Quaternion.identity);

            }
    }
           //if all enemines were killed and goal was touched, you will win the game
           //Note: goal is a gameobject with same size and poistion of tresure png 
       
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (NoOfEnemeis == 4) ;
        {
            Debug.Log(" you win");
        }

    }


    
}
