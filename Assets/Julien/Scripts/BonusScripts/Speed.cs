using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Speed")]
    public class Speed : Bonus
    {
        
        private float BonusTime = 3f;
        private  Goat _goat;
        private AudioSource _audioSource;
        
        public override void BonusEffect(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            Goat _goat = PlayerPrefab.GetComponent<Goat>();
           _goat.Speed += 5;
           
          _audioSource = PlayerPrefab.AddComponent<AudioSource>();
          _audioSource.clip = songSfx.SpeedBonus[Random.Range(0,songSfx.SpeedBonus.Count)];
          _audioSource.Play();
        }

        public override void BonusReset(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            _audioSource.clip = songSfx.DisableBonus[Random.Range(0,songSfx.DisableBonus.Count)];
            _audioSource.Play();
            
            Goat _goat = PlayerPrefab.GetComponent<Goat>();
            _goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            _goat.Speed -= 5;
            
        }

        public override void DestroySound(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}