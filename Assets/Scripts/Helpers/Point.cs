using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.PLAYER))
        {
            PointCounter.OnPointCollected?.Invoke(this, EventArgs.Empty);
            // SoundManager.Instance.PlayClip(PointCollected);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }    
    }
}
