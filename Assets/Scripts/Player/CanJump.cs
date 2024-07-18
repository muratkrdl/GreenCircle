using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanJump : MonoBehaviour
{
    public static EventHandler On_JumpEvent;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] Image jumpButtonImage;

    [SerializeField] LayerMask canJumpLayers;

    [SerializeField] CircleCollider2D circleCollider2D;

    void Start() 
    {
        On_JumpEvent += CanJump_On_JumpEvent;
        Collision.OnGameFinished += Collision_OnGameFinished;
    }

    void Collision_OnGameFinished(object sender, EventArgs e)
    {
        jumpButtonImage.raycastTarget = false;
    }

    void CanJump_On_JumpEvent(object sender, EventArgs e)
    {
        if(CheckGround())
        {
            SoundManager.Instancce.PlaySound2D("Jump");
            playerMovement.JumpFunction();
        }
    }

    public void On_Click_JumpButton()
    {
        On_JumpEvent?.Invoke(this, EventArgs.Empty);
    }

    public bool CheckGround()
    {
	    return Physics2D.IsTouchingLayers(circleCollider2D, canJumpLayers);
    }

    void OnDestroy()
    {
        On_JumpEvent -= CanJump_On_JumpEvent;
        Collision.OnGameFinished -= Collision_OnGameFinished;
    }

}
