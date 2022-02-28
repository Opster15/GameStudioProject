using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Object_Spawner : Minigame
    {
        
        public GameObject m_spawnedObject;
        public GameObject m_player;
        public Transform[] spawnPoints;

        public bool m_canAttack, m_aimedObject;

        public float m_starting_point;
        public float m_attack_speed;

        public void Start()
        {
            Invoke("ResetAttack", 0.1f);
        }

        protected override void Update()
        {
            base.Update();

            if(!Running) { return; }

            if (m_canAttack)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            m_canAttack = false;
            int y = Random.Range(0, spawnPoints.Length);

            //if you want the objects to spawn looking at the player set m_aimedObject true
            if (m_aimedObject)
            {
                Vector2 lookDir = m_player.transform.position - spawnPoints[y].transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                spawnPoints[y].rotation = Quaternion.Euler(0, 0, angle);

                GameObject bulletClone = Instantiate(m_spawnedObject, spawnPoints[y].transform.position, spawnPoints[y].transform.rotation);
                bulletClone.transform.parent = gameObject.transform;
            }
            else
            {
                GameObject bulletClone = Instantiate(m_spawnedObject, spawnPoints[y].transform.position, transform.rotation);
                bulletClone.transform.parent = gameObject.transform;
            }

            Invoke("ResetAttack", m_attack_speed);
        }

        public void ResetAttack()
        {
            m_canAttack = true;
        }
    }
}
