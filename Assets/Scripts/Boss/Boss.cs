using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] BossSpike bossSpike;
    [SerializeField] BossSummon bossSummon;

    [SerializeField] BossHealth bossHealth;

    [SerializeField] Animator bossAnimator;

    public bool canUseAbility = false;

    public void CanUseAbilityTrue()
    {
        canUseAbility = true;
    }

    public void CanUseAbilityFalse()
    {
        canUseAbility = true;
    }

    public void UseAbility()
    {
        if(bossHealth.GetIsDead || !canUseAbility) return;

        StartCoroutine(UseAbilityCoRoutine());
    }

    IEnumerator UseAbilityCoRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            if(canUseAbility)
            {
                bossAnimator.SetTrigger("Jump");
                break;
            }
        }
        StopAllCoroutines();
    }

    public void JumpAbilityAnimEvent()
    {
        int a = Random.Range(0, 2);
        if(a == 0)
        {
            bossSpike.SpawnSpikes();
        }
        else
        {
            bossSummon.SummonObject();
        }
    }

    public void JumpSFX()
    {
        SoundManager.Instancce.PlaySound2D("BossJump");
    }

    public void SmashSFX()
    {
        SoundManager.Instancce.PlaySound2D("BossSmash");
    }

}
