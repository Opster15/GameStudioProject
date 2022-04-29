using System;
using GSP.Battle;
using UnityEngine;
using UnityEngine.UI;
namespace GSP.UI.Battle
{
    public class UIMoveIsUsable : UIMoveTargetedElement
    {
        private Graphic m_graphic;

        [SerializeField] private bool m_showOnUsable;
        [SerializeField] private float m_activeAlpha;

        private bool m_shown;

        private void Awake()
        {
            m_graphic = GetComponent<Graphic>();
        }

        private void Start()
        {
            AdjustAlpha();
        }

        private void Update()
        {
            var show = m_target.IsUsable == m_showOnUsable;
            if (m_shown == show) { return; }
            
            m_shown = show;
            AdjustAlpha();
        }

        private void AdjustAlpha()
        {
            var color = m_graphic.color;
            color.a = m_shown ? m_activeAlpha : 0;
            m_graphic.color = color;
        }
    }
}