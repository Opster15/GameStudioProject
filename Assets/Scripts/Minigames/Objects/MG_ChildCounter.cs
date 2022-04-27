using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_ChildCounter : MonoBehaviour
    {

        public int m_MaxChildren;

        public void Update()
        {
            if(m_MaxChildren == 0)
            {
                GetComponentInParent<Minigame>().m_timer = GetComponentInParent<Minigame>().Length - 0.2f;
                Destroy(gameObject);
            }
        }
    }
}
