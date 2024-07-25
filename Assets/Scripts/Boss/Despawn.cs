using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystemm;
    [SerializeField] float delay;

    void Start() 
    {
        Invoke(nameof(ForInvoke), delay);
    }

    void ForInvoke()
    {
        particleSystemm.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
