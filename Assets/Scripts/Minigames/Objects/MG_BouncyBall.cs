using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_BouncyBall : MonoBehaviour
    {
        public bool scoreOnPlayerHit, scoreOnBorderHit;

        Rigidbody2D rb;

        public float m_bounceRange;

        float m_bounce;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            m_bounce = Random.Range(-m_bounceRange, m_bounceRange);
            rb.velocity = new Vector2(m_bounce, rb.velocity.y);
            if (scoreOnBorderHit)
            {
                if (collision.gameObject.CompareTag("MG_Border_Kill"))
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
            }

            if (scoreOnPlayerHit)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
            }
        }

    }
}
