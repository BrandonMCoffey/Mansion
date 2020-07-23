using UnityEngine;

public static class SaveLoadData
{
    public static void SaveData(PlayerSettings playerSettings)
    {
        PlayerPrefs.SetInt("width", playerSettings.WindowResolution.width);
        PlayerPrefs.SetInt("height", playerSettings.WindowResolution.height);
        PlayerPrefs.SetString("fullscreen", playerSettings.IsWindowFullscreen.ToString());
        PlayerPrefs.SetInt("quality", playerSettings.GraphicQuality);
        PlayerPrefs.SetFloat("volume", playerSettings.MasterVolume);
        PlayerPrefs.SetString("mapKey", playerSettings.MapKey);
        PlayerPrefs.SetString("cardKey", playerSettings.CardKey);
        PlayerPrefs.SetString("mapHold", playerSettings.MapHold.ToString());
        PlayerPrefs.SetString("cardHold", playerSettings.CardHold.ToString());
    }

    public static PlayerSettings LoadData(Resolution res)
    {
        if (PlayerPrefs.GetInt("width") > 0 && PlayerPrefs.GetInt("height") > 0)
        {
            res.width = PlayerPrefs.GetInt("width");
            res.height = PlayerPrefs.GetInt("height");
        }
        bool fullscreen = false;
        if (PlayerPrefs.GetString("fullscreen") != "")
        {
            fullscreen = bool.Parse(PlayerPrefs.GetString("fullscreen"));
        }
        int quality = PlayerPrefs.GetInt("quality");
        float volume = PlayerPrefs.GetFloat("volume");
        string mapKey = "M";
        if (PlayerPrefs.GetString("mapKey") != "")
        {
            mapKey = PlayerPrefs.GetString("mapKey");
        }
        string cardKey = "C";
        if (PlayerPrefs.GetString("cardKey") != "")
        {
            cardKey = PlayerPrefs.GetString("cardKey");
        }
        bool mapHold = true;
        if (PlayerPrefs.GetString("mapHold") != "")
        {
            mapHold = bool.Parse(PlayerPrefs.GetString("mapHold"));
        }
        bool cardHold = true;
        if (PlayerPrefs.GetString("cardHold") != "")
        {
            cardHold = bool.Parse(PlayerPrefs.GetString("cardHold"));
        }

        PlayerSettings playerSettings = new PlayerSettings()
        {
            WindowResolution = res,
            IsWindowFullscreen = fullscreen,
            GraphicQuality = quality,
            MasterVolume = volume,
            MapKey = mapKey,
            CardKey = cardKey,
            MapHold = mapHold,
            CardHold = cardHold
        };

        return playerSettings;
    }
}