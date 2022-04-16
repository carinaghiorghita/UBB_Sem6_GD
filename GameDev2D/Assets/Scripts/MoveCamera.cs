using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float screenLength = 42f;
    public float movingSpeed = 1.5f;
    private bool isMoving = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            transform.position += Vector3.right * Time.deltaTime * movingSpeed;
            if (transform.position.x >= screenLength)
                isMoving = false;
        }
    }
}
