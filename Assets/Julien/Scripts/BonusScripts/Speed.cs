using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Julien.Scripts.BonusScripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/BonusScripts/Speed")]
    public class Speed : Bonus
    {

        [SerializeField] private GameObject _audioSourcePrefab;
        
        private float BonusTime = 3f;
        private  Goat _goat;
        private AudioSource _audioSource;
        
        
        public override void BonusEffect(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Goat _goat = Player.GetComponent<Goat>();
           _goat.Speed += 5;
           
          GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
          AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
          audioSourcePlayer.Play(songSfx.SpeedBonus[Random.Range(0, songSfx.SpeedBonus.Count)]);
          
          // _audioSource.outputAudioMixerGroup.audioMixer = 
        }

        public override void BonusReset(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            GameObject instantiate = Instantiate(_audioSourcePrefab, Player.transform);
            AudioSourcePlayer audioSourcePlayer = instantiate.GetComponent<AudioSourcePlayer>();
            audioSourcePlayer.Play(songSfx.DisableBonus[Random.Range(0, songSfx.DisableBonus.Count)]);
            
            Goat _goat = Player.GetComponent<Goat>();
            _goat.GetComponent<InventaryBonus>().IsUsingBonus = false;
            _goat.Speed -= 5;
            
        }

        public override void DestroySound(GameObject Player, GameObject Spike, SongSFX songSfx)
        {
            Debug.Log("DestroySound");
            Destroy(_audioSource);
        }
    }
}