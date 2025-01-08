using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Jump")]
    public class Traverser : Bonus
    {
        [SerializeField] private GameObject _audioSourcePrefab;
        
        private LayerMask _oldLayerMask;
        private AudioSource _audioSource;
        
        public override void BonusEffect(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
            Player.GetComponent<Goat>().CanBeStun = false;
            
            _oldLayerMask = Player.layer;
            Player.layer = LayerMask.NameToLayer("NoCollideBlock");
            Debug.Log("traverser");
            
            GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
            AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
            audioSourcePlayer.Play(songSfx.InvisibleBonus[Random.Range(0, songSfx.InvisibleBonus.Count)]);
        }

        public override void BonusReset(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            
            GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
            Player.GetComponent<Goat>().CanBeStun = true;
            
            AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
            audioSourcePlayer.Play(songSfx.DisableBonus[Random.Range(0, songSfx.DisableBonus.Count)]);
            
            Player.layer = _oldLayerMask;
        }

        public override void DestroySound(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}