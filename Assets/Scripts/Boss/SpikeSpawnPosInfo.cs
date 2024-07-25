using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawnPosInfo : MonoBehaviour
{
    public Transform transformValue;

    bool canUse = true;

    public bool CanUse
    {
        get
        {
            return canUse;
        }
        set
        {
            canUse = value;
        }
    }
}
