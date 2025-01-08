using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Pic")]
    public class Pics : Bonus
    {
        [SerializeField] private GameObject _audioSourcePrefab;
        
        private AudioSource _audioSource;
        
        public override void BonusEffect(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Spike.SetActive(true);
            Player.GetComponent<Goat>().CanBeStun = true;
            
            GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
            AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
            audioSourcePlayer.Play(songSfx.PicBonus[Random.Range(0, songSfx.PicBonus.Count)]);
        }
        
        public override void BonusReset(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
            Player.GetComponent<Goat>().CanBeStun = false;
            
            AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
            audioSourcePlayer.Play(songSfx.DisableBonus[Random.Range(0, songSfx.DisableBonus.Count)]);
            
            Goat goat = Player.GetComponent<Goat>();
            goat.GetComponent<InventaryBonus>().IsUsingBonus = true;
            Spike.SetActive(false);
        }

        public override void DestroySound(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}