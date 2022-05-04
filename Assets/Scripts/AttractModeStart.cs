using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    public class AttractModeStart : MonoBehaviour
    {
        public float m_timer, m_maxTime;

        public Animator m_cam_anim,m_canvas_anim;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void ResetTimer()
        {
            m_timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            

            if(m_timer >= m_maxTime)
            {
                m_cam_anim.SetBool("isAttract", true);
                m_canvas_anim.SetBool("isAttract", true);
            }
            else if(m_timer <= m_maxTime)
            {   
                m_timer += Time.deltaTime;
                m_cam_anim.SetBool("isAttract", false);
                m_canvas_anim.SetBool("isAttract", false);
            }
        }
    }
}
