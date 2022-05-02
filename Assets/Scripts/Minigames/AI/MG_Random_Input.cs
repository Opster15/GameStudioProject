using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Random_Input : MonoBehaviour
    {
        private MG_Basic_Movement m_bm;

        public bool m_xInput, m_yInput;

        private float m_resetTime;

        public float m_xOutput, m_yOutput;

        // Start is called before the first frame update
        void Start()
        {
            m_bm = GetComponent<MG_Basic_Movement>();
            ChangeMovement();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            m_resetTime -= Time.deltaTime;

            if(m_resetTime <= 0)
            {
                ChangeMovement();
            }

            if (m_xInput)
            {
                m_bm.x = m_xOutput;
            }

            if (m_yInput)
            {
                m_bm.y = m_yOutput;
            }
        }

        void ChangeMovement()
        {
            m_xOutput = Random.Range(-1f, 1f);

            m_yOutput = Random.Range(-1f, 1f);

            m_resetTime = 0.5f;
        }
    }
}
