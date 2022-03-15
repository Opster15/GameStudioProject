using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private Vector3 m_rotationAngles;

        [SerializeField] private float m_hoverSpeed;
        [SerializeField] private float m_hoverDelay;
        [SerializeField] private Vector3 m_hoverAmount;

        private Vector3 m_startingPosition;

        private void Awake()
        {
            m_startingPosition = transform.localPosition;
        }

        void Update()
        {
            transform.Rotate(m_rotationAngles * Time.deltaTime);
            transform.localPosition = m_hoverAmount * Mathf.Sin(Time.time * m_hoverSpeed + m_hoverDelay) + m_startingPosition;
        }
    }
}
