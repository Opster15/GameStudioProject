using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSwitch : MonoBehaviour
{
    Cinemachine.CinemachineDollyCart cart;
    public Cinemachine.CinemachineSmoothPath startPath;
    public Cinemachine.CinemachineSmoothPath[] altPaths;

    private void Awake()
    {
        cart = GetComponent<Cinemachine.CinemachineDollyCart>();

        Reset();
    }

    private void Reset()
    {
        StopAllCoroutines();
        cart.m_Path = startPath;


        StartCoroutine(ChangeTrack());
    }

    IEnumerator ChangeTrack()
    {

        yield return new WaitForSeconds(Random.Range(5, 7));

        var path = altPaths[Random.Range(0, altPaths.Length)];
        cart.m_Path = path;
        cart.m_Position = 0;
        StartCoroutine(ChangeTrack());
    }
}
