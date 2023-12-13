using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Text _muteText;
    [SerializeField]private string muteSText = "Mute";
    [SerializeField]private string unmuteSText = "Unmute";
    [SerializeField]private Sprite _unmuteButton;
    [SerializeField]private Image _muteImage;
    public static bool IsMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        IsMuted = PlayerPrefs.GetInt("Mute",0) == 1;
        if(IsMuted)
        {
            if(_muteText != null)
            {
                _muteText.SetText(unmuteSText);
            }
            if(_muteImage != null)
            {
                _muteImage.overrideSprite = _unmuteButton;
            }
        }
        else
        {
            if(_muteText != null)
            {
                _muteText.SetText(muteSText);
            }
            if(_muteImage != null)
            {
                _muteImage.overrideSprite = null;
            }
        }
    }
    
    public void Mute()
    {
        IsMuted = !IsMuted;
        if(IsMuted)
        {
            if(_muteText != null)
            {
                _muteText.SetText(unmuteSText);
            }
            if(_muteImage != null)
            {
                _muteImage.overrideSprite = _unmuteButton;
            }
        }
        else
        {
            if(_muteText != null)
            {
                _muteText.SetText(muteSText);
            }
            if(_muteImage != null)
            {
                _muteImage.overrideSprite = null;
            }
        }
        
        PlayerPrefs.SetInt("Mute",IsMuted ? 1 : 0);
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
