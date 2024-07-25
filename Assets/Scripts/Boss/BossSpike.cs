using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpike : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] SpikeSpawnPosInfo[] spawnPoses;
    
    SpikeSpawnPosInfo choosenInfo;

    public void SpawnSpikes()
    {
        for (int i = 0; i < 2; i++)
        {
            while(true)
            {
                SpikeSpawnPosInfo spawnPosInfo = spawnPoses[Random.Range(0, spawnPoses.Length)];
                if(spawnPosInfo.CanUse)
                {
                    spawnPosInfo.CanUse = false;
                    choosenInfo = spawnPosInfo;
                    break;
                }
            }

            Instantiate(spikePrefab, choosenInfo.transformValue);
        }

        foreach (var item in spawnPoses)
        {
            item.CanUse = true;
        }
    }

}
