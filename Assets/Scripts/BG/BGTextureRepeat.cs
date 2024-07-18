using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTextureRepeat : MonoBehaviour
{
    [SerializeField] SpriteRenderer mySpriteRenderer;   

    [SerializeField] Rigidbody2D myRigidbody; 

    [SerializeField] float changeSpeed;

    void LateUpdate()
    {
        ChangeTextureOffset();
    }

    void ChangeTextureOffset()
    {
        Vector2 newOffset = mySpriteRenderer.material.mainTextureOffset;
        newOffset.x += changeSpeed * Time.deltaTime * myRigidbody.velocity.x;
        mySpriteRenderer.material.mainTextureOffset = newOffset;
    }

}
