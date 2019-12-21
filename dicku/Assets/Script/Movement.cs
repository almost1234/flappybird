using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
 
    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        if (transform.localPosition.x < -9.8f)
        {
            transform.SetPositionAndRotation(new Vector3(9.5f, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

        }
       
    }
}
