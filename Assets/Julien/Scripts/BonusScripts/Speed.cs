using System;
using System.Collections;
using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Speed")]
    public class Speed : Bonus
    {
        
        private float BonusTime = 3f;
        
        private  Goat _goat;
        
        public override void BonusEffect(GameObject PlayerPrefab, GameObject SpikePrefab)
        {
            Goat _goat = PlayerPrefab.GetComponent<Goat>();
           _goat.Speed += 5;
        }

        public override void BonusReset(GameObject PlayerPrefab,
            GameObject SpikePrefab)
        {
            Goat _goat = PlayerPrefab.GetComponent<Goat>();
            _goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            _goat.Speed -= 5;
        }
    }
}