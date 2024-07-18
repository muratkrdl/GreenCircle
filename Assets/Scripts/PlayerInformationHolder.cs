using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformationHolder : MonoBehaviour
{
    public static PlayerInformationHolder Instance { get; private set; }

    [SerializeField] Sprite[] ballSprites;
    [SerializeField] Sprite[] faceSprites;

    const string CHOOSEN_BALL_KEY = "Choosen_Ball";
    const string CHOOSEN_FACE_KEY = "Choosen_Face";

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveCustomizeBall(int index, bool isFace)
    {
        if(isFace)
        {
            PlayerPrefs.SetInt(CHOOSEN_FACE_KEY, index);
        }
        else
        {
            PlayerPrefs.SetInt(CHOOSEN_BALL_KEY, index);
        }
    }

    public Sprite GetChoosenBallSprite()
    {
        return ballSprites[PlayerPrefs.GetInt(CHOOSEN_BALL_KEY)];
    }

    public Sprite GetChoosenFaceSprite()
    {
        return faceSprites[PlayerPrefs.GetInt(CHOOSEN_BALL_KEY)];
    }

}
