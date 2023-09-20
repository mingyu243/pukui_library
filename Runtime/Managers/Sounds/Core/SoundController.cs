using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

public class SoundController : MonoBehaviour
{
    IObjectPool<SoundController> _managedPool;
    
    AudioSource _audioSource;
    public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }

    private void Awake()
    {
        AudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void SetManagedPool(IObjectPool<SoundController> pool)
    {
        _managedPool = pool;
    }

    public void Play()
    {
        AudioSource.Play();
        Invoke("Kill", AudioSource.clip.length);
    }

    private void Update()
    {
        
    }

    public void Kill()
    {
        Stop();

        _managedPool.Release(this);
    }

    public void Stop()
    {
        AudioSource.Stop();
    }

    public void SetSourceProperties(AudioMixerGroup mixerGroup, AudioClip clip)
    {
        AudioSource.outputAudioMixerGroup = mixerGroup;
        AudioSource.clip = clip;
    }
}
