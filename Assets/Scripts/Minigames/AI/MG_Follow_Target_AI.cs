using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Follow_Target_AI : MonoBehaviour
    {
        private MG_Basic_Movement m_bm;

        public Transform m_followObj;

        public bool m_YInput;


        private void Start()
        {
            m_bm = GetComponent<MG_Basic_Movement>();
        }
        // Update is called once per frame
        void LateUpdate()
        {
            if(m_followObj != null)
            {
                if (m_YInput)
                {
                    if (m_followObj.transform.position.y > transform.position.y)
                    {
                        m_bm.y = 1;
                    }
                    else if (m_followObj.transform.position.y < transform.position.y)
                    {
                        m_bm.y = -1;
                    }
                }
                else if (!m_YInput)
                {
                    if (m_followObj.transform.position.x > transform.position.x)
                    {
                        m_bm.x = 1;
                    }
                    else if (m_followObj.transform.position.x < transform.position.x)
                    {
                        m_bm.x = -1;
                    }
                }

                
            }
            else if (m_followObj == null)
            {
                m_followObj = GameObject.FindGameObjectWithTag("Ball").transform;
            }

        }
    }
}
