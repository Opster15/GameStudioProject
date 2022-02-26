using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{

    public class BouncyBall : MonoBehaviour
    {

        Rigidbody2D rb;

        float m_bounce;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            m_bounce = Random.Range(-3.0f, 3.0f);
            rb.velocity = new Vector2(m_bounce, rb.velocity.y);

            if (collision.gameObject.CompareTag("MG_Border_Kill"))
            {
                GetComponentInParent<MG_Object_Spawner>().ChangeScore();
            }
        }

    }
}
