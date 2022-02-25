using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Player_Character : MonoBehaviour
    {
        InputManager inputManager;
        Rigidbody2D rb;

        //Controls directions to move
        public float m_XmoveSpeed;
        public float m_YmoveSpeed;

        float x, y;
        void Start()
        {
            inputManager = GetComponent<InputManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            DirectionInput();
            Input();
        }

        public void DirectionInput()
        {
            x = inputManager.Movement.x;
            y = inputManager.Movement.y;
        }

        public void Input()
        {
            rb.velocity = new Vector2(x * m_XmoveSpeed, y * m_YmoveSpeed);
        }
    }
}
