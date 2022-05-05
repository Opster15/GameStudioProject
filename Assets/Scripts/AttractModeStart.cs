using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GSP.Battle;
namespace UnityEngine
{
    public class AttractModeStart : MonoBehaviour
    {
        public float m_timer, m_maxTime;

        public Animator m_cam_anim, m_canvas_anim, m_manager_anim;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            FindObjectOfType<BattleManager>().OnBattleEnd += OnBattleEnd;
        }

        private void OnDisable()
        {
            FindObjectOfType<BattleManager>().OnBattleEnd -= OnBattleEnd;
        }

        public void ResetTimer()
        {
            m_timer = 0;
        }

        private void OnBattleEnd()
        {
            SceneManager.LoadScene(0);
        }

        // Update is called once per frame
        void Update()
        {
            

            if(m_timer >= m_maxTime)
            {
                m_cam_anim.SetBool("isAttract", true);
                m_canvas_anim.SetBool("isAttract", true);
                m_manager_anim.SetBool("isAttract", true);
            }
            else if(m_timer <= m_maxTime)
            {   
                m_timer += Time.deltaTime;
                m_cam_anim.SetBool("isAttract", false);
                m_canvas_anim.SetBool("isAttract", false);
                m_manager_anim.SetBool("isAttract", false);
            }
        }
    }
}
