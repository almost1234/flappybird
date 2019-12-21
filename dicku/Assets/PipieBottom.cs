using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipieBottom : MonoBehaviour
{
    private bool scoreGiven;
    private int gameScore;
    private DickBird playerScript;
    public Transform topPipe;
    public Transform bottomPipe;
    private float numberHolder;
    

    // Start is called before the first frame update

    private void Start()
    {
        playerScript = FindObjectOfType<DickBird>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        topPipe.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        bottomPipe.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        if (topPipe.localPosition.x < -17.5f)
        {
            numberHolder = Random.Range(2.0f, 6.0f);
            topPipe.SetPositionAndRotation(new Vector3(9.5f, numberHolder, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            bottomPipe.SetPositionAndRotation(new Vector3(9.5f, numberHolder - 8, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            scoreGiven = false;
        }

        if (topPipe.localPosition.x < -10.0f && scoreGiven == false)
        {
            gameScore = playerScript.ScoreGet();
            scoreGiven = true;
            Debug.Log(gameScore);
        }


    }
}
