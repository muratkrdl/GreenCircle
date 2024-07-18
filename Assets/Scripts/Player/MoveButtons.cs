using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] MoveInputs myInputs;

    [SerializeField] Animator animator;

    [SerializeField] Image moveButtonImage;

    [SerializeField] bool isLeft;

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
        moveButtonImage.raycastTarget = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        myInputs.SetBooleans(isLeft, true);
        animator.SetTrigger("Push");
        myInputs.On_PushingButton?.Invoke(this, EventArgs.Empty);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        myInputs.SetBooleans(isLeft, false);
        animator.SetTrigger("Idle");
        myInputs.On_DontPushingButton?.Invoke(this, EventArgs.Empty);
    }

}
