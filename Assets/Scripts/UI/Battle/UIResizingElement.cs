using DG.Tweening;
using UnityEngine;
namespace GSP.UI.Battle
{
    public abstract class UIResizingElement : UICharacterTargetedElement
    {
        protected RectTransform m_rectTransform;

        [SerializeField] protected Vector2 m_closedSize;
        [SerializeField] protected Vector2 m_openSize;
        
        [SerializeField] protected float m_resizeTime;
        [SerializeField] private float m_resizeDelay;
        
        private Vector2 m_targetSize;
        private Sequence m_resizeSequence;

        protected virtual void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        protected void SetScale(bool _open)
        {
            if (m_resizeSequence is { active: true })
            {
                m_resizeSequence.Kill();
                m_rectTransform.sizeDelta = m_targetSize;
            }
            
            m_targetSize = _open ? m_openSize : m_closedSize;

            if (m_resizeTime > 0)
            {
                m_resizeSequence = DOTween.Sequence();
                if(m_resizeDelay > 0) { m_resizeSequence.AppendInterval(m_resizeDelay); }
                m_resizeSequence.Append(m_rectTransform.DOSizeDelta(m_targetSize, m_resizeTime));
                m_resizeSequence.Play();
            }
            else
            {
                m_rectTransform.sizeDelta = m_targetSize;
            }
        }
    }
}