using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static EventHandler OnPointCollected;
    
    int maxPointAmount;

    int currentPointAmount = 0;

    public int GetCollectedPointAmount
    {
        get
        {
            return currentPointAmount;
        }
    }

    void Start() 
    {
        maxPointAmount = StandartManager.Instance.GetPointsAmount;

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
