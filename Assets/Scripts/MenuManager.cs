using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuManager : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider musicSlider;
    public Slider soundSlider;

    public GameObject MenuOpciones;

    Resolution[] resolutions;

    public PlayerPicker pp;
    public ScenePicker sp;

    private void Start()
    {

        ChargePrefs();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void ChargePrefs()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", -100f);
        if(musicVolume != -100f)
        {
            this.musicSlider.value = musicVolume;
            SetMusicVolume(musicVolume);
        }

        float soundVolume = PlayerPrefs.GetFloat("SoundVolume", -100f);
        if (soundVolume != -100f)
        {
            this.soundSlider.value = soundVolume;
            SetMusicVolume(soundVolume);
        }

        int quality = PlayerPrefs.GetInt("Quality", -1);
        if (quality != -1)
        {
            this.qualityDropdown.value = quality;
            SetQuality(quality);
        }

        int fullscreen = PlayerPrefs.GetInt("Fullscreen", 1);
        if(quality == 1)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    // Start is called before the first frame update
    public void CloseGame()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public void SetResolution(int index)
    {
        
        Resolution resolution = resolutions[index];
        Debug.Log(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("Quality", index);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (Screen.fullScreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
    }

    public void MostrarMenuOpciones()
    {
        if (MenuOpciones.activeInHierarchy)
        {
            MenuOpciones.SetActive(false);
        }
        else
        {
            MenuOpciones.SetActive(true);
        }
    }

    public void Load()
    {
        pp.ConfirmarSeleccion();
        sp.LoadSelectedLevel();
    }

}
