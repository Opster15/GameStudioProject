using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GSP.Battle
{
    public class StatModifiers
    {
        private class Modifier
        {
            private struct ModifierValue
            {
                private int m_value;
                private int m_duration;

                public int Value => m_value;

                public ModifierValue(int _value, int _duration)
                {
                    m_value = _value;
                    m_duration = _duration;
                }
                
                public void Tick()
                {
                    m_duration--;
                    if (m_duration >= 1) { return; }
                    
                    m_value = 0;
                    m_duration = 0;
                }
            }

            private const int c_maxValue = 5;

            private List<ModifierValue> m_modifierValues = new List<ModifierValue>();

            private int m_summedValue;
            private bool m_dirty;

            public int Value
            {
                get
                {
                    if(m_dirty) { CalculateValue(); }
                    return m_summedValue;
                }
            }

            public void Tick()
            {
                foreach (var modifierValue in m_modifierValues)
                {
                    modifierValue.Tick();
                }
                m_modifierValues = m_modifierValues.Where(p => p.Value > 0).ToList();
            }

            public void AddModifier(int _modifier, int _duration)
            {
                m_modifierValues.Add(new ModifierValue(_modifier, _duration));
                m_dirty = true;
            }

            public void SetModifier(int _modifier, int _duration)
            {
                ResetModifier();
                AddModifier(_modifier, _duration);
            }

            public void ResetModifier()
            {
                m_summedValue = 0;
                m_modifierValues.Clear();
                
                m_dirty = false;
            }

            private void CalculateValue()
            {
                m_summedValue = 0;
                foreach (var modifierValue in m_modifierValues)
                {
                    m_summedValue += modifierValue.Value;
                }
                m_summedValue = Mathf.Clamp(m_summedValue, -c_maxValue, c_maxValue);

                if (m_summedValue == 0 && m_modifierValues.Count < 0) { ResetModifier(); }
                m_dirty = false;
            }
        }

        private readonly Modifier[] m_modifiers = new Modifier[Enum.GetValues(typeof(Stats)).Length];

        public StatModifiers()
        {
            for (var i = 0; i < m_modifiers.Length; i++)
            {
                m_modifiers[i] = new Modifier();
            }
        }

        public void Tick()
        {
            foreach (var statBuff in m_modifiers)
            {
                statBuff.Tick();
            }
        }

        public int GetModifierValue(Stats _stat)
            => GetModifier(_stat).Value;

        public void AddModifier(Stats _stat, int _modifier, int _duration)
            => GetModifier(_stat).AddModifier(_modifier, _duration);

        public void SetModifier(Stats _stat, int _modifier, int _duration)
            => GetModifier(_stat).SetModifier(_modifier, _duration);

        public void ResetModifier(Stats _stat)
            => GetModifier(_stat).ResetModifier();

        private Modifier GetModifier(Stats _stat)
            => m_modifiers[(int)_stat];
    }
}