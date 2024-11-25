using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Jump")]
    public class Traverser : Bonus
    {
        public override void BonusEffect()
        {
            Debug.Log(" Traverser ! ");
        }
    }
}