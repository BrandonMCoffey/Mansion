using UnityEngine;

public class PlayerSettings
{
    public Resolution WindowResolution { get; set; }
    public bool IsWindowFullscreen { get; set; }
    public int GraphicQuality { get; set; }
    public float MasterVolume { get; set; }
    public string MapKey { get; set; }
    public string CardKey { get; set; }
    public bool MapHold { get; set; }
    public bool CardHold { get; set; }
}
