using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider bgSlider;
    [SerializeField] Slider sfxSlider;

    public GameObject MainMenuPanel;
    public GameObject OptionsMenuPanel;
    public GameObject AboutPanel;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        bgSlider.onValueChanged.AddListener(SetBGMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetBGMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void HideOptionsMenu()
    {
        OptionsMenuPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void ShowOptionsMenu()
    {
        OptionsMenuPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void HideAboutMenu()
    {
        AboutPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void ShowAboutMenu()
    {
        AboutPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
}
