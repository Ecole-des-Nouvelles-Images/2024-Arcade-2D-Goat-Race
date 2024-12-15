using System;
using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Pic")]
    public class Pics : Bonus
    {
        public override void BonusEffect(GameObject playerPrefab, GameObject SpikePrefab)
        {
            SpikePrefab.SetActive(true);
        }
        
        public override void BonusReset(GameObject PlayerPrefab, GameObject SpikePrefab)
        {
            Goat goat = PlayerPrefab.GetComponent<Goat>();
            goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            SpikePrefab.SetActive(false);
        }
    }
}