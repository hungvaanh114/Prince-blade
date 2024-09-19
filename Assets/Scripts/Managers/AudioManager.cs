using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource audioVFX;

    public AudioClip musicClipOnbutton;

    public AudioClip musicClipAttack;
    public AudioClip musicClipDead;
    public AudioClip musicClipRun;
    public AudioClip musicClipJump;

    public AudioClip musicClipItem;

/*    private void Awake()
    {
        // Kiểm tra xem đã có instance tồn tại chưa
        if (instance == null)
        {
            // Nếu chưa có instance, đặt instance này là singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Nếu đã có instance, xóa bản sao này
            Destroy(gameObject);
        }
    }*/

    void PlayAudioVFX(AudioClip clip)
    {
        audioVFX.clip = musicClipAttack;
        audioVFX.PlayOneShot(clip);
    }
}
