using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;

    [SerializeField] float rotateSpeed;

    public float RotateSpeed
    {
        get
        {
            return rotateSpeed;
        }
        set
        {
            rotateSpeed = value;
        }
    }

    void Start() 
    {
        myRigidbody.angularVelocity = 180;
    }

    void Update() 
    {
        if(Mathf.Abs(myRigidbody.velocity.x) <= 0.01f)
        {
            if(rotateSpeed > 0)
                myRigidbody.angularVelocity = 180;
            else
                myRigidbody.angularVelocity = -180;
        }
    }

    void FixedUpdate()
    {
        myRigidbody.AddTorque(rotateSpeed * Time.fixedDeltaTime);
        ClampVelocity(myRigidbody);
    }

    void ClampVelocity(Rigidbody2D rigidbody2D)
    {
        Vector2 newValue = rigidbody2D.velocity;
        newValue.x = Mathf.Clamp(newValue.x, -1.5f, 1.5f);
        rigidbody2D.velocity = newValue;
    }

}
