using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassEnemy : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        Invoke(nameof(SetLayer), .3f);
    }

    void SetLayer()
    {
        gameObject.layer = layerMask;
    }

}
