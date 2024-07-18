using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlockCollision : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;

    [SerializeField] float purpleLayerGraityScale;

    [SerializeField] float invokeDelay;

    float initialGravity;

    bool makeZero = true;

    void Start() 
    {
        initialGravity = myRigidbody.gravityScale;
        CanJump.On_JumpEvent += CanJump_On_JumpEvent;
    }

    void CanJump_On_JumpEvent(object sender, EventArgs e)
    {
        makeZero = false;
        Invoke(nameof(InvokeMakeZero), invokeDelay);
    }

    void InvokeMakeZero()
    {
        makeZero = true;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PURPLE))
        {
            myRigidbody.gravityScale = purpleLayerGraityScale;
            if(makeZero)
            {
                myRigidbody.velocity = new (myRigidbody.velocity.x, 0);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PURPLE))
        {
            myRigidbody.gravityScale = initialGravity;
        }
    }

    void OnDestroy() 
    {
        CanJump.On_JumpEvent -= CanJump_On_JumpEvent;
    }

}
