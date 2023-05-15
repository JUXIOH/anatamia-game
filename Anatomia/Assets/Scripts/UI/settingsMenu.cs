using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class settingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown quality;

    void Awake()
    {
        quality.value = QualitySettings.GetQualityLevel();
    }

    public void setQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
