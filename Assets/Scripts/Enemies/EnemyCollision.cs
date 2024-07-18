using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Rigidbody2D myRigidbody;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ROTATE))
        {
            enemyMovement.RotateSpeed *= -1;
            myRigidbody.velocity *= -1;
            myRigidbody.angularVelocity *= -1;
            if(enemyMovement.RotateSpeed > 0)
            {
                myRigidbody.angularVelocity += 180;
            }
            else
            {
                myRigidbody.angularVelocity -= 180;
            }
        }
    }

}
