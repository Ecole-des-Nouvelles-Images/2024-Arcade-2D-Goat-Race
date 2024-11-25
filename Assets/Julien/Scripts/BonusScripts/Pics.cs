using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Etoile")]
    public class Pics : Bonus
    {
        public GameObject SpherePrefab;
        public Transform PlayerTransform;
        public override void BonusEffect()
        {
            Debug.Log(" Pic ! ");  
        }
    }
}