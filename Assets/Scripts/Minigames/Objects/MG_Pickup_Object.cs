using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Pickup_Object : MonoBehaviour
    {
        
        public bool m_scoreOnPlayerHit,m_scoreOnBorderHit,m_scoreOnBulletHit,m_gameEndPickup,m_multipleChild;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MG_Border"))
            {
                if (m_scoreOnBorderHit)
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
                Destroy(gameObject);
            }

            if (collision.CompareTag("Player"))
            {
                if (m_scoreOnPlayerHit)
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
                Destroy(gameObject);
            }

            if (collision.CompareTag("Bullet"))
            {
                if (m_scoreOnBulletHit)
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }

                if (m_multipleChild)
                {
                    GetComponentInParent<MG_ChildCounter>().m_MaxChildren -= 1;
                }
                Destroy(gameObject);
            }

            if (m_gameEndPickup)
            {
                GetComponentInParent<Minigame>().m_timer = GetComponentInParent<Minigame>().Length;
            }

            if (collision.CompareTag("MG_Border_Kill"))
            {
                Destroy(gameObject);
            }
        }
    }
}
