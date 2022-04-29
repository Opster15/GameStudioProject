using GSP.Battle;
namespace GSP.UI.Battle
{
    public class UIMoveHasCooldown : UIMoveTargetedElement
    {
        public override void SetTarget(GameMove _target, GameCharacter _user)
        {
            base.SetTarget(_target, _user);
            if (_target == null) { return; }
            
            gameObject.SetActive(_target.BaseMove.Cooldown > 0);
        }
    }
}
