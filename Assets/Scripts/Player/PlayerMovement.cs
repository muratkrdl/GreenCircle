using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MoveInputs myInputs;

    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] CircleCollider2D circleCollider2D;

    [SerializeField] LayerMask speedUpLayers;
    [SerializeField] LayerMask normalSpeedLayers;

    [SerializeField] float moveSpeed;
    [SerializeField] float maxVelocity;
    [SerializeField] float speedUpMaxVelocity;
    [SerializeField] float jumpForce;

    [SerializeField] float decreaseSpeedAmount;

    float initialMoveSpeed;

    float realMaxVelocity;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    public float MaxVelocity
    {
        get
        {
            return maxVelocity;
        }
        set
        {
            maxVelocity = value;
        }
    }

    void Start() 
    {
        initialMoveSpeed = moveSpeed;
        realMaxVelocity = maxVelocity;
        myInputs.On_DontPushingButton += MyInputs_DontPushingButton;
        myInputs.On_PushingButton += MyInputs_PushingButton;
    }

    void MyInputs_PushingButton(object sender, EventArgs e)
    {
        moveSpeed = initialMoveSpeed;
    }

    void MyInputs_DontPushingButton(object sender, EventArgs e)
    {
        moveSpeed = initialMoveSpeed / decreaseSpeedAmount;
    }

    void Update() 
    {
        SetMaxVelocity();
    }

    void SetMaxVelocity()
    {
        if(Physics2D.IsTouchingLayers(circleCollider2D, speedUpLayers))
        {
            realMaxVelocity = speedUpMaxVelocity;
        }
        else if(Physics2D.IsTouchingLayers(circleCollider2D, normalSpeedLayers))
        {
            realMaxVelocity = maxVelocity;
        }
    }

    void FixedUpdate() 
    {
        if(myRigidbody.bodyType == RigidbodyType2D.Static) return;

        Vector2 newVelo = myRigidbody.velocity;
        newVelo.x += myInputs.MoveInput.x * moveSpeed * Time.fixedDeltaTime;
        newVelo.x = Mathf.Clamp(newVelo.x, -realMaxVelocity, realMaxVelocity);
        
        myRigidbody.velocity = newVelo;
    }

    public void JumpFunction()
    {
        // zıplama efekti
        // zıplama sesi

        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        myRigidbody.AddForce(Vector2.up * jumpForce);
    }

    void OnDestroy() 
    {
        myInputs.On_DontPushingButton -= MyInputs_DontPushingButton;
        myInputs.On_PushingButton -= MyInputs_PushingButton;    
    }

}
