using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPosition : MonoBehaviour
{
    public static RespawnPosition Instance;

    public static EventHandler<RespawnPositionChanged> On_RespawnPositionChanged;

    public class RespawnPositionChanged : EventArgs
    {
        public Vector3 newPosition;
    }

    [SerializeField] float goCheckPointDelay;

    Vector3 currentRespawnPoint;

    void Awake() 
    {
        Instance = this;    
    }

    void Start() 
    {
        currentRespawnPoint = transform.position;

        On_RespawnPositionChanged += RespawnPotion_On_RespawnPositionChanged;
    }

    void OnDestroy() 
    {
        On_RespawnPositionChanged -= RespawnPotion_On_RespawnPositionChanged;
    }

    void RespawnPotion_On_RespawnPositionChanged(object sender, RespawnPositionChanged e)
    {
        currentRespawnPoint = e.newPosition;
    }

    public void InvokeGoCheckPoint()
    {
        Invoke(nameof(GoCheckPoint), goCheckPointDelay);
    }

    void GoCheckPoint()
    {
        transform.SetPositionAndRotation(currentRespawnPoint, Quaternion.Euler(Vector3.zero));
        GetComponent<Animator>().SetTrigger("Idle");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        StandartManager.Instance.SetFollowCamera(transform);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StandartManager.Instance.SetCratesPos();
    }

    IEnumerator ForAnimator()
    {
        yield return new WaitForEndOfFrame();

        GetComponent<Animator>().enabled = false;
        GetCustomizeSprites.Instance.SetCustomizeSprites();

        StopAllCoroutines();
    }

}
