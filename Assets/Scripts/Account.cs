using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Account : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private Image _playerAvatar;

    private PlayerData _playerData;
    [SerializeField] private AchievementManager _achievementManager;

    private void Awake()
    {
        _playerData = new PlayerData("PlayerName", "AvatarPath");
        if (_playerData.Name != null)
        {
            _playerNameText.text = _playerData.Name;
        }
        if(_playerData.AvatarTexture != null)
        {            
            _playerAvatar.sprite = Sprite.Create(_playerData.AvatarTexture, new Rect(0, 0, _playerData.AvatarTexture.width, _playerData.AvatarTexture.height), Vector2.zero);
        }
    }

    private void OnEnable()
    {
        foreach (var achievement in _achievementManager.AchievementsList)
        {
            if (PlayerPrefs.GetInt(achievement.name) == 1)
            {
                achievement.transform.gameObject.SetActive(true);
            }
        }
    }
}
