using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    //Private variables
    public float speed = 6.0f;
    private float zDestroy = 25;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down objects only if the game is not over otherwise stop movement
        if(!GameManager.isGameOver)
        {
            //move down objects to the player's position 
            objectRb.AddForce(-Vector3.forward * (speed + GameManager.speedCount));
        }
        else
            objectRb.velocity = Vector3.zero;
    
        //destroy the objects out of bound
        if(transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
