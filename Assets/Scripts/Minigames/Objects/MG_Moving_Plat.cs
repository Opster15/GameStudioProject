using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Moving_Plat : MonoBehaviour
    {
        public Transform m_startPos, m_endPos, m_origParent;
        public float m_speed;
        Vector3 m_nextPos, v;

        private void Start()
        {
            m_nextPos = m_startPos.localPosition;

            m_speed = Random.Range(5f, 12f);
        }

        public void Update()
        {
            if (transform.localPosition == m_startPos.localPosition)
            {
                m_nextPos = m_endPos.localPosition;
            }
            else if (transform.localPosition == m_endPos.localPosition)
            {
                m_nextPos = m_startPos.localPosition;
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, m_nextPos, m_speed * Time.deltaTime);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.SetParent(transform);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.SetParent(m_origParent);
            }
        }


    }
}
