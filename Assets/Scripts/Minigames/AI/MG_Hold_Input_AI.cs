using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Hold_Input_AI : MonoBehaviour
    {
        private MG_Rotation m_rotate;

        public bool m_xInput;

        public float m_inputvalue;

        private void Awake()
        {
            m_rotate = GetComponent<MG_Rotation>();
        }

        private void Update()
        {
            if (m_xInput)
            {
                m_rotate.x = m_inputvalue;
            }
            else if (!m_xInput)
            {
                m_rotate.x = m_inputvalue;
            }
            
        }
    }
}
