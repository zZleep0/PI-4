using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSliders : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundFXVolumeSlider;

    //quando a musica da load primeiro ela ativa o Save() e faz com que o sound seja substituido antes de ter seu proprio load
    private float bugSoundFXVolume;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        if (!PlayerPrefs.HasKey("soundFXVolume"))
        {
            PlayerPrefs.SetFloat("soundFXVolume", 1);
        }

        bugSoundFXVolume = PlayerPrefs.GetFloat("soundFXVolume");

        Load();
    }

    public void ChangedVolume()
    {
        Save();
    }

    private void Load()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundFXVolumeSlider.value = bugSoundFXVolume;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("soundFXVolume", soundFXVolumeSlider.value);
    }
}
