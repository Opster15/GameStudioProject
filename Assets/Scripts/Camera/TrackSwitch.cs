using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSwitch : MonoBehaviour
{
    Cinemachine.CinemachineDollyCart cart;
    Cinemachine.CinemachineVirtualCamera cam;

    public Cinemachine.CinemachineSmoothPath startPath;
    public Cinemachine.CinemachineSmoothPath[] playerPaths;
    public Cinemachine.CinemachineSmoothPath[] enemyPaths;

    public Transform playerFoc, enemyFoc;

    public bool m_isPlayerFoc;

    private void Awake()
    {
        cart = GetComponent<Cinemachine.CinemachineDollyCart>();
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        Reset();
    }

    private void Reset()
    {
        cart.m_Path = startPath;

        ChangeTrack();
    }

    public void Update()
    {
        if (cart.m_Position > 4)
        {
            ChangeTrack();
        }
    }

    public void ChangeTrack()
    {
        if (m_isPlayerFoc)
        {
            cam.LookAt = playerFoc;
            var path = playerPaths[Random.Range(0, playerPaths.Length)];
            cart.m_Path = path;
            cart.m_Position = 0;
        }
        else if (!m_isPlayerFoc)
        {
            cam.LookAt = enemyFoc;
            var path = enemyPaths[Random.Range(0, enemyPaths.Length)];
            cart.m_Path = path;
            cart.m_Position = 0;
        }

    }
}
