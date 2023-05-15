using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;

    [SerializeField] AudioMixer mixer;

    public const string MASTER_KEY = "masterVolume";
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume() //Volume saved in volumeSettings.cs
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(volumeSettings.MIXER_MASTER, Mathf.Log10(masterVolume) * 20);
        mixer.SetFloat(volumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(volumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
