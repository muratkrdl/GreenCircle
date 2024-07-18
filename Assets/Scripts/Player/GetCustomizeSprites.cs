using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCustomizeSprites : MonoBehaviour
{
    [SerializeField] SpriteRenderer ballSpriteRenderer;
    [SerializeField] SpriteRenderer faceSpriteRenderer;

    void Start() 
    {
        ballSpriteRenderer.sprite = PlayerInformationHolder.Instance.GetChoosenBallSprite();
        faceSpriteRenderer.sprite = PlayerInformationHolder.Instance.GetChoosenFaceSprite();    
    }

}
