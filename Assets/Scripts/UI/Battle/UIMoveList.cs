using System;
using System.Collections;
using System.Collections.Generic;
using GSP.Battle;
using GSP.UI.Battle;
using UnityEngine;

namespace GSP.UI.Battle
{
    public class UIMoveList : UICharacterTargetedElement
    {
        private List<UIMove> m_moves;
        
        private RectTransform m_rectTransform;
        private RectTransform m_containerTransform;

        [SerializeField] private GameObject m_movePrefab;

        [SerializeField] private Transform m_moveParent;

        [SerializeField] private int m_moveHeight;
        [SerializeField] private int m_paddingHeight;

        private void Awake()
        {
            m_moves = new List<UIMove>();

            m_rectTransform = GetComponent<RectTransform>();
            m_containerTransform = m_rectTransform.GetChild(0).GetComponent<RectTransform>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            
            var moveCount = 0;
            var uiMoveCount = m_moves.Count;
            if (_target != null) { moveCount = _target.Moveset.Count; }
            
            for (var i = 0; i < Mathf.Max(moveCount, uiMoveCount); i++)
            {
                if (i < moveCount)
                {
                    if (i < uiMoveCount)
                    {
                        m_moves[i].gameObject.SetActive(true);
                        //TODO: Move name and stats displayed
                    }
                    else
                    {
                        var moveObject = Instantiate(m_movePrefab, m_moveParent);
                        m_moves.Add(moveObject.GetComponent<UIMove>());
                    }
                }
                else
                {
                    m_moves[i].gameObject.SetActive(false);
                }
            }

            var rectSize = m_rectTransform.sizeDelta;
            
            rectSize.y = m_moveHeight * moveCount + m_paddingHeight * Mathf.Max(moveCount - 1, 1);

            m_rectTransform.sizeDelta = rectSize;
            m_containerTransform.sizeDelta = rectSize;
        }
    }
}
