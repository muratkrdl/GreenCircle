using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DamageSource
{
    none,
    enemy,
    world
}

public class HealthBar : MonoBehaviour
{
    public EventHandler<OnDecreaseHealth> OnDecreaseHealthEvent;

    public class OnDecreaseHealth : EventArgs
    {
        public int amount;
        public DamageSource damageSource;
    }

    [SerializeField] Image[] heartImages;

    [SerializeField] Sprite[] heartSprites;

    [SerializeField] Animator animator;

    int health;

    bool isLive;

    bool canTakeDamage = true;

    void Start() 
    {
        foreach (var item in heartImages)
        {
            item.sprite = heartSprites[1];
        }
        health = 3;
        SetIsLive(true);

        OnDecreaseHealthEvent += Healthbar_OnDecreaseHealthEvent;
    }

    void Healthbar_OnDecreaseHealthEvent(object sender, OnDecreaseHealth e)
    {
        DecreaseHealth(e.amount, e.damageSource);
    }

    void DecreaseHealth(int amount, DamageSource damageSource)
    {
        if(!isLive || !canTakeDamage) return;

        health -= amount;

        if(health < 0)
        {
            health = 0;
        }

        animator.SetTrigger("GetDamage");
        switch(health)
        {
            case 2:
                heartImages[2].sprite = heartSprites[0];
                if(damageSource == DamageSource.world)
                    RespawnPosition.Instance.InvokeGoCheckPoint();
                break;
            case 1:
                heartImages[1].sprite = heartSprites[0];
                if(damageSource == DamageSource.world)
                    RespawnPosition.Instance.InvokeGoCheckPoint();
                break;
            default:
                heartImages[0].sprite = heartSprites[0];
                SetIsLive(false);
                animator.SetTrigger("Die");
                float delay = 0;
                if(damageSource == DamageSource.world)
                {
                    delay = 2;
                }
                Collision.OnGameFinished?.Invoke(this, EventArgs.Empty);
                GetComponentInParent<Animator>().SetTrigger("Die");
                PlayerUIManager.Instance.InvokeShowPanel(delay);
                break;
        }

        canTakeDamage = false;
        Invoke(nameof(InvokeCanTakeDamageTrue), 1.25f);
    }

    void InvokeCanTakeDamageTrue()
    {
        canTakeDamage = true;
    }

    public void SetIsLive(bool value)
    {
        isLive = value;
    }

}
