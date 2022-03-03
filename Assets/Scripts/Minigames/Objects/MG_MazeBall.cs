using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GSP.Minigames
{
    public class MG_MazeBall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MG_Border"))
            {
                GetComponentInParent<Minigame>().ChangeScore();
                GetComponentInParent<Minigame>().m_timer = GetComponentInParent<Minigame>().Length;
                Destroy(gameObject);
            }
        }
    }
}
