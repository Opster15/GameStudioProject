using System;
using UnityEngine;
using UnityEngine.UI;
namespace GSP.UI
{
    public class UIButton : MonoBehaviour
    {
        private Button m_button;

        private void Awake()
        {
            m_button = GetComponentInChildren<Button>();
        }

        public void SetClickAction(Action _onClick)
        {
            m_button.onClick.RemoveAllListeners();
            m_button.onClick.AddListener(() => _onClick?.Invoke());
        }
    }
}
