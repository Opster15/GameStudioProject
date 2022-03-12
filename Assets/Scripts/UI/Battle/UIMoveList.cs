using System;
using System.Collections;
using System.Collections.Generic;
using GSP.Battle;
using GSP.Battle.Controller;
using GSP.UI.Battle;
using UnityEngine;
using UnityEngine.UI;

namespace GSP.UI.Battle
{
    public class UIMoveList : UISelectedCharacterScale
    {
        private PlayerBattleController m_playerBattleController;
        
        private List<UIMove> m_moves;
        
        private RectTransform m_containerTransform;

        [SerializeField] private GameObject m_movePrefab;

        [SerializeField] private Transform m_moveParent;

        [SerializeField] private int m_moveHeight;
        [SerializeField] private int m_paddingHeight;

        [SerializeField] private float m_moveResizeTime;

        private Vector2 m_rectSize;

        protected override void Awake()
        {
            base.Awake();
            m_moves = new List<UIMove>();
            
            m_playerBattleController = FindObjectOfType<PlayerBattleController>();

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
                    UIMove move;
                    if (i < uiMoveCount)
                    {
                        m_moves[i].gameObject.SetActive(true);
                        move = m_moves[i];
                    }
                    else
                    {
                        var moveObject = Instantiate(m_movePrefab, m_moveParent);
                        move = moveObject.GetComponent<UIMove>();
                        m_moves.Add(move);
                    }
                    
                    var id = i;
                    move.SetTarget(_target?.Moveset[i], _target);
                    move.GetComponent<UIButton>().SetClickAction(() => m_playerBattleController.SelectMove(id));
                }
                else
                {
                    m_moves[i].gameObject.SetActive(false);
                }
            }

            m_rectSize = m_openSize;
            m_rectSize.y = m_moveHeight * moveCount + m_paddingHeight * Mathf.Max(moveCount - 1, 1.5f);
            m_openSize = m_rectSize;
            m_containerTransform.sizeDelta = m_rectSize;

            m_resizeTime = m_moveResizeTime * moveCount;
        }
    }
}
