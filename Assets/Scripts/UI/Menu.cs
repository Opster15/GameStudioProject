using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GSP
{
    public class Menu : MonoBehaviour
    {
        private int m_random;

        public float m_delay;

        private void Start()
        {
            m_random = Random.Range(3, 8);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(m_random);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void DelayStart()
        {
            Invoke("PlayGame", m_delay);
        }
    }
}
