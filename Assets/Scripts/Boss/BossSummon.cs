using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummon : MonoBehaviour
{
    [SerializeField] GameObject summonObj;

    [SerializeField] ParticleSystem particleSystemm;

    [SerializeField] Transform summonPos;

    public void SummonObject()
    {
        particleSystemm.Play();
        Instantiate(summonObj, summonPos.position, Quaternion.identity);
    }

}
