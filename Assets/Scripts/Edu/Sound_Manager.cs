using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound_Manager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;
    void Start()
    {
        LoadValues();
    }

    public void SaveVolume()
    {
        float musicValue = musicSlider.value;
        float effectsValue = effectsSlider.value;
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.SetFloat("EffectsValue", effectsValue);
        LoadValues();
    }
    
    private void LoadValues()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        float effectsValue = PlayerPrefs.GetFloat("EffectsValue");
        musicSlider.value = musicValue;
        effectsSlider.value = effectsValue;
        //AudioListener.volume = musicValue;
    }
    private void Update()
    {
        //Debug.Log(effectsSlider.value);
    }
}
