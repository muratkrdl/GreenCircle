using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints;

    [SerializeField] Animator animator;

    int currentHealthPoint;

    void Start() 
    {
        currentHealthPoint = maxHitPoints;
    }

    public void GetDamage(int amount)
    {
        currentHealthPoint -= amount;

        if(currentHealthPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        SoundManager.Instancce.PlaySound2D("EnemyDie");
    }

    public void DeactiveEnemy()
    {
        gameObject.SetActive(false);
    }

}
