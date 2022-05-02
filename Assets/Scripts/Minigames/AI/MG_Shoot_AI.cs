using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Shoot_AI : MonoBehaviour
    {
        private MG_Player_Shoot m_ps;

        private float m_resetTime;
        // Start is called before the first frame update
        void Start()
        {
            m_ps = GetComponent<MG_Player_Shoot>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            m_resetTime -= Time.deltaTime;

            if (m_resetTime <= 0)
            {
                m_ps.Shoot();
                m_resetTime = 0.4f;
            }
        }
    }
}
