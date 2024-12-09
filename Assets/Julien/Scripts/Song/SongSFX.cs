using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSFX : MonoBehaviour
{
    
   [Header("<color=yellow>Audio Jumping </color>")]
    public List<AudioClip> AudioJump;
    public List<AudioClip> AudioLanding;
    [Header("--------------------------------------------------")]
    
    [Header("<color=red>Audio Damage Obstacle </color>")]
    public List<AudioClip> AudioDamage;
    public List<AudioClip> AudioDestroy;
    [Header("--------------------------------------------------")]
    
    [Header("<color=purple>Audio Stun </color>")]
    public List<AudioClip> AudioStun;
    [Header("--------------------------------------------------")]
  
    [Header("<color=green>Audio Step </color>")]
    public List<AudioClip> AudioStep;
}
