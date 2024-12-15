using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Jump")]
    public class Traverser : Bonus
    {
        private LayerMask _oldLayerMask;
        
        public override void BonusEffect(GameObject PlayerPrefab, GameObject SpikePrefab)
        {
            PlayerPrefab.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
            
            _oldLayerMask = PlayerPrefab.layer;
            PlayerPrefab.layer = LayerMask.NameToLayer("NoCollideBlock");
            Debug.Log("traverser");
        }

        public override void BonusReset(GameObject PlayerPrefab, GameObject SpikePrefab)
        {
            PlayerPrefab.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            
            PlayerPrefab.layer = _oldLayerMask;
        }
    }
}