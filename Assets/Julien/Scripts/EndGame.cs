using DG.Tweening;
using Julien.Scripts;
using UnityEngine;

using Random = UnityEngine.Random;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject VictoryPanelPlayerOne;
    [SerializeField] private GameObject VictoryPanelPlayerTwo;

    private AudioSource _audioSource;
    private GameObject _sfxManager;
    private SongSFX _songSFX;
    
    private bool _onePlayerWOn;

    private void Start()
    {
        _sfxManager = GameObject.Find("SFXManager");
        _songSFX = _sfxManager.GetComponent<SongSFX>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.gameObject.CompareTag("Player"))
        {
            Goat goat = other.gameObject.GetComponent<Goat>();

            if (_onePlayerWOn == false)
            {
                
                if (goat.PlayerOne)
                {
                    VictoryPanelPlayerOne.SetActive(true);
                    VictoryPanelPlayerOne.transform.DOScale(1, 0.2f);
                    
                    _audioSource.clip = _songSFX.WinAudio[Random.Range(0,_songSFX.AudioStep.Count)];
                    _audioSource.Play();
                }
                else
                {
                    VictoryPanelPlayerTwo.SetActive(true);
                    VictoryPanelPlayerTwo.transform.DOScale(1, 0.2f);
                    
                    _audioSource.clip = _songSFX.WinAudio[Random.Range(0,_songSFX.AudioStep.Count)];
                    _audioSource.Play();
                } 
            }
        }
    }
}
