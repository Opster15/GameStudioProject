using UnityEngine;
using UnityEngine.SceneManagement;
namespace GSP
{
    public class ResetTimer : MonoBehaviour
    {
        [SerializeField] private float m_length;

        private float m_timer;

        void Update()
        {
            m_timer += Time.deltaTime;
            if(m_timer < m_length) { return; }
            SceneManager.LoadScene(0);
        }
    }
}
