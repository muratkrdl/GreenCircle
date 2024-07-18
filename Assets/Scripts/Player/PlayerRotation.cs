using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float rotateSpeed;

    [SerializeField] float maxRotateValue;

    void Update() 
    {
        float rotateValue = myRigidbody.velocity.x * rotateSpeed * Time.deltaTime;
        rotateValue = Mathf.Clamp(rotateValue, -maxRotateValue, maxRotateValue);
        transform.Rotate(new Vector3(0, 0, rotateValue));
    }

}
