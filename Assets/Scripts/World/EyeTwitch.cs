using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GSP
{
    public class EyeTwitch : MonoBehaviour
    {
        [SerializeField] private Transform[] m_eyes;

        [SerializeField] private Vector2 m_lookTimeDelay;
        [SerializeField] private Vector2 m_lookTimeRange;
        [SerializeField] private Vector2 m_lookTimeVariance;

        [SerializeField] private Vector3 m_minTarget, m_maxTarget;

        private void Start()
        {
            foreach (var eye in m_eyes)
            {
                eye.LookAt(new Vector3(Random.Range(m_minTarget.x, m_maxTarget.x), Random.Range(m_minTarget.y, m_maxTarget.y), Random.Range(m_minTarget.z, m_maxTarget.z)));
            }
            StartCoroutine(LookCycle());
        }

        private IEnumerator LookCycle()
        {
            yield return new WaitForSeconds(Random.Range(m_lookTimeDelay.x, m_lookTimeDelay.y));
            LookAt(new Vector3(Random.Range(m_minTarget.x, m_maxTarget.x), Random.Range(m_minTarget.y, m_maxTarget.y), Random.Range(m_minTarget.z, m_maxTarget.z)), Random.Range(m_lookTimeRange.x, m_lookTimeRange.y));
            StartCoroutine(LookCycle());
        }

        private void LookAt(Vector3 _target, float _time)
        {
            foreach(var eye in m_eyes)
            {
                eye.DOLookAt(_target, _time * Random.Range(m_lookTimeVariance.x, m_lookTimeVariance.y));
            }
        }
    }
}
