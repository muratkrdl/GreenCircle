using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static EventHandler OnPointCollected;
    
    int currentPointAmount = 0;

    public int GetCollectedPointAmount
    {
        get
        {
            return currentPointAmount;
        }
        set
        {
            currentPointAmount = value;
        }
    }

    void Start() 
    {
        OnPointCollected += PointCounter_OnStarCollected;
    }

    void OnDestroy() 
    {
        OnPointCollected -= PointCounter_OnStarCollected;
    }

    void PointCounter_OnStarCollected(object sender, EventArgs e)
    {
        currentPointAmount++;
        SoundManager.Instancce.PlaySound2D("PointCollect");
    }

}
