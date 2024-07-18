using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMovingPlatform : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] Vector2 moveDirection;

    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.fixedDeltaTime * moveDirection);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ROTATE))
        {
            moveSpeed *= -1;
        }    
    }

}
