using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Speed")]
    public class Speed : Bonus
    {
        public override void BonusEffect()
        {
            Debug.Log(" Super Speed ! ");  
        }
    }
}