using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlatform : MonoBehaviour
{
    [SerializeField] float startAnimationDelay;

    void Start()
    {
        Invoke(nameof(Delay), startAnimationDelay);
    }

    void Delay()
    {
        GetComponent<Animation>().Play();
    }

}
