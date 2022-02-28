using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Pickup_Object : MonoBehaviour
    {
        
        public bool scoreOnPlayerHit,scoreOnBorderHit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MG_Border"))
            {
                if (scoreOnBorderHit)
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
                Destroy(gameObject);
            }

            if (collision.CompareTag("Player"))
            {
                if (scoreOnPlayerHit)
                {
                    GetComponentInParent<Minigame>().ChangeScore();
                }
                Destroy(gameObject);
            }
        }
    }
}
