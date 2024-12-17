using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Jump")]
    public class Traverser : Bonus
    {
        private LayerMask _oldLayerMask;
        private AudioSource _audioSource;
        public override void BonusEffect(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            PlayerPrefab.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
            
            _oldLayerMask = PlayerPrefab.layer;
            PlayerPrefab.layer = LayerMask.NameToLayer("NoCollideBlock");
            Debug.Log("traverser");

            _audioSource = PlayerPrefab.AddComponent<AudioSource>();
            _audioSource.clip = songSfx.InvisibleBonus[Random.Range(0,songSfx.InvisibleBonus.Count)];
            _audioSource.Play();
        }

        public override void BonusReset(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            PlayerPrefab.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            
            _audioSource.clip = songSfx.DisableBonus[Random.Range(0,songSfx.DisableBonus.Count)];
            _audioSource.Play();
            
            PlayerPrefab.layer = _oldLayerMask;
        }

        public override void DestroySound(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}