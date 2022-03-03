using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Bullet : MonoBehaviour
    {
        Rigidbody2D rb;

        public float m_speed;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * m_speed, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("MG_Border"))
            {
                Destroy(gameObject);
            }
        }
    }
}
