using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Falling_Stuff : Minigame
    {
        public GameObject bullet;
        public Transform[] spawnPoints;

        public bool canAttack;

        public void Start()
        {
            Invoke("ResetAttack", 1f);
        }

        protected override void Update()
        {
            base.Update();

            if(!Running) { return; }

            if (canAttack)
            {
                Attack();
            }
        }

        public void Attack()
        {
            canAttack = false;
            int y = Random.Range(0, spawnPoints.Length);

            GameObject bulletClone = Instantiate(bullet, spawnPoints[y].transform.position, transform.rotation);

            m_timeOutScore += 0.1f;

            Invoke("ResetAttack", 1f);
        }

        public void ResetAttack()
        {
            canAttack = true;
        }
    }
}
