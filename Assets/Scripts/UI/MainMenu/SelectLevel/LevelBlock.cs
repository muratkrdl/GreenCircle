using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBlock : MonoBehaviour
{
    [SerializeField] SceneAsset loadScene;

    [SerializeField] Image[] starImages;
    [SerializeField] Sprite[] starSprites;

    [SerializeField] Image lockedImage;

    [SerializeField] LevelBlock previousLevelBlock;

    [SerializeField] bool isLocked = true;

    const string ISLOCKED_KEY = "Is_Locked";
    const string CHOOSEN_SPRITE_INDEX = "Choosen_Sprite_Index";
    const string GAINED_STAR_AMOUNT = "Gained_Star_Amount";

    [SerializeField] int lockedValue;

    int hmStarHave = 0;

    public bool GetIsLocked
    {
        get
        {
            return isLocked;
        } 
    }

    public int HMStarHave
    {
        get
        {
            return hmStarHave;
        }
        set
        {
            hmStarHave = value;
        }
    }

    void Awake() 
    {
        if(PlayerPrefs.GetInt(gameObject.name + ISLOCKED_KEY) > lockedValue)
        {
            lockedValue = PlayerPrefs.GetInt(gameObject.name + ISLOCKED_KEY);
        }
        else
        {
            PlayerPrefs.SetInt(gameObject.name + ISLOCKED_KEY, lockedValue);
        }

        SetPlayerPrefs();
    }

    public SceneAsset GetLoadScene
    {
        get
        {
            return loadScene;
        }
    }

    public void On_Click_LoadScene()
    {
        MainMenuManager.Instance.FadeImage();
        Invoke(nameof(InvokeLoadScene), 1f);
    }

    void InvokeLoadScene()
    {
        SceneManager.LoadScene(loadScene.name);
    }

    public void CanBeOpen()
    {
        if(previousLevelBlock.HMStarHave >= 1)
        {
            isLocked = false;
            lockedImage.gameObject.SetActive(false);
            PlayerPrefs.SetInt(gameObject.name + ISLOCKED_KEY, 1);
        }
    } 

    public void ShowStars()
    {
        Sprite gainedStar = starSprites[hmStarHave -1];

        for (int i = 0; i < hmStarHave; i++)
        {
            starImages[i].enabled = true;
            starImages[i].sprite = gainedStar;
        }

        if(PlayerPrefs.GetInt(gameObject.name + CHOOSEN_SPRITE_INDEX) < hmStarHave -1)
            PlayerPrefs.SetInt(gameObject.name + CHOOSEN_SPRITE_INDEX, hmStarHave -1);
    }

    void SetPlayerPrefs()
    {
        if(lockedValue == 0)
        {
            isLocked = true;
            lockedImage.enabled = true;
        }
        else if(lockedValue == 1)
        {
            isLocked = false;
            lockedImage.enabled = false;
        }

        if(PlayerPrefs.GetInt(gameObject.name + CHOOSEN_SPRITE_INDEX) == 0) return;
        for (int i = 0; i < PlayerPrefs.GetInt(gameObject.name + CHOOSEN_SPRITE_INDEX) + 1; i++)
        {
            starImages[i].enabled = true;
            starImages[i].sprite = starSprites[PlayerPrefs.GetInt(gameObject.name + CHOOSEN_SPRITE_INDEX)];
        }
    }

}
