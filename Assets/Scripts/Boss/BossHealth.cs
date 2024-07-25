using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] Image[] heartImages;
    [SerializeField] Sprite emptyHeartSprite;

    [SerializeField] Animator animator;

    int currentHealth = 3;

    bool canTakeDamage = false;

    bool isDead;

    public bool GetIsDead
    {
        get
        {
            return isDead;
        }
    }

    public bool GetCanTakeDamage
    {
        get
        {
            return canTakeDamage;
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        animator.SetTrigger("GetDamage");
        switch(currentHealth)
        {
            case 2:
                heartImages[2].sprite = emptyHeartSprite;
                break;
            case 1:
                heartImages[1].sprite = emptyHeartSprite;
                break;
            default:
                heartImages[0].sprite = emptyHeartSprite;
                animator.SetTrigger("Die");
                GetComponent<Animator>().SetTrigger("Die");
                PlayerUIManager.Instance.GetPanelUI.SetIsGameFinishedWithFinishLine = true;
                FindObjectOfType<PointCounter>().GetCollectedPointAmount = 9;
                PlayerUIManager.Instance.InvokeShowPanel(0);
                isDead = true;
                break;
        }

        canTakeDamage = false;
    }

    public void GET()
    {
        animator.SetTrigger("GetDamage");
    }

    public void SetTrueCanTakeDamage()
    {
        canTakeDamage = true;
    }

    public void SetFalseCanTakeDamage()
    {
        canTakeDamage = false;
    }

}
