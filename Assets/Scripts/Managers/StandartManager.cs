using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class StandartManager : MonoBehaviour
{
    public static StandartManager Instance;

    [SerializeField] Camera mainCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] Crate[] crates;

    void Awake() 
    {
        Instance = this;
    }

    public void SetFollowCamera(Transform follow)
    {
        if(follow != null)
        {
            cinemachineVirtualCamera.transform.position = follow.position;
        }
        cinemachineVirtualCamera.Follow = follow;
    }

    public void SetCratesPos()
    {
        foreach (var item in crates)
        {
            item.SetStartPos();
        }
    }

}
