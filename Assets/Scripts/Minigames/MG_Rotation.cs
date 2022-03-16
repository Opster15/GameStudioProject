using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Rotation : MonoBehaviour
    {
        InputManager inputManager;

        public GameObject m_objectHolder;

        public float m_rotationSpeed;

        float x;
        void Start()
        {
            inputManager = GetComponent<InputManager>();
        }

        void FixedUpdate()
        {
            Input();
            DirectionInput();
        }


        public void Input()
        {
            //rotates spawned object from x input
            m_objectHolder.transform.Rotate(0, 0, m_rotationSpeed * -x);
        }

        public void DirectionInput()
        {
            x = inputManager.Movement.x;
        }

    }
}
