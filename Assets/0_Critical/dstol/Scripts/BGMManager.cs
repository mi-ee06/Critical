using UnityEngine;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] bgms;
    private float seVolume;

    public void LoadAllTracks()
    {
        for(int i = 0; i < bgms.Length; i++)
        {
            bgms[i].LoadAudioData();
        }
    }
    public void ChangeTrack(int track)
    {
        if (bgms[track] == audioSource.clip)
        {
            return;
        }
        ChangeTrack(bgms[track]);
    }
    public void ChangeTrack(AudioClip clip)
    {
        if(audioSource.clip == clip)
        {
            return;
        }
        audioSource.clip = clip;
    }
    public void PlayTrack(int track)
    {
        Debug.Log("Player Track #" + track);
        ChangeTrack(track);
        audioSource.PlayScheduled(AudioSettings.dspTime + 0.5f);
    }
    public void PlayTrack(AudioClip track)
    {
        ChangeTrack(track);
        audioSource.Play();
    }
    public void SetBGMVolume(float value)
    {
        audioSource.volume = value;
    }
    public void SetSEVolume(float value)
    {
        seVolume = value;
    }
    public float SEVolume
    {
        get { return seVolume; }
    }
}
