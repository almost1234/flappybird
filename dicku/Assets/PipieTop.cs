using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipieTop : MonoBehaviour
{
    private bool scoreGiven;
    private int gameScore;
    private DickBird idksomename;


    // Start is called before the first frame update
    
    private void Start()
    {
        idksomename = FindObjectOfType<DickBird>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        Debug.Log(transform.localPosition.x);
        if (transform.localPosition.x < 5.4f)
        {
            transform.SetPositionAndRotation(new Vector3(9.5f, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (transform.localPosition.x < 13.2f && scoreGiven == false)
        {
            gameScore = idksomename.Something();
            scoreGiven = true;
            Debug.Log(gameScore);
        }

    }
}
