using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSwitch : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera cam;

    public Transform m_playerFoc, m_enemyFoc,m_allFoc;

    public enum FocusState
    {
        enemy,
        player,
        all
    }

    public FocusState state = FocusState.all;


    private void Awake()
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }


    public void Update()
    {

        if(state == FocusState.all)
        {
            cam.m_LookAt = m_allFoc;
        }

        if (state == FocusState.enemy)
        {
            cam.m_LookAt = m_enemyFoc;
        }

        if (state == FocusState.player)
        {
            cam.m_LookAt = m_playerFoc;
        }

    }
}
