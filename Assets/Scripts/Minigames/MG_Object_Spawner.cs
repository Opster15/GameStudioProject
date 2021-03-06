using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Object_Spawner : Minigame
    {
        public GameObject m_player;
        public Transform[] spawnPoints;
        public GameObject[] m_objects;

        public bool m_aimedObject;

        bool m_canAttack = true;

        public float m_attack_speed;

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
            int x = Random.Range(0, m_objects.Length);

            //m_aimedObject true sets the spawned objects to spawn rotated towards player
            if (m_aimedObject)
            {
                Vector2 lookDir = m_player.transform.position - spawnPoints[y].transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                spawnPoints[y].rotation = Quaternion.Euler(0, 0, angle);

                GameObject objectClone = Instantiate(m_objects[x], spawnPoints[y].transform.position, spawnPoints[y].transform.rotation);
                objectClone.transform.parent = gameObject.transform;
            }
            else
            {
                GameObject bulletClone = Instantiate(m_objects[x], spawnPoints[y].transform.position, spawnPoints[y].transform.rotation);
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
