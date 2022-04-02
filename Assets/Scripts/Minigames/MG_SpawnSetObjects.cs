using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_SpawnSetObjects : Minigame
    {
        public GameObject m_spawnedObject;
        public GameObject m_parent;
        public Transform[] spawnPoints;

        bool canSpawn = true;


        protected override void Update()
        {
            base.Update();

            if (!Running) { return; }

            if (canSpawn)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject objectClone = Instantiate(m_spawnedObject, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                objectClone.transform.parent = m_parent.transform;
            }

            canSpawn = false;
        }
    }
}
