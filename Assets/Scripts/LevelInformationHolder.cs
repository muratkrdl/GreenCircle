using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInformationHolder : MonoBehaviour
{
    public static LevelInformationHolder Instance { get; private set; }

    LevelBlock[] levelBlocks;

    string currentlyPlayingLevelName;

    int currentlyPlayingLevelGainedStarAmount;

    bool nextLevel;

    public bool SetNextLevel
    {
        set
        {
            nextLevel = value;
        }
    }

    public int SetCurrentlyPlayingLevelGainedStarAmount
    {
        set
        {
            currentlyPlayingLevelGainedStarAmount = value;
        }
    }

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

        Application.targetFrameRate = 60;
    }

    void Start()
    {
        SceneManager.sceneLoaded += SceneManager_LoadScene;
    }

    void OnDestroy() 
    {
        SceneManager.sceneLoaded -= SceneManager_LoadScene;
    }

    void SceneManager_LoadScene(Scene loadedScene, LoadSceneMode arg1)
    {
        if(loadedScene.name == "MainMenu")
        {
            levelBlocks = MainMenuManager.Instance.GetLevelBlocks;

            foreach (var item in levelBlocks)
            {
                if(!item.GetIsLocked)
                {
                    if(currentlyPlayingLevelName == item.GetLoadScene)
                    {
                        item.HMStarHave = currentlyPlayingLevelGainedStarAmount;
                        item.ShowStars();
                    }
                }
                else if(item.GetIsLocked)
                {
                    item.CanBeOpen();
                }
            }

            if(nextLevel)
            {
                MainMenuManager.Instance.GetMenuAnimator.SetTrigger("SelectLevel");
            }
        }
        else
        {
            currentlyPlayingLevelName = loadedScene.name;
        }
    }
    
}
