using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class prop : MonoBehaviour
{
    private Scene scene;
    float speed = 1f;
    int moveDirection = 1;
    Rigidbody2D rigidbody2D;


    private float timer = 0.0f;
    private float directionChangeInterval = 5.0f;



    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Update the timer
        timer += Time.deltaTime;

        // Change direction every 5 seconds
        if (timer >= directionChangeInterval)
        {
            // Reverse the direction
            speed *= -1;

            // Reset the timer
            timer = 0.0f;
        }

        // Move the object
        rigidbody2D.velocity = new Vector2(speed, 0);

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            score.lives--;
            SceneManager.LoadScene(scene.buildIndex);
            score.totalScore = 0;
        }
        
    }
}
