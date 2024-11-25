using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Etoile")]
    public class Etoile : Bonus
    {
        public override void BonusEffect()
        {
            Debug.Log(" Etoile ! ");  
        }
    }
}