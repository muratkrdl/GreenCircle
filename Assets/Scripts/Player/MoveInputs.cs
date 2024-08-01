using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveInputs : MonoBehaviour
{
    public EventHandler On_DontPushingButton;
    public EventHandler On_PushingButton;

    [SerializeField] Rigidbody2D myRigidbody;
    
    [SerializeField] float lerpTime;

    Vector2 moveInput;

    bool isPushingLeftButton = false;
    bool isPushingRightButton = false;

    bool gameFinish = false;

    public Vector2 MoveInput
    {
        get
        {
            return moveInput;
        }
        set
        {
            moveInput = value;
        }
    }

    public bool GameFinished
    {
        get
        {
            return gameFinish;
        }
    }

    void Start() 
    {
        Collision.OnGameFinished += Collision_OnGameFinished;
    }

    void OnDestroy() 
    {
        Collision.OnGameFinished -= Collision_OnGameFinished;
    }

    void Collision_OnGameFinished(object sender, EventArgs e)
    {
        gameObject.layer = LayerMask.NameToLayer("Dead");
        StandartManager.Instance.SetFollowCamera(null);
        gameFinish = true;
        moveInput = Vector2.zero;
        isPushingLeftButton = false;
        isPushingRightButton = false;
    }

    void Update()
    {
        if(gameFinish)
        {
            moveInput.x = 1;
            return;
        }

        SetMoveInput();

        // if(Input.GetKey(KeyCode.D))
        // {
        //     isPushingRightButton = true;
        // }
        // else
        // {
        //     isPushingRightButton = false;
        // }

        // if(Input.GetKey(KeyCode.A))
        // {
        //     isPushingLeftButton = true;
        // }
        // else
        // {
        //     isPushingLeftButton = false;
        // }
    }

    void SetMoveInput()
    {
        if(isPushingLeftButton)
        {
            moveInput.x = Mathf.Lerp(moveInput.x, -1, lerpTime * Time.deltaTime);
        }
        else if(isPushingRightButton)
        {
            moveInput.x = Mathf.Lerp(moveInput.x, 1, lerpTime * Time.deltaTime);
        }
        else if(myRigidbody.velocity.x > 0)
        {
            moveInput.x = Mathf.Lerp(moveInput.x, -1, lerpTime * Time.deltaTime);
        }
        else if(myRigidbody.velocity.x < 0)
        {
            moveInput.x = Mathf.Lerp(moveInput.x, 1, lerpTime * Time.deltaTime);
        }
        else if(Mathf.Abs(myRigidbody.velocity.x) <= 0.2f)
        {
            if(myRigidbody.bodyType == RigidbodyType2D.Static) return;
            myRigidbody.velocity = new(0, myRigidbody.velocity.y);
            moveInput.x = 0;
        }
    }

    public void SetBooleans(bool isLeft, bool isTrue)
    {
        if(isLeft)
        {
            isPushingLeftButton = isTrue;
        }
        else
        {
            isPushingRightButton = isTrue;
        }
    }

}
