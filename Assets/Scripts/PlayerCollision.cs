using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Obstacle") {
            Debug.Log("obstacle");
            playerMovement.detachment();
            FindObjectOfType<Score>().scoreStoper();
            FindObjectOfType<GameManager>().EndGame();  

        }
    }
}
