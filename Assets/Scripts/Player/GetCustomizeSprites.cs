using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCustomizeSprites : MonoBehaviour
{
    public static GetCustomizeSprites Instance;

    [SerializeField] SpriteRenderer ballSpriteRenderer;
    [SerializeField] SpriteRenderer faceSpriteRenderer;

    void Awake() 
    {
        Instance = this;    
    }

    void Start() 
    {
        SetCustomizeSprites();
    }

    public void SetCustomizeSprites()
    {
        faceSpriteRenderer.sprite = PlayerInformationHolder.Instance.GetChoosenFaceSprite();
        ballSpriteRenderer.sprite = PlayerInformationHolder.Instance.GetChoosenBallSprite();
    }

}
