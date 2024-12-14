using System;
using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Pic")]
    public class Pics : Bonus
    {
        public override void BonusEffect(GameObject PlayerPrefab,
            GameObject SpkiePrefab)
        {
            Debug.Log(" Pic ! ");
            SpkiePrefab.SetActive(true);
        }

        public override void BonusReset(GameObject PlayerPrefab,
            GameObject SpkiePrefab)
        {
            Goat goat = PlayerPrefab.GetComponent<Goat>();
            goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            SpkiePrefab.SetActive(false);
        }
    }
}