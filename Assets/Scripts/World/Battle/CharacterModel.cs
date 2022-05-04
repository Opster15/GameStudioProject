using DG.Tweening;
using GSP.Battle;
using GSP.UI.Battle;
using UnityEngine;
namespace GSP.World.Battle
{
    public class CharacterModel : CharacterTargetedElement
    {
        private static readonly int s_isAttacking = Animator.StringToHash("isAttacking");
        private static readonly int s_isWalking = Animator.StringToHash("isWalking");
        private static readonly int s_isDamaged = Animator.StringToHash("isDamaged");
        private static readonly int s_isDead = Animator.StringToHash("isDead");
        
        private GameObject m_model;

        private Animator m_anim;

        [SerializeField] private Vector3 m_selectedPosition;
        [SerializeField] private float m_moveTime;

        private Sequence m_walkSequence;

        private void Start()
        {
            m_anim = GetComponentInChildren<Animator>();
        }

        private void OnDisable()
        {
            if (m_target != null)
            {
                m_target.OnSelected -= OnSelected;
                m_target.OnDamaged -= OnDamaged;
                m_target.OnUsingMove -= OnUsingMove;
            }
        }

        public override void SetTarget(GameCharacter _target)
        {
            if (m_target != null)
            {
                m_target.OnSelected -= OnSelected;
                m_target.OnDamaged -= OnDamaged;
                m_target.OnUsingMove -= OnUsingMove;
            }
        
            base.SetTarget(_target);

            var modelPrefab = _target.BaseCharacter.ModelPrefab;
            if (!modelPrefab) { return; }

            m_model = Instantiate(modelPrefab, transform.position + modelPrefab.transform.position, transform.rotation, transform);

            _target.OnSelected += OnSelected;
            _target.OnDamaged += OnDamaged;
            m_target.OnUsingMove += OnUsingMove;
        }
        
        private void OnSelected(bool _selected)
        {
            if (!m_target.BaseCharacter.WalkOnSelected) { return; }
            
            if (m_walkSequence is { active: true })
            {
                m_walkSequence.Kill();
            }

            m_anim.SetBool(s_isWalking, true);

            m_walkSequence = DOTween.Sequence();
            m_walkSequence.Append(transform.DOLocalMove(_selected ? m_selectedPosition : Vector3.zero, m_moveTime));
            m_walkSequence.AppendCallback(() => m_anim.SetBool(s_isWalking, false));
        }

        private void OnUsingMove()
        {
            m_anim.SetTrigger(s_isAttacking);
        }

        private void OnDamaged(int _amount)
        {
            m_anim.SetTrigger(m_target.CurrentHP <= 0 ? s_isDead : s_isDamaged);
        }
    }
}