using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu; 

    [SerializeField] UnityEngine.UI.Button pauseButton;

    public void OnClick_PauseButton()
    {
        SetPauseMenu(true);
        Time.timeScale = 0;
    }

    public void OnClick_Button()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void OnClick_ContinueButton()
    {
        SetPauseMenu(false);
    }

    void SetPauseMenu(bool value)
    {
        isGamePaused = value;
        pauseMenu.SetActive(value);
        pauseButton.interactable = !value;
    }

}
