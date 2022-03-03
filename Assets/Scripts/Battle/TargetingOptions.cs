using System;
using System.Collections.Generic;
using UnityEngine;
using GSP.Battle.Party;
namespace GSP.Battle
{
    /// <summary>
    /// A move's targeting options.
    /// </summary>
    [Serializable]
    public struct TargetingOptions
    {
        public enum TargetChoice
        {
            Self,
            Friendly,
            Enemy,
            All
        }

        /// <summary>
        /// What characters are valid targets for the move.
        /// </summary>
        [SerializeField] private TargetChoice m_target;

        /// <summary>
        /// Whether the move should select all valid targets.
        /// </summary>
        [SerializeField] private bool m_selectAll;

        /// <summary>
        /// Whether the user of the move should be excluded from selection.
        /// </summary>
        [SerializeField] private bool m_excludeSelf;

        /// <summary>
        /// What characters are valid targets for the move.
        /// </summary>
        public TargetChoice Target => m_target;

        /// <summary>
        /// Whether the move should select all valid targets.
        /// </summary>
        public bool SelectAll => m_selectAll;

        /// <summary>
        /// Whether the user of the move should be excluded from selection.
        /// </summary>
        public bool ExcludeSelf => m_excludeSelf;

        public bool IsTargetingManual()
            => m_target != TargetChoice.Self && !m_selectAll;

        public List<GameCharacter> GetValidTargets(int _characterID, GameParty _party, GameParty _opposingParty)
        {
            var targets = new List<GameCharacter>();
            switch(m_target)
            {
                case TargetChoice.Self:
                    targets.Add(_party.PartyMembers[_characterID]);
                    break;
                case TargetChoice.Friendly:
                    targets.AddRange(_party.PartyMembers);
                    break;
                case TargetChoice.Enemy:
                    targets.AddRange(_opposingParty.PartyMembers);
                    break;
                case TargetChoice.All:
                    targets.AddRange(_party.PartyMembers);
                    targets.AddRange(_opposingParty.PartyMembers);
                    break;
            }

            if(m_excludeSelf && m_target != TargetChoice.Enemy) { targets.Remove(_party.PartyMembers[_characterID]); }
            return targets;
        }
    }
}