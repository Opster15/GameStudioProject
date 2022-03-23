using UnityEngine;
using UnityEngine.SceneManagement;
namespace GSP
{
    public class ResetTimer : MonoBehaviour
    {
        [SerializeField] private float m_length;

        private float m_timer;

        private int m_random;

        private void Start()
        {
            m_random = Random.Range(1, 6);
        }

        void Update()
        {
            m_timer += Time.deltaTime;
            if(m_timer < m_length) { return; }
            SceneManager.LoadScene(m_random);
        }
    }
}
