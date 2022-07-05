using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private variables
    private float horizontalInput;
    private float xRange = 10;
    private float speed = 10;
    //private bool hasPowerUp;
    public GameObject gameManager;
    public GameObject powerupIndicator;

    public AudioClip collectSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not over then player can move and play the game
        if(!GameManager.isGameOver)
        {
            ConstrainPlayerPosition();
            //speed boost when the player collected a nitro boost and press the spacebar key
            if(Input.GetKeyDown(KeyCode.Space) )
            {
                //to do
                Debug.Log("spacebar pressed");
            }
            MovePlayer();
        }
        else
            Destroy(gameObject);

    }

    //player can move to left or to right by pressing the left or right arrows
    void MovePlayer()
    {
        //get the horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        //move the player
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
    //restrain the unnecessary movement of the player
    void ConstrainPlayerPosition()
    {
        //set the left boundary of a player
        if(transform.position.x < -xRange )
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        //set the right boundary of a player
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }
    }

    //activate powerup effect for 7 seconds
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        //hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
        GetComponent<Collider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }   
    }

    private void OnTriggerEnter(Collider other) 
    {
        //increment the number of flowers when the player collect a flower
        //coin was the original idea -> now it's a flower
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameManager.GetComponent<GameManager>().Flowers++;
            audioSource.PlayOneShot(collectSound);
        }
        else if(other.gameObject.CompareTag("Nitro"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(collectSound);
            //hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            GetComponent<Collider>().isTrigger = true;
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
}
