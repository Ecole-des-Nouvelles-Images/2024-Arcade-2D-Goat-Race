using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour
{
    
    private AudioSource _source;
    private bool _hasStarted;
    
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_source.isPlaying && _hasStarted) 
            Destroy(gameObject);
    }

    public void Play(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
        _hasStarted = true;
    }
}
