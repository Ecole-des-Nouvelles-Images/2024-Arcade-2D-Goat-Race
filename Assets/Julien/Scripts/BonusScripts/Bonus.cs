using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    public abstract class Bonus : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        
        public abstract void BonusEffect();
    }
}
