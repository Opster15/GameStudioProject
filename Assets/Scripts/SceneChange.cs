using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GSP
{
    public class SceneChange : MonoBehaviour
    {
        private int m_random;

        private void Start()
        {
            m_random = Random.Range(4, 9);
            Invoke("PlayGame", 2f);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(m_random);
        }
    }
}
