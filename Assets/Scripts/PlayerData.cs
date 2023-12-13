
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
    public string Name { get; set; }

    public Texture2D AvatarTexture { get; set; }

    public PlayerData(string playerPrefsName, string playerPrefsImgPath)
    {
        if (PlayerPrefs.GetString(playerPrefsName) != string.Empty)
        {
            Name = PlayerPrefs.GetString(playerPrefsName);
        }
        if (PlayerPrefs.GetString(playerPrefsImgPath) != string.Empty)
        {
            AvatarTexture = NativeGallery.LoadImageAtPath(PlayerPrefs.GetString(playerPrefsImgPath));
        }
    }

}
