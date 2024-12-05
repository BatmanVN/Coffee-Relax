using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : Singleton<Cinema>
{
    public CinemachineVirtualCamera virtualCamera;
    private void OnValidate()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void OnEnable()
    {
        //Observer.AddObserver(ListAction.SetCamFollow, start_follow);
    }

    public void SetCamWin(Vector3 newVector)
    {
        var framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        framingTransposer.m_TrackedObjectOffset = newVector;

    }

    public void SetcamStart(Transform player/*object[] datas*/)
    {
        //if (datas == null || datas.Length < 1 || !(datas[0] is Transform player)) return;
        if (player != null)
            virtualCamera.Follow = player;
    }
    private void OnDestroy()
    {
        //Observer.RemoveObserver(ListAction.SetCamFollow, start_follow);
    }
}
