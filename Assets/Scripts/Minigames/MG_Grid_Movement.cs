using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Grid_Movement : MonoBehaviour
    {
        InputManager inputManager;
        Rigidbody2D rb;

        public LayerMask whatIsCollision;

        public Transform[] movePos;
        Vector3 origPos, targetPos;

        public float m_moveDist;


        public bool canMove, isMoving;
        bool canLeft, canRight, canUp, canDown;

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
            DetectCollision();
        }
        private void LateUpdate()
        {
            if (canMove)
            {
                Input();
            }
        }

        public void DirectionInput()
        {
            x = inputManager.Movement.x;
            y = inputManager.Movement.y;
        }

        public void Input()
        {
            if (!isMoving && !inputManager.spacePress)
            {
                if (y == 1 && canUp)
                {
                    MovePlayer(Vector3.up * m_moveDist);
                }
                if (x == 1 && canRight)
                {
                    MovePlayer(Vector3.right * m_moveDist);
                }
                if (y == -1 && canDown)
                {
                    MovePlayer(Vector3.down * m_moveDist);
                }
                if (x == -1 && canLeft)
                {
                    MovePlayer(Vector3.left * m_moveDist);
                }
            }

            canMove = false;
            Invoke("ResetMove", 0.2f);
        }

        public void MovePlayer(Vector3 dir)
        {
            origPos = transform.position;
            targetPos = origPos + dir;

            transform.position = targetPos;
        }

        void ResetMove()
        {
            canMove = true;
        }

        public void DetectCollision()
        {
            canUp = !Physics2D.OverlapCircle(movePos[0].position, 0.1f, whatIsCollision);
            canRight = !Physics2D.OverlapCircle(movePos[1].position, 0.1f, whatIsCollision);
            canDown = !Physics2D.OverlapCircle(movePos[2].position, 0.1f, whatIsCollision);
            canLeft = !Physics2D.OverlapCircle(movePos[3].position, 0.1f, whatIsCollision);
        }
    }
}
