using System;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public EventHandler sceneChanging;

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

        sceneChanging += MainMenuManager_SceneChanging;
    }

    void MainMenuManager_SceneChanging(object sender, EventArgs e)
    {
        foreach (var item in levelBlocks)
        {
            item.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
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

    void OnDestroy() 
    {
        sceneChanging -= MainMenuManager_SceneChanging;
    }

    void InvokeQuit()
    {
        Application.Quit();
    }

}
