using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_PickupObject : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MG_Border"))
            {
                GetComponentInParent<MG_Falling_Stuff>().ChangeScore();
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
