using UnityEngine;

using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    AudioSource m_audioSource;
    [SerializeField] public AudioClip hitSound, deathSound, attackSound, jumpSound;
    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        m_audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void PlayAudioClip(AudioClip clip, float volume = 1f)
    {
        m_audioSource.PlayOneShot(clip, volume);
    }
    public void playJumpSound()
    {
        PlayAudioClip(jumpSound, 3);
    }
    public void playdeadSound()
    {
        PlayAudioClip(deathSound, 1);
    }
    public void playAttackSound()
    {
        PlayAudioClip(attackSound, 1);
    }
    public void playhitSound()
    {
        PlayAudioClip(hitSound, 1);
    }
}