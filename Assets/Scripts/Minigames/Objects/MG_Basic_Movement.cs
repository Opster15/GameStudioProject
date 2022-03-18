using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Basic_Movement : MonoBehaviour
    {
        Rigidbody2D rb;
        InputManager inputManager;

        public float m_moveSpeedX,m_moveSpeedY;

        float x, y;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            inputManager = GetComponent<InputManager>();
        }

        public void Update()
        {
            DirectionInput();
        }

        private void LateUpdate()
        {
            Input();
        }

        public void DirectionInput()
        {
            x = inputManager.Movement.x;
            y = inputManager.Movement.y;
        }

        public void Input()
        {
            rb.velocity = new Vector2(m_moveSpeedX * x, m_moveSpeedY * y);
        }
    }
}

