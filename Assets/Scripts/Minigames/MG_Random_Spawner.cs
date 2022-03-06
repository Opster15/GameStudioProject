using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Random_Spawner : Minigame
    {
        public GameObject m_objectHolder;
        public GameObject m_spawnedObject;
        public GameObject[] m_objects;
        // Start is called before the first frame update
        void Start()
        {
            int y = Random.Range(0, m_objects.Length);
            m_spawnedObject = m_objects[y];
            Instantiate(m_spawnedObject, m_objectHolder.transform);
        }


        protected override void Update()
        {
            base.Update();

            if (!Running) { return; }
        }
    }
}
