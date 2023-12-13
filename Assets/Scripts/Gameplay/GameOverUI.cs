using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
   [SerializeField] private RectTransform _gameOverPanel;

   public void Awake()
   {
      AudioListener.volume = Settings.IsMuted ? 0 : 1;
   }

   public void Update()
   {
      AudioListener.volume = Settings.IsMuted ? 0 : 1;
   }

   public void OnGameOver()
   {
      _gameOverPanel.gameObject.SetActive(true);
      GameManager.Instance.ChangeSpeed(0);
   }
   public void OnRestart()
   {
      GameManager.Instance.ChangeSpeed(1);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
