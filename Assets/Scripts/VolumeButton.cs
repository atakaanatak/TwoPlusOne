using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    public static bool SoundOn = true;
    [Header("Settings")] 
    public Sprite volumeOnPic;
    public Sprite volumeOffPic;

    [Header("Goal")] 
    public Image changePicture;

    private bool volumeOn = true;

    void Start()
    {
        UpdatePicture();
    }

    public void ChangeIcon()
    {
        volumeOn = !volumeOn;

        if (volumeOn)
            SoundOn = true;
        else
            SoundOn = false;
        UpdatePicture();
    }

    void UpdatePicture()
    {
        if (changePicture == null) return;

        if (volumeOn)
            changePicture.sprite = volumeOnPic;
        else
            changePicture.sprite = volumeOffPic;
    }
}