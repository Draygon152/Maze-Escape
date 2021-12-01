using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_control : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;

    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
