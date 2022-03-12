using System.Collections.Generic;
using DG.Tweening;
using GSP.Battle;
using GSP.Battle.Controller;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UITargetList : UIResizingElement
    {
        private PlayerBattleController m_playerBattleController;
        
        private List<UICharacter> m_targets;
        
        private RectTransform m_containerTransform;

        [SerializeField] private GameObject m_targetPrefab;

        [SerializeField] private Transform m_targetParent;

        [SerializeField] private int m_targetHeight;
        [SerializeField] private int m_targetPaddingHeight;

        [SerializeField] private float m_targetResizeTime;

        private Vector2 m_rectSize;

        protected override void Awake()
        {
            base.Awake();
            m_targets = new List<UICharacter>();
            
            m_playerBattleController = FindObjectOfType<PlayerBattleController>();

            m_containerTransform = m_rectTransform.GetChild(0).GetComponent<RectTransform>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            if (m_target != null) { m_target.OnTargeting -= OnCharacterTargeting; }
            base.SetTarget(_target);
            if (_target != null) { _target.OnTargeting += OnCharacterTargeting; }
        }

        private void OnCharacterTargeting(List<GameCharacter> _targetOptions)
        {
            var targetCount = 0;
            var uiTargetCount = m_targets.Count;
            if (_targetOptions != null) { targetCount = _targetOptions.Count; }

            var hideObjectSequence = DOTween.Sequence();
            for (var i = 0; i < Mathf.Max(targetCount, uiTargetCount); i++)
            {
                UICharacter target;
                if (i < targetCount)
                {
                    if (i < uiTargetCount)
                    {
                        target = m_targets[i];
                        target.gameObject.SetActive(true);
                    }
                    else
                    {
                        var moveObject = Instantiate(m_targetPrefab, m_targetParent);
                        target = moveObject.GetComponent<UICharacter>();
                        m_targets.Add(target);
                    }
                    
                    var id = i;
                    target.SetTarget(_targetOptions?[i]);
                    target.GetComponent<UIButton>().SetClickAction(() => m_playerBattleController.SelectTarget(id));
                }
                else
                {
                    target = m_targets[i];
                    if (targetCount > 0) { target.gameObject.SetActive(false); }
                    else { hideObjectSequence.AppendCallback(() => target.gameObject.SetActive(false)); }
                }
            }

            if (targetCount > 0)
            {
                m_rectSize = m_openSize;
                m_rectSize.y = m_targetHeight * targetCount + m_targetPaddingHeight * Mathf.Max(targetCount - 1, 1.5f);
                m_openSize = m_rectSize;
                m_containerTransform.sizeDelta = m_rectSize;
                m_resizeTime = m_targetResizeTime * targetCount;
                
                hideObjectSequence.Kill();
            }
            else
            {
                hideObjectSequence.PrependInterval(m_resizeTime);
                hideObjectSequence.Play();
            }
            
            SetScale(targetCount > 0);
        }
    }
}
