using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource audioVFX;

    public AudioClip musicClipMenu;
    public AudioClip musicClipGame;

    public AudioClip musicClipOnbutton;

    public AudioClip musicClipAttack;
    public AudioClip musicClipDead;
    public AudioClip musicClipRun;
    public AudioClip musicClipJump;

    public AudioClip musicClipItem;

    private void Awake()
    {
        // Giữ object này tồn tại khi load scene mới
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        music.clip = musicClipMenu;
        music.Play();
    }
    void PlayAudioVFX(AudioClip clip)
    {
        audioVFX.clip = musicClipMenu;
        audioVFX.PlayOneShot(clip);
    }
}
