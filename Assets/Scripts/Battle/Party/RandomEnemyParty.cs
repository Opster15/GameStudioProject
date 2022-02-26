using System;
using System.Collections.Generic;
using System.Linq;
using GSP.Util;
using Sirenix.OdinInspector;
using UnityEngine;
namespace GSP.Battle.Party
{
    /// <summary>
    /// An enemy party populated with random enemies from a list of possible spawns.
    /// </summary>
    [CreateAssetMenu(fileName = "New Random Enemy Party", menuName = "GSP/Random Enemy Party")]
    public class RandomEnemyParty : EnemyPartyObject
    {
        /// <summary>
        /// Every possible character that can be in the party, along with the weighted chance of picking them.
        /// </summary>
        [TableList] [SerializeField] private List<WeightedRollCharacter> m_spawnWeights;

        /// <summary>
        /// Every possible party size, along with the weighted chance of using it.
        /// </summary>
        [TableList] [SerializeField] private List<WeightedRollInteger> m_spawnSizes;

        /// <summary>
        /// Randomly populate the party with an amount of characters, based on their spawn weights.
        /// </summary>
        public override GameParty GetParty()
        {
            // There is no need to roll a random party size if only one is available.
            var partySize = m_spawnSizes.Count == 1 ? m_spawnSizes[0].Value : WeightedRollInteger.GetRoll(m_spawnSizes, 1);
            var totalSpawnWeight = WeightedRollCharacter.SumWeights(m_spawnWeights);

            var partyMembers = new List<Character>();
            for(var i = 0; i < partySize; i++)
            {
                var spawn = WeightedRollCharacter.GetRoll(m_spawnWeights, totalSpawnWeight, null);
                if(!spawn) { Debug.LogError("Invalid Character rolled when populating random enemy party!"); }
                partyMembers.Add(spawn);
            }

            return new GameParty(partyMembers);
        }
    }
}
