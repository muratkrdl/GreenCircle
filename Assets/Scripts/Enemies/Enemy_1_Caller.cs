using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy_1_Caller : MonoBehaviour
{
    [SerializeField] GameObject grassEnemyPrefab;
    [SerializeField] Transform spawnPos;

    [SerializeField] GameObject[] rotateObj;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PLAYER))
        {
            Invoke(nameof(CollisionEvent), .15f);
        }
    }

    void CollisionEvent()
    {
        var enemy = Instantiate(grassEnemyPrefab, spawnPos.position, Quaternion.identity);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<TilemapRenderer>().enabled = false;
        Invoke(nameof(OpenRotateObj), 2);
    }

    void OpenRotateObj()
    {
        foreach (var item in rotateObj)
        {
            item.SetActive(true);
        }
    }

}
