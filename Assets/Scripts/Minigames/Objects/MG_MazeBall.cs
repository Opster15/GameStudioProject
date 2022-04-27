using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GSP.Minigames
{
    public class MG_MazeBall : MonoBehaviour
    {
        public GameObject m_particle;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MG_Border"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                GameObject particleClone = Instantiate(m_particle, transform.position, transform.rotation);
                Destroy(particleClone, 0.2f);
                GetComponentInParent<Minigame>().m_timer = GetComponentInParent<Minigame>().Length - 0.2f;
                Destroy(gameObject);
            }
        }
    }
}
