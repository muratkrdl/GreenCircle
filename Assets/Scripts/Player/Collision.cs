using System;
using System.Collections;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static EventHandler OnGameFinished;

    [SerializeField] PanelUI panelUI;

    [SerializeField] Rigidbody2D myRigidbody;

    [SerializeField] float backPushForce;
    [SerializeField] float enemyKillOffset;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(PauseUI.isGamePaused) return;

        if(other.CompareTag(TagManager.DEAD_ZONE))
        {
            StandartManager.Instance.SetFollowCamera(null);

            SoundManager.Instancce.PlaySound2D("Fall");

            PlayerUIManager.Instance.GetHealthBar.OnDecreaseHealthEvent?.Invoke(this, new() { amount = 1, damageSource = DamageSource.world } );

            Invoke(nameof(StopBall), 2);
        }
        else if(other.CompareTag(TagManager.FINISH))
        {
            StandartManager.Instance.SetFollowCamera(null);
            OnGameFinished?.Invoke(this, EventArgs.Empty);
            GetComponentInChildren<PanelUI>().SetIsGameFinishedWithFinishLine = true;
            panelUI.PlayAnim();
        }
        else if(other.CompareTag(TagManager.STOP))
        {
            StopBall();
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(PauseUI.isGamePaused) return;

        if(other.transform.CompareTag(TagManager.ENEMY))
        {
            if(transform.position.y - other.transform.position.y > enemyKillOffset)
            {
                if(other.gameObject.TryGetComponent<EnemyHealth>(out var health))
                {
                    health.GetDamage(1);
                }
            }
            else
            {
                SoundManager.Instancce.PlaySound2D("TakeDamage");
                PlayerUIManager.Instance.GetHealthBar.OnDecreaseHealthEvent?.Invoke(this, new() { amount = 1, damageSource = DamageSource.enemy } );
            }
            
            Vector2 direction = other.transform.position - transform.position;
            direction.Normalize();
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.AddForce(-direction * backPushForce);
        }
        else if(other.gameObject.CompareTag(TagManager.TURNING_SPIKE))
        {
            SoundManager.Instancce.PlaySound2D("KilledFromTurningSpike");
            // kan efekti
            StandartManager.Instance.SetFollowCamera(null);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetTrigger("BigSpike");
            PlayerUIManager.Instance.GetHealthBar.OnDecreaseHealthEvent?.Invoke(this, new() { amount = 1, damageSource = DamageSource.world } );
        }
    }

    public void StopBall()
    {
        myRigidbody.bodyType = RigidbodyType2D.Static;
    }

    public void SetBodyTypeDynmaic()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

}
