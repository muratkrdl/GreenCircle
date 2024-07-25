using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningSpike : MonoBehaviour
{
    [SerializeField] GameObject[] rotateObj;

    [SerializeField] float rotateSpeed;

    void Update() 
    {
        foreach (var item in rotateObj)
        {
            if(item == rotateObj[0])
            {
                item.transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
            }
            else
            {
                item.transform.Rotate(-rotateSpeed * Time.deltaTime * Vector3.forward);
            }
        }
    }

}
