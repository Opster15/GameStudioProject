using UnityEngine;
namespace GSP.FX
{
    public class OnHealthChangeSpawner : OnHealthChangedBase
    {
        [SerializeField] private GameObject m_spawnPrefab;

        protected override void OnHealthChanged(int _amount)
        {
            var spawnObject = Instantiate(m_spawnPrefab, transform.position + m_spawnPrefab.transform.position, Quaternion.identity);
            var spawn = spawnObject.GetComponent<ISpawnedOnHealthChange>();
            spawn?.SetAmount(_amount);
        }
    }
}
