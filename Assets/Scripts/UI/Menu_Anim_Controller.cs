using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class Menu_Anim_Controller : MonoBehaviour
    {

        Animator m_anim;
        // Start is called before the first frame update
        void Start()
        {
            m_anim = GetComponent<Animator>();
        }


        public void ChangeBoolTrue(string name)
        {
            m_anim.SetBool(name, true);
        }

        public void ChangeBoolFalse(string name)
        {
            m_anim.SetBool(name, false);
        }
    }
}
