using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollower : MonoBehaviour
{
    [SerializeField] Transform follow;

    void Update() 
    {
        transform.position = follow.position;    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PLAYER))
        {
            PlayerUIManager.Instance.GetHealthBar.OnDecreaseHealthEvent?.Invoke(this, new() { amount = 1, damageSource = DamageSource.enemy } );
        }    
    }

}
