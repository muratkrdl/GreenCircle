using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    [SerializeField] BossHealth bossHealth;

    public bool oneShot = true;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PLAYER))
        {
            if(bossHealth.GetCanTakeDamage)
            {
                bossHealth.DecreaseHealth(1);
                SoundManager.Instancce.PlaySound2D("BossGetDamage");
            }
            else
            {
                int value;
                if(oneShot)
                {
                    value = 3;
                }
                else
                {
                    value = 1;
                }
                PlayerUIManager.Instance.GetHealthBar.OnDecreaseHealthEvent?.Invoke(this, new() { amount = value, damageSource = DamageSource.enemy } );
            }
        }
    }

    public void SetOneShotFalse()
    {
        oneShot = false;
    }

}
