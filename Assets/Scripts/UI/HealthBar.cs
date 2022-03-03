using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GSP.Minigames
{
    public class HealthBar : MonoBehaviour
    {

        public Slider m_slider;
        public int m_health;
        //public PlayerHealth playerHealth;

        //sets health at the start of the level
        public void SetMaxHealth(int health)
        {
            m_slider.maxValue = health;
            m_slider.value = health;
        }


        //changes the health bar to match the amount of health
        //and uses Lerp to have a smooth transition
        private void Update()
        {
            //m_health = playerHealth.currentHealth;
            m_slider.value = Mathf.Lerp(m_slider.value, m_health, Time.deltaTime * 10f);
        }
    }
}
