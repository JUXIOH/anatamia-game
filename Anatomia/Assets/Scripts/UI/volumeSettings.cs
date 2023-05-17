using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMPro.TMP_Text masterText;
    [SerializeField] TMPro.TMP_Text musicText;
    [SerializeField] TMPro.TMP_Text sfxText;

    public const string MIXER_MASTER = "masterVolume";
    public const string MIXER_MUSIC = "musicVolume";
    public const string MIXER_SFX = "sfxVolume";

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(audioManager.MASTER_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(audioManager.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(audioManager.SFX_KEY, 1f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(audioManager.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(audioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(audioManager.SFX_KEY, sfxSlider.value);
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
        float calculate = value * 100;
        masterText.text = (int)calculate + "%";
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        float calculate = value * 100;
        musicText.text = (int)calculate + "%";
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        float calculate = value * 100;
        sfxText.text = (int)calculate + "%";
    }

}
