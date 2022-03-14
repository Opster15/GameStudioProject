using TMPro;
using UnityEngine;
namespace GSP
{
    public class DamageIndicator : MonoBehaviour, ISpawnedOnHealthChange
    {
        private TMP_Text m_text;

        [SerializeField] private Color m_healColor;
        [SerializeField] private Color m_damageColor;

        [SerializeField] private float m_minFloatSpeed;
        [SerializeField] private float m_maxFloatSpeed;
        [SerializeField] private float m_lifetime;

        private float m_floatSpeed;
        private float m_timer;

        private void Awake()
        {
            m_text = GetComponent<TMP_Text>();

            m_floatSpeed = Random.Range(m_minFloatSpeed, m_maxFloatSpeed);
        }

        private void Update()
        {
            m_timer += Time.deltaTime;
            if(m_timer > m_lifetime) { Destroy(gameObject); }
            else
            {
                transform.position += Vector3.up * m_floatSpeed * Time.deltaTime;
                var color = m_text.color;
                color.a = 1 - Mathf.Clamp(m_timer / m_lifetime, 0, 1);
                m_text.color = color;
            }
        }

        public void SetAmount(int _amount)
        {
            var positive = _amount > 0;
            m_text.text = (positive ? "-" : "+") + Mathf.Abs(_amount);
            m_text.color = positive ? m_damageColor : m_healColor;
        }
    }
}
