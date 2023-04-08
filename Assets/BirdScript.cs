using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Bob Birdington";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) {
            myRigidbody2D.velocity = Vector2.up * flapStrength;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && birdIsAlive == true)
        {
            // Touch detected, do something
            myRigidbody2D.velocity = Vector2.up * flapStrength;
            Debug.Log("Touch detected on Android device");
        }
        if (transform.position.y > 16 || transform.position.y < -17)
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
