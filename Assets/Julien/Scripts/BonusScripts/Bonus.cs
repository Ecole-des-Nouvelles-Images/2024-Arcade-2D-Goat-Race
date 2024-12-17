using System.Collections;
using UnityEngine;

namespace Julien.Scripts.BonusScripts
{
    public abstract class Bonus : ScriptableObject
    {
        public Sprite _sprite;
        
        public abstract void BonusEffect(GameObject Player, GameObject Spike, SongSFX songSfx);
        public abstract void BonusReset(GameObject Player, GameObject Spike, SongSFX songSfx);
        public abstract void DestroySound(GameObject Player, GameObject Spike, SongSFX songSfx);
    }
}
