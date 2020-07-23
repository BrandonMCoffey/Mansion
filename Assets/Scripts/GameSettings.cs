using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEditor.Experimental.RestService;
using System;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public PlayerSettings playerSettings { get; private set; }
    public AudioMixer audioMixer;

    [Header("UI Visibility")]
    public GameObject pauseUI;
    public GameObject settingsUI;
    public GameObject mapUI;
    public GameObject cardUI;

    bool pauseOpen = false;
    bool mapOpen = false;
    bool cardOpen = false;

    [Header("Settings")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider volumeSlider;
    public Toggle mapHoldToggle;
    public Toggle cardHoldToggle;
    public TMP_Text mapKeyText;
    public TMP_Text cardKeyText;

    string listening = "";
    Resolution[] resolutions;

    private void OnEnable()
    {
        RefreshSettings();
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        if (resolutions.Length > 0 && resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == playerSettings.WindowResolution.width && resolutions[i].height == playerSettings.WindowResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    private void Update()
    {
        if (pauseOpen)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !mapOpen && !cardOpen)
        {
            pauseOpen = !pauseOpen;
            pauseUI.SetActive(pauseOpen);
            settingsUI.SetActive(false);
        }
        if (playerSettings.MapHold)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), playerSettings.MapKey)) && !pauseOpen && !cardOpen)
            {
                mapUI.SetActive(true);
                mapOpen = true;
            }
            else if (mapOpen)
            {
                mapUI.SetActive(false);
                mapOpen = false;
            }
        }
        else
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), playerSettings.MapKey)) && !pauseOpen && !cardOpen)
            {
                mapOpen = !mapOpen;
                mapUI.SetActive(mapOpen);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && mapOpen)
            {
                mapUI.SetActive(false);
                mapOpen = false;
            }
        }
        if (playerSettings.CardHold)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), playerSettings.CardKey)) && !pauseOpen && !mapOpen)
            {
                cardUI.SetActive(true);
                cardOpen = true;
            }
            else if (cardOpen)
            {
                cardUI.SetActive(false);
                cardOpen = false;
            }
        }
        else
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), playerSettings.CardKey)) && !pauseOpen && !mapOpen)
            {
                cardOpen = !cardOpen;
                cardUI.SetActive(cardOpen);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && cardOpen)
            {
                cardUI.SetActive(false);
                cardOpen = false;
            }
        }

        if (listening != "") {
            foreach (KeyCode vkey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vkey) && vkey != KeyCode.Return)
                {
                    Debug.Log(vkey.ToString());
                    if (listening == "map")
                    {
                        playerSettings.MapKey = vkey.ToString();
                        mapKeyText.text = playerSettings.MapKey;
                        listening = "";
                        break;
                    }
                    else if (listening == "card")
                    {
                        playerSettings.CardKey = vkey.ToString();
                        cardKeyText.text = playerSettings.CardKey;
                        listening = "";
                        break;
                    }
                }
            }
        }
    }

    public void SaveSettings()
    {
        SaveLoadData.SaveData(playerSettings);
    }
    public void RefreshSettings()
    {
        playerSettings = SaveLoadData.LoadData(Screen.currentResolution);

        Screen.SetResolution(playerSettings.WindowResolution.width, playerSettings.WindowResolution.height, playerSettings.IsWindowFullscreen);
        QualitySettings.SetQualityLevel(playerSettings.GraphicQuality);
        audioMixer.SetFloat("volume", playerSettings.MasterVolume);
        qualityDropdown.value = playerSettings.GraphicQuality;
        volumeSlider.value = playerSettings.MasterVolume;
        mapHoldToggle.isOn = playerSettings.MapHold;
        cardHoldToggle.isOn = playerSettings.CardHold;
        mapKeyText.text = playerSettings.MapKey;
        cardKeyText.text = playerSettings.CardKey;
    }
    public void ResumeFromPause()
    {
        pauseUI.SetActive(false);
        pauseOpen = false;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.height, resolution.width, playerSettings.IsWindowFullscreen);
        playerSettings.WindowResolution = resolution;
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        playerSettings.IsWindowFullscreen = isFullscreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        playerSettings.MasterVolume = volume;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        playerSettings.GraphicQuality = qualityIndex;
    }
    public void SetMapHold(bool input)
    {
        playerSettings.MapHold = input;
    }
    public void SetCardHold(bool input)
    {
        playerSettings.CardHold = input;
    }
    public void listen(string input)
    {
        listening = input;
    }
}
