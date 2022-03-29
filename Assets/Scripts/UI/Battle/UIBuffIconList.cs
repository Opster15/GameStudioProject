using System;
using System.Collections.Generic;
using GSP.Battle;
using UnityEngine;
using UnityEngine.UI;
namespace GSP.UI.Battle
{
    public class UIBuffIconList : CharacterTargetedElement
    {
        [Serializable]
        private struct BuffIconSprite
        {
            [SerializeField] private string m_key;
            [SerializeField] private Sprite m_icon;

            public string Key => m_key;

            public Sprite Icon => m_icon;
        }

        [SerializeField] private BuffIconSprite[] m_buffIconSpriteValues;

        [SerializeField] private GameObject m_buffIconPrefab;

        private Dictionary<string, Sprite> m_buffIconSprites = new Dictionary<string, Sprite>();

        private Dictionary<string, Image> m_activeIcons = new Dictionary<string, Image>();
        private Queue<Image> m_inactiveIcons = new Queue<Image>();

        private void Awake()
        {
            foreach(var iconValue in m_buffIconSpriteValues)
            {
                m_buffIconSprites.Add(iconValue.Key, iconValue.Icon);
            }
        }

        private void OnDisable()
        {
            if(m_target == null) { return; }
            m_target.StatModifiers.OnModifierChanged -= OnStatModifierChanged;
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            if (m_target == null) { return; }
            m_target.StatModifiers.OnModifierChanged += OnStatModifierChanged;
        }

        private void OnStatModifierChanged(Stats _stat, int _value)
        {
            Debug.Log(_stat);
            string keyPrefix = "StatModifier_" + Enum.GetName(typeof(Stats), _stat);

            if (_value <= 0) { RemoveKey(keyPrefix + "_Up"); }
            else { AddKey(keyPrefix + "_Up"); }

            if (_value >= 0) { RemoveKey(keyPrefix + "_Down"); }
            else { AddKey(keyPrefix + "_Down"); }
        }

        private void AddKey(string _key)
        {
            Debug.Log(_key);
            if (m_activeIcons.TryGetValue(_key, out _) || !m_buffIconSprites.TryGetValue(_key, out var buffIconSprite)) { return; }

            var buffIcon = GetBuffIcon();
            buffIcon.sprite = buffIconSprite;

            m_activeIcons.Add(_key, buffIcon);
        }

        private void RemoveKey(string _key)
        {
            if(!m_activeIcons.TryGetValue(_key, out var value)) { return; }

            m_activeIcons.Remove(_key);
            m_inactiveIcons.Enqueue(value);

            value.gameObject.SetActive(false);
        }

        /// <summary>
        /// Either receives a UI buff icon prefab from the inactive queue, or creates a new one if none are available.
        /// </summary>
        /// <returns>A UI buff icon prefab.</returns>
        private Image GetBuffIcon()
        {
            Image buffIcon;
            if(m_inactiveIcons.Count > 0)
            {
                buffIcon = m_inactiveIcons.Dequeue();
                buffIcon.gameObject.SetActive(true);
            }
            else
            {
                buffIcon = Instantiate(m_buffIconPrefab, transform).GetComponent<Image>();
            }
            return buffIcon;
        }
    }
}
