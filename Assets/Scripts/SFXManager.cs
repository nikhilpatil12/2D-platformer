using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip killMonsterClip;
    public AudioClip dieClip;
    public AudioClip collectClip;
    public AudioClip finishClip;

    public static SFXManager sfxManager;

    private void Awake()
    {
        if(sfxManager != null && sfxManager!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxManager = this;
        DontDestroyOnLoad(this);
    }
}
