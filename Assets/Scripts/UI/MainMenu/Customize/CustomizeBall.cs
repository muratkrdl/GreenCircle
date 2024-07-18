using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeBall : MonoBehaviour
{
    [SerializeField] Image customizeImage;
    [SerializeField] Sprite[] customizeSprites;

    [SerializeField] TextMeshProUGUI counterText;

    [SerializeField] bool isFace;

    const string CHOOSEN_BALL_KEY = "Choosen_Ball";
    const string CHOOSEN_FACE_KEY = "Choosen_Face";

    int counter;

    void Start() 
    {
        if(isFace)
        {
            counter = PlayerPrefs.GetInt(CHOOSEN_FACE_KEY) +1;
        }
        else
        {
            counter = PlayerPrefs.GetInt(CHOOSEN_BALL_KEY) +1;
        }

        customizeImage.sprite = customizeSprites[counter -1];
        counterText.text = counter.ToString();
    }

    public void On_Click_PushButton(bool isleft)
    {
        if(isleft)
        {
            counter--;
            if(counter <= 0)
            {
                counter = customizeSprites.Length;
            }
        }
        else
        {
            counter++;
            if(counter >= customizeSprites.Length)
            {
                counter = 1;
            }
        }

        counterText.text = counter.ToString();
        customizeImage.sprite = customizeSprites[counter - 1];
    }

    
    public void On_ClickCustomizeSaveButon()
    {
        PlayerInformationHolder.Instance.SaveCustomizeBall(counter -1, isFace);
    }

}
