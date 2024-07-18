using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBlockCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] float snowMoveSpeed;

    float initialMoveSpeed;
    float initialMaxVelocity;

    void Start() 
    {
        initialMoveSpeed = playerMovement.MoveSpeed;
        initialMaxVelocity = playerMovement.MaxVelocity; 
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.SNOW))
        {
            playerMovement.MoveSpeed = snowMoveSpeed;
            playerMovement.MaxVelocity = initialMaxVelocity * 2;
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.SNOW))
        {
            playerMovement.MoveSpeed = initialMoveSpeed;
            playerMovement.MaxVelocity = initialMaxVelocity;
        }
    }

}
