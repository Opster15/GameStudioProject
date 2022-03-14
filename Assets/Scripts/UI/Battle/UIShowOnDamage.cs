using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GSP.UI.Battle;
using UnityEngine;
using UnityEngine.UI;

namespace GSP
{
    public class UIShowOnDamage : MonoBehaviour
    {
        private UIHealthBar m_healthBar;

        private Graphic[] m_graphics;

        [SerializeField] private float m_fadeInTime;
        
        [SerializeField] private float m_fadeOutDelay;
        [SerializeField] private float m_fadeOutTime;

        private bool m_wasTakingDamage;

        private Sequence m_fadeSequence;
        
        private void Awake()
        {
            m_healthBar = GetComponent<UIHealthBar>();

            m_graphics = GetComponentsInChildren<Graphic>();
            foreach (var graphic in m_graphics)
            {
                var color = graphic.color;
                color.a = 0;
                graphic.color = color;
            }
        }

        private void Update()
        {
            if (m_healthBar.TakingDamage == m_wasTakingDamage) { return; }
            m_wasTakingDamage = m_healthBar.TakingDamage;

            if (m_fadeSequence is { active: true })
            {
                m_fadeSequence.Kill();
            }
            
            m_fadeSequence = DOTween.Sequence();
            foreach (var graphic in m_graphics)
            {
                m_fadeSequence.Insert(0, graphic.DOFade(m_wasTakingDamage ? 1 : 0, m_wasTakingDamage ? m_fadeInTime : m_fadeOutTime));
            }
            if (!m_wasTakingDamage) { m_fadeSequence.PrependInterval(m_fadeOutDelay); }
            m_fadeSequence.Play();
        }
    }
}
