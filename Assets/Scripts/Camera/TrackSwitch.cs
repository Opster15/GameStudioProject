using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class TrackSwitch : MonoBehaviour
{
    public GameObject camObj;
    Cinemachine.CinemachineVirtualCamera cineCam;

    public Transform[] m_camFocus;
    public Transform[] m_camPos;
    //order of array is All,Enemy,Player

    public enum FocusState
    {
        enemy,
        player,
        all
    }

    public FocusState state = FocusState.all;


    private void Awake()
    {
        cineCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }


    public void Update()
    {

        if(state == FocusState.all)
        {
            cineCam.m_LookAt = m_camFocus[0];
            camObj.transform.DOMove(m_camPos[0].position, 1);
        }

        if (state == FocusState.enemy)
        {
            cineCam.m_LookAt = m_camFocus[1];
            camObj.transform.DOMove(m_camPos[1].position, 1);
        }

        if (state == FocusState.player)
        {
            cineCam.m_LookAt = m_camFocus[2];
            camObj.transform.DOMove(m_camPos[2].position, 1);
        }

    }
}
