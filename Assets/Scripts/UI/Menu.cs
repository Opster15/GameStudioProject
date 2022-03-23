using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GSP
{
    public class Menu : MonoBehaviour
    {
        private int m_random;

        private void Start()
        {
            m_random = Random.Range(3, 7);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(m_random);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
