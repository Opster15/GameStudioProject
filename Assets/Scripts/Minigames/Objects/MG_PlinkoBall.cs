using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_PlinkoBall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MG_Border"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                Destroy(gameObject);
                GetComponentInParent<MG_ChildCounter>().m_MaxChildren -= 1;
            }

            if (collision.gameObject.CompareTag("MG_Border_Kill"))
            {
                Destroy(gameObject);
                GetComponentInParent<MG_ChildCounter>().m_MaxChildren -= 1;
            }
        }
    }
}
