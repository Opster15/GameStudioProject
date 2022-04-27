using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Bullet : MonoBehaviour
    {
        Rigidbody2D rb;

        public GameObject m_Particle;

        public bool m_destoryOnBorderHit;

        public float m_speed,m_maxLifetime;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * m_speed, ForceMode2D.Impulse);
        }


        public void Update()
        {
            m_maxLifetime -= Time.deltaTime;
            if(m_maxLifetime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                GameObject particleClone = Instantiate(m_Particle, transform.position, transform.rotation);
                Destroy(particleClone, 0.2f);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("MG_Border"))
            {
                if (m_destoryOnBorderHit)
                {
                    Destroy(gameObject);
                }
 
            }
        }
    }
}
