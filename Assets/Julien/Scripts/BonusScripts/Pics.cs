using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Pic")]
    public class Pics : Bonus
    {
        private AudioSource _audioSource;
        public override void BonusEffect(GameObject playerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            SpikePrefab.SetActive(true);
            
            _audioSource = playerPrefab.AddComponent<AudioSource>();
            _audioSource.clip = songSfx.PicBonus[Random.Range(0,songSfx.PicBonus.Count)];
            _audioSource.Play();
        }
        
        public override void BonusReset(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            _audioSource.clip = songSfx.DisableBonus[Random.Range(0,songSfx.DisableBonus.Count)];
            _audioSource.Play();
            
            Goat goat = PlayerPrefab.GetComponent<Goat>();
            goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            SpikePrefab.SetActive(false);
        }

        public override void DestroySound(GameObject PlayerPrefab, GameObject SpikePrefab, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}