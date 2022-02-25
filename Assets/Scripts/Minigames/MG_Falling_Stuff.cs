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

        public float m_point_gain;
        public float m_starting_point;
        public float m_attack_speed;

        public void Start()
        {
            Invoke("ResetAttack", 0.1f);
            m_timeOutScore = m_starting_point;
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

            Invoke("ResetAttack", m_attack_speed);
        }

        public void ResetAttack()
        {
            canAttack = true;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                m_timeOutScore += m_point_gain;
                Destroy(collision.gameObject);
            }

        }
    }
}
