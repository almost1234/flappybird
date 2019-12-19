
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DickBird : MonoBehaviour
{
    
    private Rigidbody2D rb2D;
    private float thrust = 300.0f;
    public int score = 0;
    public GameObject Pipes;
    public int pipeGenerated;
    public float timePassed;
    public bool pipeFormed;



    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        pipeGenerated = 0;
        pipeFormed = false;
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb2D.AddForce(transform.up * thrust);
            Debug.Log(Mathf.Round(timePassed % 2.0f));
        }
        
    }

    private void FixedUpdate()
    { 
       
        if (Mathf.Round(timePassed % 2.0f) == 1 & pipeFormed == false & pipeGenerated < 6)
        {
            
            Instantiate(Pipes, new Vector3(9.04f, Random.Range(4.0f,0.0f), 0), Quaternion.identity);
            pipeGenerated = pipeGenerated + 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D  collision)
    {
        Debug.Log("Touched");
        if(collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Floor"){
            Time.timeScale = 0;
        }
    }

    public int Something()
    {
        score = score + 1;
        return score; 
    }


}
