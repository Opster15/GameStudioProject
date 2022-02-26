using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Rotation : Minigame
    {
        InputManager inputManager;

        public GameObject m_objectHolder;
        public GameObject m_spawnedObject;
        public GameObject[] m_objects;

        public float m_rotationSpeed;

        float x;
        void Start()
        {
            inputManager = GetComponent<InputManager>();
            int y = Random.Range(0, m_objects.Length);
            m_spawnedObject = m_objects[y];
            GameObject ObjectClone = Instantiate(m_spawnedObject, m_objectHolder.transform);
        }

        protected override void Update()
        {
            base.Update();

            if (!Running) { return; }

            Input();
            DirectionInput();
        }


        public void Input()
        {
            m_objectHolder.transform.Rotate(0, 0, m_rotationSpeed * -x);
        }

        public void DirectionInput()
        {
            x = inputManager.Movement.x;
        }

    }
}
