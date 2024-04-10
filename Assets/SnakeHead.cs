using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        //headSnake = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    
    void Update()
    {


       if (Input.GetKeyDown(KeyCode.W))
           transform.rotation = Quaternion.Euler (0, 0, -90);
        if (Input.GetKeyDown(KeyCode.S))
            transform.rotation = Quaternion.Euler (0, 0, 90);
        if (Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler (0, 0, 0);
            if (Input.GetKeyDown(KeyCode.D)) 
                transform.rotation = Quaternion.Euler (0, 0, 180);
    }
}
