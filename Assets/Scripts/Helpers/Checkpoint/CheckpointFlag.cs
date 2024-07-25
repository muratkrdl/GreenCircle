using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform checkpointPosition;

    public Vector3 GetCheckpointPosition
    {
        get
        {
            return checkpointPosition.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.PLAYER))
        {
            animator.SetTrigger("Up");

            SoundManager.Instancce.PlaySound2D("CheckpointFlag");

            RespawnPosition.On_RespawnPositionChanged?.Invoke(this, new() { newPosition = checkpointPosition.position } );

            GetComponent<BoxCollider2D>().enabled = false;
        }    
    }

}
