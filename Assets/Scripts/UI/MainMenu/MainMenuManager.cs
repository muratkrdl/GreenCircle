using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    [SerializeField] Animator menuAnimator;

    [SerializeField] Animator fadeImageAnimator;

    [SerializeField] LevelBlock[] levelBlocks;
    
    public LevelBlock[] GetLevelBlocks
    {
        get
        {
            return levelBlocks;
        }
    }

    public Animator GetMenuAnimator
    {
        get
        {
            return menuAnimator;
        }
    }

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        Invoke(nameof(InvokeStart), .35f);
    }

    void InvokeStart()
    {
        UnFadeImage();
    }

    public void FadeImage()
    {
        fadeImageAnimator.SetTrigger("Fade");
    }

    public void UnFadeImage()
    {
        fadeImageAnimator.SetTrigger("UnFade");
    }

    public void On_Click_SelectLevel()
    {
        menuAnimator.SetTrigger("SelectLevel");
    }

    public void On_Click_MainMenu()
    {
        menuAnimator.SetTrigger("MainMenu");
    }

    public void On_Click_CustomizePlayer()
    {
        menuAnimator.SetTrigger("Customize");
    }

    public void On_Click_Quit()
    {
        FadeImage();
        Invoke(nameof(InvokeQuit), 0.65f);
    }

    void InvokeQuit()
    {
        Application.Quit();
    }

}
