using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class settingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown qualityIndex;
    public Slider slider;
    public AudioMixer audioMixer;
    public GameObject podesavanja;
    private float jacinaZvuka = 0;
    private bool result;

    private void Start()
    {

        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel());
        qualityIndex.value = QualitySettings.GetQualityLevel() -  1;
        GetMasterLevel();
        SetStartVolume(jacinaZvuka);
    }
    public float GetMasterLevel()
    {
        result = audioMixer.GetFloat("volume", out jacinaZvuka);
        if (result)
        {
            return jacinaZvuka;
        }
        else
        {
            return 0f;
        }
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex + 1);
    }
    public void goInSettings()
    {
        podesavanja.SetActive(true);
    }
    public void outOfSettings()
    {
        podesavanja.SetActive(false);
    }
    public void SetStartVolume(float startVolume)
    {
        audioMixer.SetFloat("volume", startVolume);
        slider.value = startVolume;
    }
}
