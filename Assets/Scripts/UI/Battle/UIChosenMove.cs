using GSP.Battle;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIChosenMove : UIResizingElement
    {
        private UIMove m_move;

        [SerializeField] private int m_openHeight;

        protected override void Awake()
        {
            base.Awake();
            m_move = GetComponentInChildren<UIMove>();
        }

        private void OnDisable()
        {
            if (m_target != null) { m_target.OnMoveChosen -= OnMoveChosen; }
        }

        public override void SetTarget(GameCharacter _target)
        {
            if (m_target != null) { m_target.OnMoveChosen -= OnMoveChosen; }
            base.SetTarget(_target);
            if (_target != null) { _target.OnMoveChosen += OnMoveChosen; }
        }

        private void OnMoveChosen(GameMove _move)
        {
            m_move.SetTarget(_move, m_target);
            SetScale(_move != null);
        }
    }
}
