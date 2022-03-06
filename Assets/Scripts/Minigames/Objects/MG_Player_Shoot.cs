using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Player_Shoot : MonoBehaviour
    {
        InputManager inputManager;
        public GameObject bullet;
        public Transform shootPoint;

        bool m_canAttack;

        public float m_attackSpeed;


        private void Start()
        {
            m_canAttack = true;
            inputManager = GetComponent<InputManager>();
        }


        private void Update()
        {
            if (inputManager.spacePressed && m_canAttack)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            m_canAttack = false;
            GameObject bulletClone = Instantiate(bullet, shootPoint.position, transform.rotation);
            bulletClone.transform.parent = gameObject.transform;
            Invoke("ResetAttack", m_attackSpeed);
        }

        void ResetAttack()
        {
            m_canAttack = true;
        }
    }
}
