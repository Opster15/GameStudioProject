using System.Collections;
using GSP.Battle.Party;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private GameParty[] m_parties;

    private void Awake()
    {
        m_parties = new GameParty[2];
    }

    [SerializeField] private EnemyPartyObject m_A;
    [SerializeField] private EnemyPartyObject m_B;

    private void Start()
    {
        StartBattle(m_A.GetParty(), m_B.GetParty());
    }

    public void StartBattle(GameParty _a, GameParty _b)
    {
        m_parties[0] = _a;
        m_parties[1] = _b;

        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        StartTurn();
        for (var i = 0; i < m_parties.Length; i++) { yield return ChooseMoves(m_parties[m_parties.Length - i - 1], m_parties[m_parties.Length]); }
    }

    private void StartTurn()
    {
        
    }

    private IEnumerator ChooseMoves(GameParty _party, GameParty _opposingParty)
    {
        for (var i = 0; i < _party.PartyMembers.Count; i++)
        {
            _party.BattleController.SelectPartyMember(i);
            yield return new WaitUntil(() => _party.BattleController.GetChosenAction() != null);
        }
    }
}
