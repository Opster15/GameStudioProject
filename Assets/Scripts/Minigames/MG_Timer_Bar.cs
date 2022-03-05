using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Timer_Bar : MonoBehaviour
    {
        public GameObject m_fill;
        SpriteRenderer m_fillSprite;

        public Gradient m_gradient;
        Minigame minigame;


        private void Start()
        {
            minigame = GetComponentInParent<Minigame>();
            m_fillSprite = m_fill.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            m_fillSprite.color = m_gradient.Evaluate(minigame.TimeTaken);
            m_fill.transform.localScale = new Vector3(1 - minigame.TimeTaken, 1, 1);
        }
    }
}
