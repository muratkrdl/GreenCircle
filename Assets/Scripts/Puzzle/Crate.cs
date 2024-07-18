using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    Vector2 startPos;

    void Start() 
    {
        startPos = transform.position;
    }

    public void SetStartPos()
    {
        transform.position = startPos;
    }

}
