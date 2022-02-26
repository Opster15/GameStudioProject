using System;
using System.Collections.Generic;
using GSP.Util;
using UnityEngine;
namespace GSP.Battle.Party
{
    /// <summary>
    /// An enemy party populated with random enemies from a list of possible spawns.
    /// </summary>
    [CreateAssetMenu(fileName = "New Random Enemy Party", menuName = "GSP/Random Enemy Party")]
    public class RandomEnemyParty : EnemyParty
    {
        /// <summary>
        /// Every possible character that can be in the party, along with the weighted chance of picking them.
        /// </summary>
        [SerializeField] private List<WeightedRollCharacter> m_spawnWeights;

        /// <summary>
        /// Every possible party size, along with the weighted chance of using it.
        /// </summary>
        [SerializeField] private List<WeightedRollInteger> m_spawnSizes;
        
        /// <summary>
        /// The final generated party's members.
        /// </summary>
        private List<Character> m_partyMembers;
        
        /// <summary>
        /// Whether the party has been filled.
        /// </summary>
        private bool m_populated;
        
        /// <summary>
        /// Randomly populate the party with an amount of characters, based on their spawn weights.
        /// </summary>
        public void Populate()
        {
            // There is no need to roll a random party size if only one is available.
            var partySize = m_spawnSizes.Count == 1 ? m_spawnSizes[0].Value : WeightedRollInteger.GetRoll(m_spawnSizes, 1);
            
            var totalSpawnWeight = WeightedRollCharacter.SumWeights(m_spawnWeights);
            for(var i = 0; i < partySize; i++)
            {
                var spawn = WeightedRollCharacter.GetRoll(m_spawnWeights, totalSpawnWeight, null);
                if(!spawn) { Debug.LogError("Invalid Character rolled when populating random enemy party!"); }
                m_partyMembers.Add(spawn);
            }
            
            m_populated = true;
        }

        public override List<Character> GetPartyMembers()
        {
            if (!m_populated) { Populate(); }
            return m_partyMembers;
        }
    }
}
