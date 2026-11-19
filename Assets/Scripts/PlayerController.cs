/**************************************************************
* This script is attached to the player
* Its purpose is to move the player towards the location of 
* the mouse click and to destroy the player if it collides
* with anything in the scene.
*
* Cameron K.
* [November 19 v1
**************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private float thrustForce = 2.5f;
     [SerializeField] private GameObject explosionEffect;

  Rigidbody2D playerRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         playerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerToMouse();

    }
     private void MovePlayerToMouse()
    {
         if (Mouse.current.leftButton.isPressed)
        {
            // Calculate mouse direction
 Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
Vector2 direction = (mousePos - transform.position).normalized;
            // Move player in direction of mouse
            transform.up = direction;
  playerRB.AddForce(direction * thrustForce);
        } 

    }
 void OnCollisionEnter2D(Collision2D collision)
    {
       Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
