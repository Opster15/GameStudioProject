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

    FocusState state = FocusState.all;

    private void Awake()
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }


    public void ChangeTrack()
    {
        switch (state)
        {
            case FocusState.all:
                return;

            case FocusState.player:
                cam.LookAt = m_playerFoc;
                return;

            case FocusState.enemy:
                cam.LookAt = m_enemyFoc;
                return;
        }

    }
}
