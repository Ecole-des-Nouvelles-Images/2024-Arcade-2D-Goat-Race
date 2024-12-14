using System.Collections;
using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    public abstract class Bonus : ScriptableObject
    {
        public Sprite _sprite;
        
        public abstract void BonusEffect(GameObject PlayerPrefab, GameObject SpkiePrefab);
        public abstract void BonusReset(GameObject PlayerPrefab, GameObject SpkiePrefab);
    }
}
