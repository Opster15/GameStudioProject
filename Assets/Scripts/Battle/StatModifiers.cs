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
            private class ModifierValue
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

            public Action<int> OnValueChanged;

            public int Value => m_summedValue;

            public void Tick()
            {
                foreach (var modifierValue in m_modifierValues)
                {
                    modifierValue.Tick();
                }
                m_modifierValues = m_modifierValues.Where(p => p.Value > 0).ToList();
                CalculateValue();

                OnValueChanged?.Invoke(Value);
            }

            public void AddModifier(int _modifier, int _duration)
            {
                m_modifierValues.Add(new ModifierValue(_modifier, _duration));
                CalculateValue();

                OnValueChanged?.Invoke(Value);
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

                OnValueChanged?.Invoke(Value);
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
            }
        }

        private readonly Modifier[] m_modifiers = new Modifier[Enum.GetValues(typeof(Stats)).Length];

        public Action<Stats, int> OnModifierChanged;

        public StatModifiers()
        {
            for (var i = 0; i < m_modifiers.Length; i++)
            {
                m_modifiers[i] = new Modifier();

                var stat = (Stats)i;
                m_modifiers[i].OnValueChanged += (value) => OnModifierValueChanged(stat, value);
            }
        }

        ~StatModifiers()
        {
            foreach (var statModifier in m_modifiers)
            {
                statModifier.OnValueChanged = null;
            }
        }

        public void Tick()
        {
            foreach (var statModifier in m_modifiers)
            {
                statModifier.Tick();
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

        private void OnModifierValueChanged(Stats _stat, int _value)
            => OnModifierChanged?.Invoke(_stat, _value);
    }
}