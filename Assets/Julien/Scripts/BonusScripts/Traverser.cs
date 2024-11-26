using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Jump")]
    public class Traverser : Bonus
    {
        public override void BonusEffect(GameObject PlayerPrefab,
            GameObject SpkiePrefab)
        {
            Debug.Log(" Traverser ! ");
        }

        public override void BonusReset(GameObject PlayerPrefab,
            GameObject SpkiePrefab)
        {
            throw new System.NotImplementedException();
        }
    }
}