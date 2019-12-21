
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DickBird : MonoBehaviour
{
    private float x_Cord;
    private Rigidbody2D rb2D;
    private float thrust = 300.0f;
    public int score = 0;
    public GameObject Pipes;
    public int pipeGenerated;
    public float timePassed;
    public bool pipeFormed;
    public Text scorePicture;
    public Text endPicture;
    private bool gameStart;
    public bool pauseState;
    public bool endState;
    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject finishUI;


    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        pipeGenerated = 0;
        pipeFormed = false;
        gameStart = false;
        scorePicture.text = "";
        Time.timeScale = 0;
        pauseState = false;
        endState = false;
        finishUI.SetActive(false);
        pauseUI.SetActive(false);
    }


    void Update()
    { 
        if (Input.GetKeyDown("space"))
        {
            if (gameStart == false)
            {
                startUI.SetActive(false);
                gameStart = true;
                Time.timeScale = 1;
                rb2D.AddForce(transform.up * (thrust / 10.0f));
                
            }
            if (gameStart == true)
            {
                rb2D.AddForce(transform.up * thrust);
            }
        }
        if (Input.GetKeyDown("escape") && gameStart == true && endState == false)
        {
            PauseChanger();
        }

        else if (Input.GetKeyDown("r") && (pauseState == true || endState == true))
        {
            pauseState = false;
            pipeGenerated = 0;
            gameStart = false;
            pipeFormed = false;
            score = 0;
            scorePicture.text = "";
            pauseUI.SetActive(false);
            finishUI.SetActive(false);
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            var multiplePipes = GameObject.FindGameObjectsWithTag("Pipe");
            foreach (var pipes in multiplePipes)
            {
                Destroy(pipes);
            }
            startUI.SetActive(true);
        }
            
        
    }

    private void FixedUpdate()
    { 
        if ((Mathf.Round(Time.timeSinceLevelLoad) % 3) == 2 && pipeFormed == true)
        {
            pipeFormed = false;
        }
        else if ( (Mathf.Round(Time.timeSinceLevelLoad) % 3) == 0 && pipeGenerated < 6 && pipeFormed == false)
        {
            pipeFormed = true;
            Instantiate(Pipes, new Vector3(9.04f, Random.Range(4.0f,0.0f), 0), Quaternion.identity);
            pipeGenerated = pipeGenerated + 1;
        }
    }

    public void WinFunction()
    {
        endState = true;
        Time.timeScale = 0;
        finishUI.SetActive(true);
        
    }

    private void OnCollisionEnter2D(Collision2D  collision)
    {
        Debug.Log("Touched");
        if(collision.gameObject.tag == "Pipe")
        {
            WinFunction();
            endPicture.text = "You knocked the wood too hard! Score : " + score.ToString();
        }

        else if(collision.gameObject.tag == "Floor")
        {
            WinFunction();
            endPicture.text = "You gone limp! Score : " + score.ToString();
        }
    }

    public void PauseChanger()
    {
        if(pauseState == false)
        {
            pauseState = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        else if(pauseState == true)
        {
            pauseState = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public int ScoreGet()
    {
        score = score + 1;
        scorePicture.text = score.ToString();
        return score; 
    }

}
