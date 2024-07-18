using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour
{
    [SerializeField] PlayerUIManager playerUIManager;

    [SerializeField] TextMeshProUGUI noStarText;

    [SerializeField] Image[] buttonsImage;

    [SerializeField] Animation diePanelAnimation;

    [SerializeField] PointCounter pointCounter;

    [SerializeField] Image[] startImages;

    [SerializeField] Sprite[] starSprites;

    int colledtedAmount = 0;

    bool isGameFinishedWithFinishLine = false;

    public bool SetIsGameFinishedWithFinishLine
    {
        set
        {
            isGameFinishedWithFinishLine = value;
        }
    }

    public void PlayAnim()
    {
        Invoke(nameof(StopBall), 2);
        diePanelAnimation.Play();
        if(isGameFinishedWithFinishLine)
        {
            colledtedAmount = pointCounter.GetCollectedPointAmount;
            StartCoroutine(StartStarAnimations());
        }
        else
        {
            noStarText.gameObject.SetActive(true);
            foreach (var item in buttonsImage)
            {
                item.raycastTarget = true;
            }
        }
    }

    void StopBall()
    {
        GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    } 

    IEnumerator StartStarAnimations()
    {
        Sprite choosenStarSprite;
        if(colledtedAmount <= 5)
        {
            choosenStarSprite = starSprites[0];
        }
        else if(colledtedAmount <= 8 && colledtedAmount > 5)
        {
            choosenStarSprite = starSprites[1];
        }
        else
        {
            choosenStarSprite = starSprites[2];
        }

        yield return new WaitForSeconds(1f);

        if(colledtedAmount < 3)
        {
            noStarText.gameObject.SetActive(true);
        }

        for (int i = 0; i < colledtedAmount / 3; i++)
        {
            startImages[i].sprite = choosenStarSprite;
            startImages[i].GetComponent<Animation>().Play();
            yield return new WaitForSeconds(.57f);
        }

        foreach (var item in buttonsImage)
        {
            item.raycastTarget = true;
        }

        colledtedAmount = 0;

        foreach (var item in startImages)
        {
            if(item.sprite == choosenStarSprite)
            {
                colledtedAmount++;
            }
        }

        if(isGameFinishedWithFinishLine)
        {
            LevelInformationHolder.Instance.SetCurrentlyPlayingLevelGainedStarAmount = colledtedAmount;
        }
        else
        {
            LevelInformationHolder.Instance.SetCurrentlyPlayingLevelGainedStarAmount = 0;
        }
        StopAllCoroutines();
    }

    public void On_Click_HomeButtonEvent()
    {
        playerUIManager.FadeImage();
        Invoke(nameof(InvokeHomeButton), .65f);
    }

    void InvokeHomeButton()
    {
        LevelInformationHolder.Instance.SetNextLevel = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void On_Click_RestartButtonEvent()
    {
        playerUIManager.FadeImage();
        Invoke(nameof(InvokeRestartLevelButton), .65f);
    }

    void InvokeRestartLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void On_Click_NextLevelButtonEvent()
    {
        playerUIManager.FadeImage();
        Invoke(nameof(InvokeNextLevelButton), .65f);
    }

    void InvokeNextLevelButton()
    {
        LevelInformationHolder.Instance.SetNextLevel = true;
        SceneManager.LoadScene("MainMenu");
    }

}
