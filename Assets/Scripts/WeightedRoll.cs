using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
namespace GSP
{
    /// <summary>
    /// A weighted chance to roll a specified value.
    /// </summary>
    [Serializable]
    public class WeightedRoll<T>
    {
        /// <summary>
        /// The value to use if chosen.
        /// </summary>
        [SerializeField] private T m_value;
            
        /// <summary>
        /// The chance that this value is rolled, in relation to the other possible weights.
        /// </summary>
        [SerializeField] private int m_weight;

        /// <summary>
        /// This value's weight in relation to its position in the list of possible rolls.
        /// </summary>
        private int m_summedWeight;

        /// <summary>
        /// The value to use if chosen.
        /// </summary>
        public T Value => m_value;

        /// <summary>
        /// The chance that this value is rolled, in relation to the other possible weights.
        /// </summary>
        public int Weight => m_weight;

        public int SummedWeight
        {
            get => m_summedWeight;
            set => m_summedWeight = value;
        }

        /// <summary>
        /// Return the sum of weights of a list of possible rolls.
        /// </summary>
        /// <param name="_rolls">A list of possible rolls.</param>
        /// <returns>The sum of all rolls' weights.</returns>
        public static int SumWeights(IEnumerable<WeightedRoll<T>> _rolls)
        {
            var weight = 0;
            foreach (var roll in _rolls)
            {
                weight += roll.Weight;
                roll.SummedWeight = weight;
            }
            return weight;
        }

        /// <summary>
        /// Return a random value from a list of possible rolls, chosen with accordance to each roll's given weight.
        /// </summary>
        /// <param name="_rolls">A list of possible rolls.</param>
        /// <param name="_totalWeight">The sum of all rolls' weights.</param>
        /// <param name="_defaultReturn">The default value to return if the roll fails for some reason (i.e. an empty list)</param>
        /// <returns></returns>
        public static T GetRoll(IEnumerable<WeightedRoll<T>> _rolls, int _totalWeight, T _defaultReturn)
        {
            var r = Random.Range(0, _totalWeight);
            foreach (var roll in _rolls)
            {
                if (roll.SummedWeight > r) { return roll.Value; }
            }
            return _defaultReturn;
        }

        /// <summary>
        /// Return a random value from a list of possible rolls, chosen with accordance to each roll's given weight.
        /// </summary>
        /// <param name="_rolls">A list of possible rolls.</param>
        /// <param name="_defaultReturn">The default value to return if the roll fails for some reason (i.e. an empty list)</param>
        public static T GetRoll(IEnumerable<WeightedRoll<T>> _rolls, T _defaultReturn)
            => GetRoll(_rolls, SumWeights(_rolls), _defaultReturn);
    }
}
