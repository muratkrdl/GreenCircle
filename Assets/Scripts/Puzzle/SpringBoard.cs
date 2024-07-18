using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float jumpForce;

    GameObject jumpObj;

    bool startedAnimation = false;

    bool canJump = false;

    public void JumpFunctionEvent()
    {
        if(!canJump) return;

        if(jumpObj.TryGetComponent<Rigidbody2D>(out var component))
        {
            SoundManager.Instancce.PlaySound2D("SpringBoard");
            component.AddForce(jumpForce * Vector2.up);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.PLAYER))
        {
            canJump = true;
            jumpObj = other.gameObject;
            if(startedAnimation) return;
            startedAnimation = true;
            animator.SetTrigger("Jump");
        } 
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.PLAYER))
        {
            canJump = false;
            jumpObj = null;
            if(!startedAnimation) return;
            startedAnimation = false;
            animator.SetTrigger("Idle");
        }    
    }

    public void SetStartedAnimationFalseAnimEvent()
    {
        startedAnimation = false;
    }

}
