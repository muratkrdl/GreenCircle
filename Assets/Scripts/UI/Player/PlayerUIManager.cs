using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager Instance;

    [SerializeField] Animator fadeImageAnimator;

    [SerializeField] PanelUI panelUI;
    [SerializeField] HealthBar healthBar;

    public HealthBar GetHealthBar
    {
        get
        {
            return healthBar;
        }
    }

    void Awake() 
    {
        Instance = this;    
    }

    public void InvokeShowPanel(float invokeDelay)
    {
        Invoke(nameof(ShowPanel), invokeDelay);
    }

    void ShowPanel()
    {
        panelUI.PlayAnim();
    }

    public void FadeImage()
    {
        fadeImageAnimator.SetTrigger("Fade");
    }

    public void UnFadeImage()
    {
        fadeImageAnimator.SetTrigger("UnFade");
    }

}
