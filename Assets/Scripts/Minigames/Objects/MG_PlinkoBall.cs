using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_PlinkoBall : MonoBehaviour
    {
        public GameObject m_lossParticle;

        public GameObject m_gainParticle;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MG_Border"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                GameObject particleClone = Instantiate(m_gainParticle, transform.position, transform.rotation);
                Destroy(particleClone, 0.2f);
                Destroy(gameObject);
                GetComponentInParent<MG_ChildCounter>().m_MaxChildren -= 1;
            }

            if (collision.gameObject.CompareTag("MG_Border_Kill"))
            {
                GameObject particleClone = Instantiate(m_lossParticle, transform.position, transform.rotation);
                Destroy(particleClone, 0.2f);
                Destroy(gameObject);
                GetComponentInParent<MG_ChildCounter>().m_MaxChildren -= 1;
            }
        }
    }
}
