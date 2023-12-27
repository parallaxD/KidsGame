using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image imageDisplay;

    public void LoadImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture != null)
                {
                    imageDisplay.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    PlayerPrefs.SetString("AvatarPath", path);
                }
            }
        }, "Выберите изображение", "image/*");
    }
}
